using System;
using System.Collections.Generic;
using Dapper;
using System.Data.Entity;
using System.Linq;

namespace Inventory.Web.Models
{
    public class EmployeeModel
    {
        #region Attribute
        public int Id { get; set; }
        public string LegalName { get; set; }
        public string LegalSurname { get; set; }

        public string PrintName { get; set; }

        public int Ssn { get; set; }

        public int Gender { get; set; }
        public DateTime DateBirth { get; set; }
        public string MaritalStatus { get; set; }
        public int UsCitizen { get; set; }
        public string Ethnicity { get; set; }
        public bool Active { get; set; }
        public int Disability { get; set; }
        public string DisabilityDescription { get; set; }
        public int I9Form { get; set; }
        public DateTime WorkExpires { get; set; }
        public int UsVeteran { get; set; }
        public string VeteranStatus { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string ContactName1 { get; set; }
        public string ContactPhone1 { get; set; }
        public string ContactRelation1 { get; set; }
        public string ContactName2 { get; set; }
        public string ContactPhone2 { get; set; }
        public string ContactRelation2 { get; set; }

        public EmployeeTypePerson EmployeeType { get; set; }



        #endregion

        #region Methods

        public static int RescueQuantity()
        {
            var ret = 0;

            using (var db = new ContextBD())
            {
                ret = db.Employees.Count();
            }
            return ret;
        }

        public static List<EmployeeModel> RescueList(int page, int lenPage, string filter = "", string order = "", bool onlyActives = false)
        {
            var ret = new List<EmployeeModel>();

            using (var db = new ContextBD())
            {

                var filterWhere = "";
                if (!string.IsNullOrEmpty(filter))
                {
                    filterWhere = string.Format(" where lower(legal_name) like '%{0}%'", filter.ToLower());
                }

                if (onlyActives)
                {
                    filterWhere = (string.IsNullOrEmpty(filterWhere) ? " where" : " and") + "(active = 1)";
                }

                var pos = (page - 1) * lenPage;
                var pagination = "";
                if (page > 0 && lenPage > 0)
                {
                    pagination = string.Format(" offset {0} rows fetch next {1} rows only",
                        pos > 0 ? pos - 1 : 0, lenPage);
                }


                var sql =
                      "select id, legal_name as LegalName, legal_surname as LegalSurname, print_name as PrintName, ssn as Ssn, " +
                      "gender, date_birth, marital_status as MarritalStatus, us_citizen as UsCitizen, ethnicity, active, disability, disability_description, " +
                      "i9_form, work_expires, us_veteran, veteran_status, address_1, address_2, e_city, e_state_province, " +
                      "e_postal_code, e_phone_number, e_mobile_number, e_email, e_contact_name1, e_contact_phone1, e_contact_relation1, " +
                      "e_contact_name2, e_contact_phone2, e_contact_relation2, type as Type " +
                      "from employee " +
                      filterWhere +
                      "order by " + (!string.IsNullOrEmpty(order) ? order : "legal_name") +
                      pagination;

                ret = db.Database.Connection.Query<EmployeeModel>(sql).ToList();

            }
            return ret;
        }


        public static EmployeeModel IdRescue(int id)
        {
            EmployeeModel ret = null;

            using (var db = new ContextBD())
            {
                ret = db.Employees.Find(id);
            }
            return ret;
        }

        public static bool IdDelete(int id)
        {
            var ret = false;

            if (IdRescue(id) != null)
            {

                using (var db = new ContextBD())
                {
                    var employee = new EmployeeModel { Id = id };
                    db.Employees.Attach(employee);
                    db.Entry(employee).State = EntityState.Deleted;
                    db.SaveChanges();
                    ret = true;
                }
            }
            return ret;
        }

        public int Savee()
        {
            var ret = 0;

            var model = IdRescue(this.Id);

            using (var db = new ContextBD())
            {

                if (model == null)
                {
                    db.Employees.Add(this);

                }
                else
                {
                    db.Employees.Attach(this);
                    db.Entry(this).State = EntityState.Modified;
                }
                db.SaveChanges();
                ret = this.Id;

            }
            return ret;
        }

        #endregion
    }
}
