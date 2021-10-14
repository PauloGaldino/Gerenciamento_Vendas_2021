using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Notifications
{
    public class Notifier
    {
        //=============Construtor da classe=============
        public Notifier()
        {
            Notifications = new List<Notifier>();
        }

        //===============Propriedades==================

        [NotMapped] //Esta coluna não existe no banco de dados para ser herdada
        public string PropertyName { get; set; }

        [NotMapped]
        public string Message { get; set; }

        [NotMapped]
        public List<Notifier> Notifications { get; set; }

        //=============Nétodos============================

        // método para validar a string
        public bool ValidateStringProperties(string value, string propertyMane)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(propertyMane))
            {
                Notifications.Add(new Notifier
                {
                    Message = " Este campo é obrigatório.",
                    PropertyName = propertyMane
                });

                return false;
            }
            return true;
        }

        // método para validar a propriedade inteiro
        public bool ValidateIntProperties(int value, string propertyMane)
        {
            if (value < 1 || string.IsNullOrWhiteSpace(propertyMane))
            {
                Notifications.Add(new Notifier
                {
                    Message = " O valor deste campo deve ser maior que 0.",
                    PropertyName = propertyMane
                });

                return false;
            }
            return true;
        }

        // método para validar a propriedade decimal
        public bool ValidateDecimaProperties(decimal value, string propertyMane)
        {
            if (value < 1 || string.IsNullOrWhiteSpace(propertyMane))
            {
                Notifications.Add(new Notifier
                {
                    Message = " O valor deste campo deve ser maior que 0.",
                    PropertyName = propertyMane
                });

                return false;
            }
            return true;
        }

    }
}
