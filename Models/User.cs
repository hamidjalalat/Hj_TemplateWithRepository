using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Models
{
    public class User:BaseEntity
    {
        #region Configuration
        internal class Configuration:System.Data.Entity.ModelConfiguration.ComplexTypeConfiguration<User>
        {
            public Configuration() : base()
            {

            }
        }
        #endregion /Configuration
        public User() :base()
        {
        }


        // **********
        //[RegularExpression(pattern: "[a-zA-Z0-9]")]
        [Remote(action: "CheckUsername", controller: "Account", areaName: "")]
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
        [Display(ResourceType = typeof(Resources.Users), Name = Resources.Strings.UsersKeys.CreateDate)]
        public DateTime DataCreate { get; set; }
        // **********

        public virtual IList<Role> Roles { get; set; }
    }
}