using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Data.Identity
{
    [Table("Managers", Schema = "data")]
    public class Ticket
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CarType { get; set; }
        public string CarModel { get; set; }
    }
}