using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Web.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field Legal Name Required.")]
        public string LegalName { get; set; }

        [Required(ErrorMessage = "Field Legal Surname Required.")]
        public string LegalSurname { get; set; }


        [Required(ErrorMessage = "Field Print Name Required.")]
        public string PrintName { get; set; }

        [Required(ErrorMessage = "Field Social Security # Required.")]
        public int Ssn { get; set; }

        [Required(ErrorMessage = "Field Code Required.")]
        public int Gender { get; set; }

        public DateTime DateBirth { get; set; }

        [Required(ErrorMessage = "Field Code Required.")]
        public string MaritalStatus { get; set; }

        [Required(ErrorMessage = "Field Code Required.")]
        public int UsCitizen { get; set; }

        [Required(ErrorMessage = "Field Code Required.")]
        public string Ethnicity { get; set; }

        [Required(ErrorMessage = "Field Code Required.")]
        public bool Active { get; set; }

        [Required(ErrorMessage = "Field Code Required.")]
        public int Disability { get; set; }

        [Required(ErrorMessage = "Field Code Required.")]
        public string DisabilityDescription { get; set; }

        [Required(ErrorMessage = "Field Code Required.")]
        public int I9Form { get; set; }

        //[Required(ErrorMessage = "Field Code Required.")]
        public DateTime WorkExpires { get; set; }

        [Required(ErrorMessage = "Field Code Required.")]
        public int UsVeteran { get; set; }

        [Required(ErrorMessage = "Field Code Required.")]
        public string VeteranStatus { get; set; }

        [Required(ErrorMessage = "Field Address Required.")]
        public string Address1 { get; set; }

        [Required(ErrorMessage = "Field Address Required.")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Field Address Required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Field State/Province Required.")]
        public string StateProvince { get; set; }

        [Required(ErrorMessage = "Field PostalCode Required.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Field Phone Number Required.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Field Mobile Number Required.")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Field Email Required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contact Name Required.")]
        public string ContactName1 { get; set; }

        [Required(ErrorMessage = "Contact Phone Required.")]
        public string ContactPhone1 { get; set; }

        [Required(ErrorMessage = "Contact Relation Required.")]
        public string ContactRelation1 { get; set; }

        [Required(ErrorMessage = "Contact Name Required.")]
        public string ContactName2 { get; set; }

        [Required(ErrorMessage = "Contact Phone Required.")]
        public string ContactPhone2 { get; set; }

        [Required(ErrorMessage = "Contact Relation Required.")]
        public string ContactRelation2 { get; set; }


        public EmployeeTypePerson EmployeeType { get; set; }



    }
}