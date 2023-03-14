using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace IntroASP.Models.ViewModels
{
    public class ClientViewModel
    {
        [Required] //Permite hacer que el campo en el formulario sea obligatorio.
        [Display(Name = "Id")] //Permite cambiar el nombre del campo a manera de información extra.
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }
    }
}
