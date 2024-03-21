using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BackEndApi.Models
{
    public class UserModel
    {
        [Key]
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public string? EmailID { get; set; }
        public long PhoneNo { get; set; }
        public long BankAccNo { get; set; }
        public long AadharNo { get; set; }
        public string? Password { get; set; }
    }
}
