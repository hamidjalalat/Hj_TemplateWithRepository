using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ViewModels.Users
{
    public class EditViewModel
    {
        public EditViewModel() : base()
        {
        }
        // **********
        public Guid Id { get; set; }
        // **********

        // **********

        [Display(ResourceType = typeof(Resources.Users), Name = Resources.Strings.UsersKeys.Name)]
        [StringLength(maximumLength: 20, MinimumLength = 8, ErrorMessageResourceType = typeof(Resources.Users),
            ErrorMessageResourceName = Resources.Strings.UsersKeys.minimumlength)]
        public string Name { get; set; }
        // **********

        // **********
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources.Users), Name = Resources.Strings.UsersKeys.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources.Users)
            , ErrorMessageResourceName = Resources.Strings.UsersKeys.RequiredFieldValidator)]
        public string Password { get; set; }
        // **********

        // **********
        [Display(ResourceType = typeof(Resources.Users), Name = Resources.Strings.UsersKeys.ConfirmPassword)]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(Resources.Users)
            , ErrorMessageResourceName = Resources.Strings.UsersKeys.RequiredFieldValidator)]
        [System.ComponentModel.DataAnnotations.Compare(otherProperty: "Password",
            ErrorMessageResourceType = typeof(Resources.Users), ErrorMessageResourceName = Resources.Strings.UsersKeys.donotmatch)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        // **********

    }
}
