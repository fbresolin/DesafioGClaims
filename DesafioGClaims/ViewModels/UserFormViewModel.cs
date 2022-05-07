using DesafioGClaims.Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace DesafioGClaims.ViewModels
{
    public class UserFormViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Message { get; set; }
    }
}
