using System.ComponentModel.DataAnnotations;

namespace Inventory.Web.Models
{
    public class ProviderViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field Name Required.")]
        [MaxLength(60, ErrorMessage = "Name must be less than 60 characteres.")]
        public string Name { get; set; }

        [MaxLength(100, ErrorMessage = "Corporate Name must be less than 100 characteres.")]
        public string CorporateName { get; set; }

        [MaxLength(20, ErrorMessage = "Documente number must be less than 20 characteres.")]
        public string DocNum { get; set; }

        [Required]
        public TypePerson Type { get; set; }

        [Required(ErrorMessage = "Field Phone Number Required.")]
        [MaxLength(20, ErrorMessage = "Phone Number must be less than 20 characteres.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Field Contact Required.")]
        [MaxLength(60, ErrorMessage = "Contact must be less than 60 characteres.")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Field Address Required.")]

        [MaxLength(100, ErrorMessage = "Address must be less than 100 characteres.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Field Number Required.")]

        [MaxLength(20, ErrorMessage = "Number must be less than 20 characteres.")]
        public string Number { get; set; }

        [MaxLength(100, ErrorMessage = "Instruction must be less than 100 characteres.")]
        public string Instruction { get; set; }

        [MaxLength(10, ErrorMessage = "Postal Code must be less than 10 characteres.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Select Country.")]
        [Range(1, int.MaxValue, ErrorMessage = "Select Country.")]
        public int IdCountry { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select Province.")]
        [Required(ErrorMessage = "Select Province.")]
        public int IdProvince { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select City.")]
        [Required(ErrorMessage = "Select City.")]
        public int IdCity { get; set; }


        public bool Active { get; set; }
    }
}