using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvcDay2.Models;
using mvcDay2.servervalidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using mvcDay2.servervalidation;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace mvcDay2.viewmodel
{
    public class employeevaild
    {
        public int Ssn { get; set; }
        [uniqname]
        public string fname { get; set; }
        public string lname { get; set; }
        public DateOnly Bdate { get; set; }
        
        [RegularExpression("^(male|female)$", ErrorMessage = "choose male or female ")]
        public string sex { get; set; }
        [Remote("check", "clientvalid", ErrorMessage = "salary shoud between 10000 and 15000")]
       // [Range(15000,20000)]
        public decimal salary { get; set; }
        [RegularExpression("^(cario|alex|giza)$",ErrorMessage = "choose cario|alex|giza ")]
        public string address { get; set; }
        [Compare("confirmpassword" ,ErrorMessage ="password not match")]
        public string password { get; set; }
        [Compare("password", ErrorMessage = "password not match")]
        public string confirmpassword { get; set; }
        public int? Dno { get; set; }
        
        public int? superid { get; set; }
        [ValidateNever]
        public SelectList departments { get; set; }
       // public SelectList gender {  get; set; }
    }
}
