using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Proje.MvcWebUI.Models
{
    public class Login
    {
        [Required]
        [DisplayName("Kullanıcı Adınız")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Parolanız")]
        public string Password { get; set; }

        
        [DisplayName("Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}