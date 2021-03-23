using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace Web_server.Models
{
    [Table("Parking mesto")]
    public class ParkingMesto 
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Vozilo")]
        public Vozilo Vozilo { get; set; }

        [Column("Vreme parkiranja")]
        public int Vreme { get; set; }

        [Column("Status")]
        public bool Tip { get; set; }

        [JsonIgnore]
        public Garaza Garaza { get; set; }
        
    }
}