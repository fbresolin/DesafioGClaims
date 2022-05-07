using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DesafioGClaims.Entities.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        [Display(Name = "Senha")]
        public string Password { get; set; }
        public List<Character> FavCharacters { get; set; }
    }
}
