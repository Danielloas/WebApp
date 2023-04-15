using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace WebApp.Data.Identity
{
    [Table("Managers", Schema = "data")]
    public class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Deleted { get; set; }
        public decimal Salary { get; set; }
    }
}

