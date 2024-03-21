using System.ComponentModel.DataAnnotations;

namespace BackEndApi.DTO
{
    public class VehicleDTO
    {
        [Key]
        public int VehicleId { get; set; }
        public string? VehicleNo { get; set; }
        public string? VehicleName { get; set; }
        public string? VehicleType { get; set; }
        public string? Location { get; set; }
        public DateTime? YearOfMake { get; set; }
        public int? IDVvalue { get; set; }
        public int UserID {  get; set; }

    }
}
