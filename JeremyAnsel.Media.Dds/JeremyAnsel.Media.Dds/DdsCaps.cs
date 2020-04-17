using System;

namespace JeremyAnsel.Media.Dds
{
    [Flags]
    public enum DdsCaps
    {
        /// <summary>
        /// Optional; must be used on any file that contains more than one surface (a mipmap, a cubic environment map, or volume texture).
        /// </summary>
        Complex = 0x8,

        /// <summary>
        /// Optional; should be used for a mipmap.
        /// </summary>
        Mipmap = 0x400000,

        /// <summary>
        /// Required.
        /// </summary>
        Texture = 0x1000
    }
}
