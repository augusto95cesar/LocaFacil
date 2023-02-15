using LocaFacilWeb.Models.Enums;

namespace LocaFacilWeb.Models.Entity
{
    public class Filme
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public TipoFilmes Genero { get; set; }
    }
}