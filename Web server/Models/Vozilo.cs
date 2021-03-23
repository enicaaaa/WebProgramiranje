using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Web_server.Models
{
    [Table("Vozilo")]
    public class Vozilo 
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Registarska oznaka")]
        [MaxLength(7)]
        public string Registarska_oznaka  { get; set; }

        [Column("Ime")]
        [MaxLength(255)]
        public string Ime { get; set; }

        [Column("Prezime")]
        [MaxLength(255)]
        public string Prezime { get; set; }

        [Column("Broj telefona")]
        [MaxLength(10)]
        public string Broj_telefona { get; set; }

        //public ParkingMesto mesto {get; set;}
 
    }
}