using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZXing;

namespace Hontrack_library
{
    public partial class BorrowBook : UserControl
    {
        private FilterInfoCollection filterInfoCollection;
        private VideoCaptureDevice videoCaptureDevice;
        private bool isCameraRunning = false;

        public BorrowBook()
        {
            InitializeComponent();
            Status.DropDownStyle = ComboBoxStyle.DropDownList;
            displayBookData();

            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (filterInfoCollection != null && filterInfoCollection.Count > 0)
            {
                foreach (FilterInfo device in filterInfoCollection)
                {
                    Camera.Items.Add(device.Name);
                }
                Camera.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No camera devices found.");
            }

            // Handle form visibility changes
            this.VisibleChanged += BorrowBook_VisibleChanged;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            IDTextBox.Clear();
            BookTitleTextBox.Clear();
            BIssueTextBox.Clear();
            AuthotTextBox.Clear();
            Status.SelectedIndex = -1;
        }

        private void CameraBtn_Click(object sender, EventArgs e)
        {
            if (!isCameraRunning)
            {
                StartCamera();
            }
            else
            {
                StopCamera();
            }
        }

        private void StartCamera()
        {
            if (filterInfoCollection.Count > 0)
            {
                // Stop any running camera before starting a new one
                StopCamera();

                videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[Camera.SelectedIndex].MonikerString);

                // Set the desired resolution (choose one supported by your camera)
                if (videoCaptureDevice.VideoCapabilities.Length > 0)
                {
                    var highestResolution = videoCaptureDevice.VideoCapabilities
                        .OrderByDescending(vc => vc.FrameSize.Width * vc.FrameSize.Height)
                        .First();
                    videoCaptureDevice.VideoResolution = highestResolution;
                }

                videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
                videoCaptureDevice.Start();
                isCameraRunning = true;
            }
            else
            {
                MessageBox.Show("No camera selected.");
            }
        }

        private void StopCamera()
        {
            if (videoCaptureDevice != null && videoCaptureDevice.IsRunning)
            {
                videoCaptureDevice.SignalToStop();
                videoCaptureDevice.WaitForStop(); // Ensure camera stops completely
                videoCaptureDevice.NewFrame -= VideoCaptureDevice_NewFrame;
                isCameraRunning = false;
            }
        }

        private void BorrowBook_VisibleChanged(object sender, EventArgs e)
        {
            // Only start/stop camera if the form is visible
            if (this.Visible && !isCameraRunning)
            {
                StartCamera();
            }
            else if (!this.Visible && isCameraRunning)
            {
                StopCamera();
            }
        }

        private void VideoCaptureDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader();

            Bitmap resizedBitmap = new Bitmap(bitmap, new Size(640, 480));

            var result = reader.Decode(resizedBitmap);
            if (result != null)
            {
                IDTextBox.Invoke(new MethodInvoker(delegate
                {
                    IDTextBox.Text = result.Text;
                }));
            }

            CameraFrame.Image = resizedBitmap;
        }

        private void BorrowBook_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera();
        }

        public void displayBookData()
        {
            BookData bookData = new BookData();
            List<BookData> listdata = bookData.BookListData();

            dataGridView1.DataSource = listdata;

        }
    }
}
