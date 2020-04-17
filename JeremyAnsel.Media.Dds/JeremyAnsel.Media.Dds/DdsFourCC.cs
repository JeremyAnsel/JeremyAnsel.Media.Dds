using System.Diagnostics.CodeAnalysis;

namespace JeremyAnsel.Media.Dds
{
    [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue", Justification = "Reviewed.")]
    [SuppressMessage("Naming", "CA1707:Les identificateurs ne doivent pas contenir de traits de soulignement", Justification = "Reviewed")]
    public enum DdsFourCC
    {
        DXT1 = 'D' | ('X' << 8) | ('T' << 16) | ('1' << 24),

        DXT2 = 'D' | ('X' << 8) | ('T' << 16) | ('2' << 24),

        DXT3 = 'D' | ('X' << 8) | ('T' << 16) | ('3' << 24),

        DXT4 = 'D' | ('X' << 8) | ('T' << 16) | ('4' << 24),

        DXT5 = 'D' | ('X' << 8) | ('T' << 16) | ('5' << 24),

        DX10 = 'D' | ('X' << 8) | ('1' << 16) | ('0' << 24),

        BC4U = 'B' | ('C' << 8) | ('4' << 16) | ('U' << 24),

        BC4S = 'B' | ('C' << 8) | ('4' << 16) | ('S' << 24),

        BC5U = 'B' | ('C' << 8) | ('5' << 16) | ('U' << 24),

        BC5S = 'B' | ('C' << 8) | ('5' << 16) | ('S' << 24),

        RGBG = 'R' | ('G' << 8) | ('B' << 16) | ('G' << 24),

        GRGB = 'G' | ('R' << 8) | ('G' << 16) | ('B' << 24),

        YUY2 = 'Y' | ('U' << 8) | ('Y' << 16) | ('2' << 24),

        D3DFMT_A16B16G16R16 = 36,

        D3DFMT_Q16W16V16U16 = 110,

        D3DFMT_R16F = 111,

        D3DFMT_G16R16F = 112,

        D3DFMT_A16B16G16R16F = 113,

        D3DFMT_R32F = 114,

        D3DFMT_G32R32F = 115,

        D3DFMT_A32B32G32R32F = 116
    }
}
