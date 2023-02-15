using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocaFacilWeb.Models.Entity
{
    public class Locacao
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int FilmeId { get; set; }
        public DateTime  DataAluguel { get; set; }
        public DateTime Devolução { get; set; }
        public decimal ValorDiaAluguel { get; set; }
        public decimal TotalAluguel { get; set; }
        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }
        [ForeignKey("FilmeId")]
        public virtual Filme Filme { get; set; }
    }
}