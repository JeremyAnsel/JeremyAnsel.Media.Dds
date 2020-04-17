using System;
using System.Diagnostics.CodeAnalysis;

namespace JeremyAnsel.Media.Dds
{
    public static class DdsHelpers
    {
        public static int GetBitsPerPixel(DdsFormat format)
        {
            switch (format)
            {
                case DdsFormat.R32G32B32A32Typeless:
                case DdsFormat.R32G32B32A32Float:
                case DdsFormat.R32G32B32A32UInt:
                case DdsFormat.R32G32B32A32SInt:
                    return 128;

                case DdsFormat.R32G32B32Typeless:
                case DdsFormat.R32G32B32Float:
                case DdsFormat.R32G32B32UInt:
                case DdsFormat.R32G32B32SInt:
                    return 96;

                case DdsFormat.R16G16B16A16Typeless:
                case DdsFormat.R16G16B16A16Float:
                case DdsFormat.R16G16B16A16UNorm:
                case DdsFormat.R16G16B16A16UInt:
                case DdsFormat.R16G16B16A16SNorm:
                case DdsFormat.R16G16B16A16SInt:
                case DdsFormat.R32G32Typeless:
                case DdsFormat.R32G32Float:
                case DdsFormat.R32G32UInt:
                case DdsFormat.R32G32SInt:
                case DdsFormat.R32G8X24Typeless:
                case DdsFormat.D32FloatS8X24UInt:
                case DdsFormat.R32FloatX8X24Typeless:
                case DdsFormat.X32TypelessG8X24UInt:
                case DdsFormat.Y416:
                case DdsFormat.Y210:
                case DdsFormat.Y216:
                    return 64;

                case DdsFormat.R10G10B10A2Typeless:
                case DdsFormat.R10G10B10A2UNorm:
                case DdsFormat.R10G10B10A2UInt:
                case DdsFormat.R11G11B10Float:
                case DdsFormat.R8G8B8A8Typeless:
                case DdsFormat.R8G8B8A8UNorm:
                case DdsFormat.R8G8B8A8UNormSrgb:
                case DdsFormat.R8G8B8A8UInt:
                case DdsFormat.R8G8B8A8SNorm:
                case DdsFormat.R8G8B8A8SInt:
                case DdsFormat.R16G16Typeless:
                case DdsFormat.R16G16Float:
                case DdsFormat.R16G16UNorm:
                case DdsFormat.R16G16UInt:
                case DdsFormat.R16G16SNorm:
                case DdsFormat.R16G16SInt:
                case DdsFormat.R32Typeless:
                case DdsFormat.D32Float:
                case DdsFormat.R32Float:
                case DdsFormat.R32UInt:
                case DdsFormat.R32SInt:
                case DdsFormat.R24G8Typeless:
                case DdsFormat.D24UNormS8UInt:
                case DdsFormat.R24UNormX8Typeless:
                case DdsFormat.X24TypelessG8UInt:
                case DdsFormat.R9G9B9E5SharedExp:
                case DdsFormat.R8G8B8G8UNorm:
                case DdsFormat.G8R8G8B8UNorm:
                case DdsFormat.B8G8R8A8UNorm:
                case DdsFormat.B8G8R8X8UNorm:
                case DdsFormat.R10G10B10XRBiasA2UNorm:
                case DdsFormat.B8G8R8A8Typeless:
                case DdsFormat.B8G8R8A8UNormSrgb:
                case DdsFormat.B8G8R8X8Typeless:
                case DdsFormat.B8G8R8X8UNormSrgb:
                case DdsFormat.AYuv:
                case DdsFormat.Y410:
                case DdsFormat.Yuy2:
                    return 32;

                case DdsFormat.P010:
                case DdsFormat.P016:
                    return 24;

                case DdsFormat.R8G8Typeless:
                case DdsFormat.R8G8UNorm:
                case DdsFormat.R8G8UInt:
                case DdsFormat.R8G8SNorm:
                case DdsFormat.R8G8SInt:
                case DdsFormat.R16Typeless:
                case DdsFormat.R16Float:
                case DdsFormat.D16UNorm:
                case DdsFormat.R16UNorm:
                case DdsFormat.R16UInt:
                case DdsFormat.R16SNorm:
                case DdsFormat.R16SInt:
                case DdsFormat.B5G6R5UNorm:
                case DdsFormat.B5G5R5A1UNorm:
                case DdsFormat.A8P8:
                case DdsFormat.B4G4R4A4UNorm:
                    return 16;

                case DdsFormat.NV12:
                case DdsFormat.P420Opaque:
                case DdsFormat.NV11:
                    return 12;

                case DdsFormat.R8Typeless:
                case DdsFormat.R8UNorm:
                case DdsFormat.R8UInt:
                case DdsFormat.R8SNorm:
                case DdsFormat.R8SInt:
                case DdsFormat.A8UNorm:
                case DdsFormat.AI44:
                case DdsFormat.IA44:
                case DdsFormat.P8:
                    return 8;

                case DdsFormat.R1UNorm:
                    return 1;

                case DdsFormat.BC1Typeless:
                case DdsFormat.BC1UNorm:
                case DdsFormat.BC1UNormSrgb:
                case DdsFormat.BC4Typeless:
                case DdsFormat.BC4UNorm:
                case DdsFormat.BC4SNorm:
                    return 4;

                case DdsFormat.BC2Typeless:
                case DdsFormat.BC2UNorm:
                case DdsFormat.BC2UNormSrgb:
                case DdsFormat.BC3Typeless:
                case DdsFormat.BC3UNorm:
                case DdsFormat.BC3UNormSrgb:
                case DdsFormat.BC5Typeless:
                case DdsFormat.BC5UNorm:
                case DdsFormat.BC5SNorm:
                case DdsFormat.BC6HalfTypeless:
                case DdsFormat.BC6HalfUF16:
                case DdsFormat.BC6HalfSF16:
                case DdsFormat.BC7Typeless:
                case DdsFormat.BC7UNorm:
                case DdsFormat.BC7UNormSrgb:
                    return 8;

                default:
                    return 0;
            }
        }

        public static void GetSurfaceInfo(int width, int height, DdsFormat format, out int outNumBytes, out int outRowBytes, out int outNumRows)
        {
            bool bc = false;
            bool packed = false;
            bool planar = false;
            int bpe = 0;

            switch (format)
            {
                case DdsFormat.BC1Typeless:
                case DdsFormat.BC1UNorm:
                case DdsFormat.BC1UNormSrgb:
                case DdsFormat.BC4Typeless:
                case DdsFormat.BC4UNorm:
                case DdsFormat.BC4SNorm:
                    bc = true;
                    bpe = 8;
                    break;

                case DdsFormat.BC2Typeless:
                case DdsFormat.BC2UNorm:
                case DdsFormat.BC2UNormSrgb:
                case DdsFormat.BC3Typeless:
                case DdsFormat.BC3UNorm:
                case DdsFormat.BC3UNormSrgb:
                case DdsFormat.BC5Typeless:
                case DdsFormat.BC5UNorm:
                case DdsFormat.BC5SNorm:
                case DdsFormat.BC6HalfTypeless:
                case DdsFormat.BC6HalfUF16:
                case DdsFormat.BC6HalfSF16:
                case DdsFormat.BC7Typeless:
                case DdsFormat.BC7UNorm:
                case DdsFormat.BC7UNormSrgb:
                    bc = true;
                    bpe = 16;
                    break;

                case DdsFormat.R8G8B8G8UNorm:
                case DdsFormat.G8R8G8B8UNorm:
                case DdsFormat.Yuy2:
                    packed = true;
                    bpe = 4;
                    break;

                case DdsFormat.Y210:
                case DdsFormat.Y216:
                    packed = true;
                    bpe = 8;
                    break;

                case DdsFormat.NV12:
                case DdsFormat.P420Opaque:
                    planar = true;
                    bpe = 2;
                    break;

                case DdsFormat.P010:
                case DdsFormat.P016:
                    planar = true;
                    bpe = 4;
                    break;
            }

            int rowBytes;
            int numRows;
            int numBytes;
            if (bc)
            {
                int numBlocksWide = 0;
                if (width > 0)
                {
                    numBlocksWide = Math.Max(1, (width + 3) / 4);
                }

                int numBlocksHigh = 0;
                if (height > 0)
                {
                    numBlocksHigh = Math.Max(1, (height + 3) / 4);
                }

                rowBytes = numBlocksWide * bpe;
                numRows = numBlocksHigh;
                numBytes = rowBytes * numBlocksHigh;
            }
            else if (packed)
            {
                rowBytes = ((width + 1) >> 1) * bpe;
                numRows = height;
                numBytes = rowBytes * height;
            }
            else if (format == DdsFormat.NV11)
            {
                rowBytes = ((width + 3) >> 2) * 4;
                numRows = height * 2; // Direct3D makes this simplifying assumption, although it is larger than the 4:1:1 data
                numBytes = rowBytes * numRows;
            }
            else if (planar)
            {
                rowBytes = ((width + 1) >> 1) * bpe;
                numBytes = (rowBytes * height) + ((rowBytes * height + 1) >> 1);
                numRows = height + ((height + 1) >> 1);
            }
            else
            {
                int bpp = DdsHelpers.GetBitsPerPixel(format);
                rowBytes = (width * bpp + 7) / 8; // round up to nearest byte
                numRows = height;
                numBytes = rowBytes * height;
            }

            outNumBytes = numBytes;
            outRowBytes = rowBytes;
            outNumRows = numRows;
        }

        public static DdsFormat MakeSrgb(DdsFormat format)
        {
            switch (format)
            {
                case DdsFormat.R8G8B8A8UNorm:
                    return DdsFormat.R8G8B8A8UNormSrgb;

                case DdsFormat.BC1UNorm:
                    return DdsFormat.BC1UNormSrgb;

                case DdsFormat.BC2UNorm:
                    return DdsFormat.BC2UNormSrgb;

                case DdsFormat.BC3UNorm:
                    return DdsFormat.BC3UNormSrgb;

                case DdsFormat.B8G8R8A8UNorm:
                    return DdsFormat.B8G8R8A8UNormSrgb;

                case DdsFormat.B8G8R8X8UNorm:
                    return DdsFormat.B8G8R8X8UNormSrgb;

                case DdsFormat.BC7UNorm:
                    return DdsFormat.BC7UNormSrgb;

                default:
                    return format;
            }
        }

        private static bool IsBitMask(DdsPixelFormat ddpf, uint r, uint g, uint b, uint a)
        {
            return ddpf.RedBitMask == r && ddpf.GreenBitMask == g && ddpf.BlueBitMask == b && ddpf.AlphaBitMask == a;
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        internal static DdsFormat GetDdsFormat(DdsPixelFormat ddpf)
        {
            if ((ddpf.Options & DdsPixelFormatOptions.Rgb) != 0)
            {
                switch (ddpf.RgbBitCount)
                {
                    case 32:
                        if (IsBitMask(ddpf, 0x000000ff, 0x0000ff00, 0x00ff0000, 0xff000000))
                        {
                            return DdsFormat.R8G8B8A8UNorm;
                        }

                        if (IsBitMask(ddpf, 0x00ff0000, 0x0000ff00, 0x000000ff, 0xff000000))
                        {
                            return DdsFormat.B8G8R8A8UNorm;
                        }

                        if (IsBitMask(ddpf, 0x00ff0000, 0x0000ff00, 0x000000ff, 0x00000000))
                        {
                            return DdsFormat.B8G8R8X8UNorm;
                        }

                        if (IsBitMask(ddpf, 0x3ff00000, 0x000ffc00, 0x000003ff, 0xc0000000))
                        {
                            return DdsFormat.R10G10B10A2UNorm;
                        }

                        if (IsBitMask(ddpf, 0x0000ffff, 0xffff0000, 0x00000000, 0x00000000))
                        {
                            return DdsFormat.R16G16UNorm;
                        }

                        if (IsBitMask(ddpf, 0xffffffff, 0x00000000, 0x00000000, 0x00000000))
                        {
                            return DdsFormat.R32Float;
                        }

                        break;

                    case 24:
                        break;

                    case 16:
                        if (IsBitMask(ddpf, 0x7c00, 0x03e0, 0x001f, 0x8000))
                        {
                            return DdsFormat.B5G5R5A1UNorm;
                        }

                        if (IsBitMask(ddpf, 0xf800, 0x07e0, 0x001f, 0x0000))
                        {
                            return DdsFormat.B5G6R5UNorm;
                        }

                        if (IsBitMask(ddpf, 0x0f00, 0x00f0, 0x000f, 0xf000))
                        {
                            return DdsFormat.B4G4R4A4UNorm;
                        }

                        break;
                }
            }
            else if ((ddpf.Options & DdsPixelFormatOptions.Luminance) != 0)
            {
                switch (ddpf.RgbBitCount)
                {
                    case 16:
                        if (IsBitMask(ddpf, 0x0000ffff, 0x00000000, 0x00000000, 0x00000000))
                        {
                            return DdsFormat.R16UNorm;
                        }

                        if (IsBitMask(ddpf, 0x000000ff, 0x00000000, 0x00000000, 0x0000ff00))
                        {
                            return DdsFormat.R8G8UNorm;
                        }

                        break;

                    case 8:
                        if (IsBitMask(ddpf, 0x000000ff, 0x00000000, 0x00000000, 0x00000000))
                        {
                            return DdsFormat.R8UNorm;
                        }

                        if (IsBitMask(ddpf, 0x000000ff, 0x00000000, 0x00000000, 0x0000ff00))
                        {
                            return DdsFormat.R8G8UNorm;
                        }

                        break;
                }
            }
            else if ((ddpf.Options & DdsPixelFormatOptions.Alpha) != 0)
            {
                if (ddpf.RgbBitCount == 8)
                {
                    return DdsFormat.A8UNorm;
                }
            }
            else if ((ddpf.Options & DdsPixelFormatOptions.BumpDuDv) != 0)
            {
                switch (ddpf.RgbBitCount)
                {
                    case 32:
                        if (IsBitMask(ddpf, 0x000000ff, 0x0000ff00, 0x00ff0000, 0xff000000))
                        {
                            return DdsFormat.R8G8B8A8SNorm;
                        }

                        if (IsBitMask(ddpf, 0x0000ffff, 0xffff0000, 0x00000000, 0x00000000))
                        {
                            return DdsFormat.R16G16SNorm;
                        }

                        break;

                    case 16:
                        if (IsBitMask(ddpf, 0x00ff, 0xff00, 0x0000, 0x0000))
                        {
                            return DdsFormat.R8G8SNorm;
                        }

                        break;
                }
            }
            else if ((ddpf.Options & DdsPixelFormatOptions.FourCC) != 0)
            {
                switch (ddpf.FourCC)
                {
                    case DdsFourCC.DXT1:
                        return DdsFormat.BC1UNorm;

                    case DdsFourCC.DXT3:
                        return DdsFormat.BC2UNorm;

                    case DdsFourCC.DXT5:
                        return DdsFormat.BC3UNorm;

                    case DdsFourCC.DXT2:
                        return DdsFormat.BC2UNorm;

                    case DdsFourCC.DXT4:
                        return DdsFormat.BC3UNorm;

                    case DdsFourCC.BC4U:
                        return DdsFormat.BC4UNorm;

                    case DdsFourCC.BC4S:
                        return DdsFormat.BC4SNorm;

                    case DdsFourCC.BC5U:
                        return DdsFormat.BC5UNorm;

                    case DdsFourCC.BC5S:
                        return DdsFormat.BC5SNorm;

                    case DdsFourCC.RGBG:
                        return DdsFormat.R8G8B8G8UNorm;

                    case DdsFourCC.GRGB:
                        return DdsFormat.G8R8G8B8UNorm;

                    case DdsFourCC.YUY2:
                        return DdsFormat.Yuy2;

                    case DdsFourCC.D3DFMT_A16B16G16R16:
                        return DdsFormat.R16G16B16A16UNorm;

                    case DdsFourCC.D3DFMT_Q16W16V16U16:
                        return DdsFormat.R16G16B16A16SNorm;

                    case DdsFourCC.D3DFMT_R16F:
                        return DdsFormat.R16Float;

                    case DdsFourCC.D3DFMT_G16R16F:
                        return DdsFormat.R16G16Float;

                    case DdsFourCC.D3DFMT_A16B16G16R16F:
                        return DdsFormat.R16G16B16A16Float;

                    case DdsFourCC.D3DFMT_R32F:
                        return DdsFormat.R32Float;

                    case DdsFourCC.D3DFMT_G32R32F:
                        return DdsFormat.R32G32Float;

                    case DdsFourCC.D3DFMT_A32B32G32R32F:
                        return DdsFormat.R32G32B32A32Float;
                }
            }

            return DdsFormat.Unknown;
        }
    }
}
