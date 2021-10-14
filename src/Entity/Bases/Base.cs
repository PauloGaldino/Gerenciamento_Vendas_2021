using Entity.Notifications;
using System.ComponentModel.DataAnnotations;

namespace Entity.Bases
{
    public class Base : Notifier
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }
    }
}
