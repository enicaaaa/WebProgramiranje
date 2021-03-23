using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Web_server.Models
{
    [Table("Garaza")] //ime tabele u bazi 
    public class Garaza 
    {
        //kolone: (PO JEDAN PROPERTY ZA SVAKU KOLONU U BAZI)
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Naziv")]
        [MaxLength(255)]
        public string Naziv { get; set; }

        [Column("Ulica")]
        [MaxLength(255)]
        public string Ulica { get; set; }

        [Column("Broj")]
        public int Broj { get; set; }

        [Column("Broj mesta")]
        public int Broj_mesta { get; set; }

        [Column("Broj nivoa")]
        public int Broj_nivoa { get; set; }


        public virtual List<ParkingMesto> ParkingMesta { get; set; } //pokazivac na klasu ParknigMesto.js da bi znali da postoji veza izmedju
    }
}