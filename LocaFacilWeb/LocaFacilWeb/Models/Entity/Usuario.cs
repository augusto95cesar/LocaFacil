using LocaFacilWeb.Models.Enums;

namespace LocaFacilWeb.Models.Entity
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public TipoUsuarios UserType { get; set; }
        public string Senha { get; set; }
    }
}