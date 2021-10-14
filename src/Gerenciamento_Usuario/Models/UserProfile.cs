using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gerenciamento_Usuario.Models
{
    public class UserProfile
    {
        [DisplayName("Código")]
        public int Id { get; set; }

        [DisplayName("Tipo de Usuário")]
        [ForeignKey("UserType")]
        [Column(Order = 1)]
        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }

        [DisplayName("Usuário")]
        [ForeignKey("Identity")]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }

    }
}
