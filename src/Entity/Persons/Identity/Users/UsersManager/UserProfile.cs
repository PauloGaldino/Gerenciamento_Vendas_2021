using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Persons.Identity.Users.UsersManager
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
        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
