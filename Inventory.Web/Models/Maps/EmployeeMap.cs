
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Inventory.Web.Models
{
    public class EmployeeMap : EntityTypeConfiguration<EmployeeModel>
    {
        public EmployeeMap()
        {
            ToTable("employee");

            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.LegalName).HasColumnName("legal_name").HasMaxLength(50).IsRequired();
            Property(x => x.LegalSurname).HasColumnName("legal_surname").HasMaxLength(50).IsRequired();
            Property(x => x.PrintName).HasColumnName("print_name").HasMaxLength(50).IsRequired();
            Property(x => x.Ssn).HasColumnName("ssn").IsRequired();
            Property(x => x.Gender).HasColumnName("gender").IsRequired();
            Property(x => x.DateBirth).HasColumnName("date_birth").IsOptional();
            Property(x => x.MaritalStatus).HasColumnName("marital_status").HasMaxLength(50).IsRequired();
            Property(x => x.UsCitizen).HasColumnName("us_citizen").IsRequired();
            Property(x => x.Ethnicity).HasColumnName("ethnicity").HasMaxLength(50).IsRequired();
            Property(x => x.Active).HasColumnName("active").IsRequired();

            Property(x => x.Disability).HasColumnName("disability").IsRequired();
            Property(x => x.DisabilityDescription).HasColumnName("disability_description").HasMaxLength(50).IsRequired();
            Property(x => x.I9Form).HasColumnName("i9_form").IsRequired();
            Property(x => x.WorkExpires).HasColumnName("work_expires").IsOptional();
            Property(x => x.UsVeteran).HasColumnName("us_veteran").IsRequired();
            Property(x => x.VeteranStatus).HasColumnName("veteran_status").HasMaxLength(50).IsRequired();



            Property(x => x.Address1).HasColumnName("address_1").HasMaxLength(50).IsRequired();
            Property(x => x.Address2).HasColumnName("address_2").HasMaxLength(50).IsOptional();
            Property(x => x.City).HasColumnName("e_city").HasMaxLength(50).IsRequired();
            Property(x => x.StateProvince).HasColumnName("e_state_province").HasMaxLength(50).IsRequired();
            Property(x => x.PostalCode).HasColumnName("e_postal_code").HasMaxLength(10).IsRequired();
            Property(x => x.PhoneNumber).HasColumnName("e_phone_number").HasMaxLength(10).IsRequired();
            Property(x => x.MobileNumber).HasColumnName("e_mobile_number").HasMaxLength(10);
            Property(x => x.Email).HasColumnName("e_email").HasMaxLength(50).IsRequired();
            Property(x => x.ContactName1).HasColumnName("e_contact_name1").HasMaxLength(10).IsOptional();
            Property(x => x.ContactPhone1).HasColumnName("e_contact_phone1").HasMaxLength(10).IsOptional();
            Property(x => x.ContactRelation1).HasColumnName("e_contact_relation1").HasMaxLength(10).IsOptional();
            Property(x => x.ContactName2).HasColumnName("e_contact_name2").HasMaxLength(10).IsOptional();
            Property(x => x.ContactPhone2).HasColumnName("e_contact_phone2").HasMaxLength(10).IsOptional();
            Property(x => x.ContactRelation2).HasColumnName("e_contact_relation2").HasMaxLength(10).IsOptional();

            Property(x => x.EmployeeType).HasColumnName("type");







        }
    }
}
