using MagicVilla_API.Modelos.DTO;

namespace MagicVilla_API.Datos
{
    public static class VillaStore
    {
        public static List<VillaDto> villaList = new List<VillaDto> {
            new VillaDto{ Id=1, Nombre="Villa1", Ocupantes=50, MetrosCuadrados=100 },
            new VillaDto{ Id=2, Nombre="Villa2", Ocupantes=22, MetrosCuadrados=222 }
        };
    }
}
