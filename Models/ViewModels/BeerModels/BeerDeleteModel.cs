using System.ComponentModel.DataAnnotations;

namespace IntroASP.Models.ViewModels.BeerModels
{
    public class BeerDeleteModel
    {
        [Required]
        [Display(Name = "Marca")]
        public int BrandId { get; set; }
    }
}
