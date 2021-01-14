using System.ComponentModel.DataAnnotations;

namespace LunchAndLearnAzureFunctionApp.Models
{
    public class AppSettings : IValidatable
    {
        [Required]
        public string SelectedLeague { get; set; }

        public void Validate()
        {
            Validator.ValidateObject(this, new ValidationContext(this), validateAllProperties: true);
        }
    }
}
