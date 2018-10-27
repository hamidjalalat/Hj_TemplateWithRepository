using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public  class Role:BaseEntity
    {
        #region Configuration
        internal class Configuration:System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Role>
        {
            public Configuration() : base()
            {

            }
        }
        #endregion /Configuration
        public Role() : base()
        {

        }
        public string Name { get; set; }
        public virtual IList<User> Users { get; set; }
    }
}
