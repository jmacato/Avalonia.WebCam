namespace Avalonia.WebCam.Backend
{
    public interface IVideoFormat
    {
        string FormatName { get; }
        PixelSize Resolution { get; }
    }
}