using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ADT.Core.Mvc.ModelValidation.Remote.Models.Home
{
    public class EmployeeInputModel
    {
        [Required]
        [Remote(action: "ValidateEmployeeNo", controller: "Home")]
        public string EmployeeNo { get; set; }
    }
}
