using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace WebApp.Data.Identity
{
    [Table("Managers", Schema = "data")]
    public class Car
    {
        public int Id { get; set; }
        public string NameCar { get; set; }
        public string TypeCar { get; set; }
        public DateTime DateCreate { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
    }
}