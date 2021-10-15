using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Persons.Identity.Users.UsersManager
{
    public class UserType
    {
        [Display(Name = "Código")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Tipo Usuário")]
        [Column("NameUserType")]
        [MaxLength(255)]
        public string NameUserType { get; set; }
    }
}
