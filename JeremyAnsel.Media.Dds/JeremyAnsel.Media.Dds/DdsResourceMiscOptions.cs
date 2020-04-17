using System;

namespace JeremyAnsel.Media.Dds
{
    /// <summary>
    /// Identifies options for resources.
    /// </summary>
    [Flags]
    public enum DdsResourceMiscOptions
    {
        /// <summary>
        /// No option.
        /// </summary>
        None = 0,

        /// <summary>
        /// Sets a resource to be a cube texture created from a Texture2DArray that contains 6 textures.
        /// </summary>
        TextureCube = 0x00000004
    }
}
