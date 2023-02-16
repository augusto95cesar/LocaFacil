using System.ComponentModel.DataAnnotations;

namespace LocaFacilWeb.Models.ViewModels
{
    public class Login
    { 
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}