using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proje.MvcWebUI.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Adınız")]
        public string Name {  get; set; }

        [Required]
        [DisplayName("Soyadınız")]
        public string SurName { get; set; }

        [Required]
        [DisplayName("Kullanıcı Adınız")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Eposta Adresiniz")]
        [EmailAddress(ErrorMessage ="Eposta adresinizi doğru giriniz")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Parolanız")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Parola Tekrar")]
        [Compare("Password",ErrorMessage ="Parolalar Uyuşmuyor.")]
        public string RePassword { get; set; }

    }
}