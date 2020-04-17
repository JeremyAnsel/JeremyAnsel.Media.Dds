namespace JeremyAnsel.Media.Dds
{
    public enum DdsAlphaMode
    {
        /// <summary>
        /// Alpha channel content is unknown. This is the value for legacy files, which typically is assumed to be 'straight' alpha.
        /// </summary>
        Unknown,

        /// <summary>
        /// Any alpha channel content is presumed to use straight alpha.
        /// </summary>
        Straight,

        /// <summary>
        /// Any alpha channel content is using premultiplied alpha. The only legacy file formats that indicate this information are 'DX2' and 'DX4'.
        /// </summary>
        Premultiplied,

        /// <summary>
        /// Any alpha channel content is all set to fully opaque.
        /// </summary>
        Opaque,

        /// <summary>
        /// Any alpha channel content is being used as a 4th channel and is not intended to represent transparency (straight or premultiplied).
        /// </summary>
        Custom
    }
}
