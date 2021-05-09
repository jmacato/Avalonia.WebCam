using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using System;

namespace Avalonia.WebCam.Sample.Views
{
    public partial class MainWindow : Window
    {
        private Image _image;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
      
                DoStuff();

 
        }

        void DoStuff()
        { 

            var image = this.FindControl<Image>("Preview");

            // [How to use]
            // check USB camera is available.
            string[] devices = WindowsCapture.FindDevices();
            if (devices.Length == 0) return; // no camera.

            // check format.
            int cameraIndex = 0;
            WindowsCapture.VideoFormat[] formats = WindowsCapture.GetVideoFormat(cameraIndex);
            for (int i = 0; i < formats.Length; i++) Console.WriteLine("{0}:{1}", i, formats[i]);

            // create usb camera and start.
            var camera = new WindowsCapture(cameraIndex, formats[0]);
            camera.Start();

            // get image.
            // Immediately after starting the USB camera,
            // GetBitmap() fails because image buffer is not prepared yet.
            var bmp = camera.GetBitmap();

            //// show image in PictureBox.
            var timer = new System.Timers.Timer(100);
            timer.Elapsed += (s, ev) =>
            {
                Dispatcher.UIThread.InvokeAsync(() =>
                {

                     if(image is not null)
                    image.Source = camera.GetBitmap();

                    
                });
            };

            timer.Start();

        }
    }
}
