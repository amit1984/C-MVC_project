using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Production.enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Production.ViewModels.customer
{
    public class createCustomer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int custID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Culture { get; set; }
        public string TimeZone { get; set; }
        public string Phone { get; set; }
        public string email { get; set; }
        public Channel? Channel { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? Created { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? Changed { get; set; }
        public Guid? ChangedBy { get; set; }
        public IEnumerable<SelectListItem> Genders { get; set; }
        public IEnumerable<SelectListItem> Channels { get; set; }
    }
}