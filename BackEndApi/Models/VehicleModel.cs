using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndApi.Models
{
    public class VehicleModel
    {
        [Key]
        public int VehicleId { get; set; }
        public string? VehicleNo { get; set; }
        public string? VehicleName { get; set; }
        public string? VehicleType { get; set; }
        public string? Location { get; set; }
        public DateTime? YearOfMake { get; set; }
        public int? IDVvalue { get; set; }
        [ForeignKey("UserID")]
        public UserModel? User { get; set; }
    }
}
