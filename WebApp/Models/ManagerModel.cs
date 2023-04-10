namespace WebApp.Models
{
    public class ManagerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Deleted { get; set; }
        public decimal Salary { get; set; }
        public string FullName { get; set; }
    }
}
