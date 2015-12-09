using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Production.Models
{
    public class Account : IlogItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Culture { get; set; }
        public string TimeZone { get; set; }
        public string Phone { get; set; }
        public string email { get; set; }
        public DateTime? Created { get; set; }
		public Guid? CreatedBy { get; set; }
		public DateTime? Changed { get; set; }
		public Guid? ChangedBy { get; set; }
		
    }
}