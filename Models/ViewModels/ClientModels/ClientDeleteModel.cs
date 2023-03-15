using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace IntroASP.Models.ViewModels.ClientModels
{
    public class ClientDeleteModel
    {
        [Required] //Permite hacer que el campo en el formulario sea obligatorio.
        [Display(Name = "Cédula")] //Permite cambiar el nombre del campo a manera de información extra.
        public int Id { get; set; }
    }
}
