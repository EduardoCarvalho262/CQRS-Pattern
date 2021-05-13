using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDomain.Domain
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o Name")]
        [MinLength(3, ErrorMessage = "O name deve ter um tamanho mínimo de 3 caracteres.")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o Phone")]
        [MinLength(3, ErrorMessage = "O phone deve ter um tamanho mínimo de 3 caracteres.")]
        public string Phone { get; set; }

        public Customer()
        {

        }

        public Customer(string name, string phone)
        {
            this.Name = name;
            this.Phone = phone;
        }

    }
}
