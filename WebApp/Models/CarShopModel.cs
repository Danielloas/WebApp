namespace WebApp.Models
{
    public class CarShopModel
    {
        public int Id { get; set; }
        public string NameCar { get; set; }
        public string TypeCar { get; set; }
        public DateTime DateCreate { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
    }
}
