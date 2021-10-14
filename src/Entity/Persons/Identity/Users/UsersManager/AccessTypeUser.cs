using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Persons.Identity.Users.UsersManager
{
    public class AccessTypeUser
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [MaxLength(150)]
        public string FunctionalityName { get; set; }



        [Display(Name = "Tipo de Usuário")]
        [ForeignKey("UserType")]
        [Column(Order = 1)]
        public int UserTypeId { get; set; }

        public virtual UserType UserType { get; set; }
    }
}
