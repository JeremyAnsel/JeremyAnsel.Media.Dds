namespace JeremyAnsel.Media.Dds
{
    public sealed class DdsPixelFormat
    {
        internal DdsPixelFormat()
        {
        }

        public DdsPixelFormatOptions Options { get; internal set; }

        public DdsFourCC FourCC { get; internal set; }

        public int RgbBitCount { get; internal set; }

        public uint RedBitMask { get; internal set; }

        public uint GreenBitMask { get; internal set; }

        public uint BlueBitMask { get; internal set; }

        public uint AlphaBitMask { get; internal set; }
    }
}
