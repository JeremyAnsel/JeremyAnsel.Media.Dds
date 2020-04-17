﻿using System;

namespace JeremyAnsel.Media.Dds
{
    [Flags]
    public enum DdsPixelFormatOptions
    {
        /// <summary>
        /// Texture contains alpha data; dwRGBAlphaBitMask contains valid data.
        /// </summary>
        AlphaPixels = 0x1,

        /// <summary>
        /// Used in some older DDS files for alpha channel only uncompressed data (dwRGBBitCount contains the alpha channel bitcount; dwABitMask contains valid data).
        /// </summary>
        Alpha = 0x2,

        /// <summary>
        /// Texture contains compressed RGB data; dwFourCC contains valid data.
        /// </summary>
        FourCC = 0x4,

        /// <summary>
        /// Texture contains uncompressed RGB data; dwRGBBitCount and the RGB masks (dwRBitMask, dwRBitMask, dwRBitMask) contain valid data.
        /// </summary>
        Rgb = 0x40,

        ///// <summary>
        ///// Used in some older DDS files for YUV uncompressed data (dwRGBBitCount contains the YUV bit count; dwRBitMask contains the Y mask, dwGBitMask contains the U mask, dwBBitMask contains the V mask).
        ///// </summary>
        //Yuv = 0x200,

        /// <summary>
        /// Used in some older DDS files for single channel color uncompressed data (dwRGBBitCount contains the luminance channel bit count; dwRBitMask contains the channel mask). Can be combined with DDPF_ALPHAPIXELS for a two channel DDS file.
        /// </summary>
        Luminance = 0x20000,

        /// <summary>
        /// Bump-map data in the pixel format is valid. Bump-map information is in the dwBumpBitCount, dwBumpDuBitMask, dwBumpDvBitMask, and dwBumpLuminanceBitMask members.
        /// </summary>
        BumpDuDv = 0x80000
    }
}
