using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace Avalonia.WebCam.Backend
{
    public interface ICameraBackend : INotifyPropertyChanged
    {
        IVideoFormat[] GetAvailableVideoFormats(ICamera target);

        ICamera[] GetAvailableCameras();

        Task<bool> TryStartAsync(
            ICamera targetCamera,
            IVideoFormat targetVideoFormat, 
            Action<ICamera, IVideoFormat, ILockedFramebuffer> frameCallback);
        
        bool IsRunning { get; }
    }
}