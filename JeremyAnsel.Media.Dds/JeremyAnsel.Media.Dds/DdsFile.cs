using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace JeremyAnsel.Media.Dds
{
    public sealed class DdsFile
    {
        private const int DdsMagic = 0x20534444;

        internal DdsFile()
        {
            this.PixelFormat = new DdsPixelFormat();
        }

        public DdsOptions Options { get; private set; }

        public int Height { get; private set; }

        public int Width { get; private set; }

        public int LinearSize { get; private set; }

        public int Depth { get; private set; }

        public int MipmapCount { get; private set; }

        public DdsPixelFormat PixelFormat { get; private set; }

        public DdsCaps Caps { get; private set; }

        public DdsAdditionalCaps Caps2 { get; private set; }

        public DdsFormat Format { get; private set; }

        public DdsResourceDimension ResourceDimension { get; private set; }

        public DdsResourceMiscOptions ResourceMiscOptions { get; private set; }

        public int ArraySize { get; private set; }

        public DdsAlphaMode AlphaMode { get; private set; }

        public int DataOffset { get; private set; }

        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
        public byte[] Data { get; private set; }

        public static DdsFile FromFile(string fileName)
        {
            using (FileStream filestream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                return FromStream(filestream);
            }
        }

        [SuppressMessage("Reliability", "CA2000:Supprimer les objets avant la mise hors de portée", Justification = "Reviewed.")]
        public static DdsFile FromStream(Stream stream)
        {
            DdsFile dds = new DdsFile();

            BinaryReader file = new BinaryReader(stream);

            int magic = file.ReadInt32();

            if (magic != DdsFile.DdsMagic)
            {
                throw new InvalidDataException();
            }

            if (file.ReadInt32() != 124)
            {
                throw new InvalidDataException();
            }

            dds.Options = (DdsOptions)file.ReadInt32();
            dds.Height = file.ReadInt32();
            dds.Width = file.ReadInt32();
            dds.LinearSize = file.ReadInt32();
            dds.Depth = file.ReadInt32();
            dds.MipmapCount = file.ReadInt32();

            file.BaseStream.Position += 44;

            if (file.ReadInt32() != 32)
            {
                throw new InvalidDataException();
            }

            dds.PixelFormat.Options = (DdsPixelFormatOptions)file.ReadInt32();
            dds.PixelFormat.FourCC = (DdsFourCC)file.ReadInt32();
            dds.PixelFormat.RgbBitCount = file.ReadInt32();
            dds.PixelFormat.RedBitMask = file.ReadUInt32();
            dds.PixelFormat.GreenBitMask = file.ReadUInt32();
            dds.PixelFormat.BlueBitMask = file.ReadUInt32();
            dds.PixelFormat.AlphaBitMask = file.ReadUInt32();

            dds.Caps = (DdsCaps)file.ReadInt32();
            dds.Caps2 = (DdsAdditionalCaps)file.ReadInt32();

            file.BaseStream.Position += 12;

            if ((dds.PixelFormat.Options & DdsPixelFormatOptions.FourCC) != 0 && dds.PixelFormat.FourCC == DdsFourCC.DX10)
            {
                dds.Format = (DdsFormat)file.ReadInt32();
                dds.ResourceDimension = (DdsResourceDimension)file.ReadInt32();
                dds.ResourceMiscOptions = (DdsResourceMiscOptions)file.ReadInt32();
                dds.ArraySize = file.ReadInt32();

                DdsAlphaMode mode = (DdsAlphaMode)(file.ReadInt32() & 0x7);
                switch (mode)
                {
                    case DdsAlphaMode.Straight:
                    case DdsAlphaMode.Premultiplied:
                    case DdsAlphaMode.Opaque:
                    case DdsAlphaMode.Custom:
                        dds.AlphaMode = mode;
                        break;
                }
            }
            else
            {
                dds.Format = DdsHelpers.GetDdsFormat(dds.PixelFormat);

                if ((dds.PixelFormat.Options & DdsPixelFormatOptions.FourCC) != 0)
                {
                    switch (dds.PixelFormat.FourCC)
                    {
                        case DdsFourCC.DXT2:
                        case DdsFourCC.DXT4:
                            dds.AlphaMode = DdsAlphaMode.Premultiplied;
                            break;
                    }
                }
            }

            dds.DataOffset = (int)file.BaseStream.Position;
            dds.Data = file.ReadBytes((int)file.BaseStream.Length - (int)file.BaseStream.Position);

            return dds;
        }
    }
}
