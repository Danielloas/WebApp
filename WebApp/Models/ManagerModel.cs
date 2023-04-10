namespace WebApp.Models
{
    public class ManagerModel
    {
        public int Id { get; set; }

        //TODO Validation Name
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Enter how you can be contacted.")]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Deleted { get; set; }

        //TODO Validation Salary
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Enter salary in whole numbers.")]
        public decimal Salary { get; set; }

        //TODO Validation FullName
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter your full name.")]
        public string FullName { get; set; }
    }
}
