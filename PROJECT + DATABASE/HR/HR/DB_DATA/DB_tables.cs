using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DB_DATA
{
    class DB_tables : DbContext
    {
        public DB_tables() : base("name=DBconnect")
        {

        }

        public virtual DbSet<USER> USERs { get; set; }
        public virtual DbSet<SOFTWARE_SKILL> SOFTWARE_SKILLs { get; set; }
        public virtual DbSet<LANGUAGE> LANGUAGEs { get; set; }
        public virtual DbSet<SALARY> SALARIEs { get; set; }
        public virtual DbSet<ATTENDANCE> ATTENDANCEs { get; set; }
    }

    public class USER
    {
        [Key]
        public int ID { get; set; }
        public string FIRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string JOB_TITLE { get; set; }
        public byte[] IMAGE { get; set; }
        public string EMAIL { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string DESCRIPTION { get; set; }
        public string CONTACT_PHONE { get; set; }
        public string CONTACT_EMAIL { get; set; }
        public string CONTACT_ADDRESS { get; set; }
        public string SOCIAL_FACEBOOK { get; set; }
        public string SOCIAL_TWITTER { get; set; }
        public string SOCIAL_LINKEDIN { get; set; }
        public string ROLE { get; set; }
        public string SECURITY_QUESTION { get; set; }
        public string SECURITY_ANSWER { get; set; }
        public string EXPERIENCE { get; set; }
        public string EDUCATION { get; set; }
        public string LANGUAGE { get; set; }
        public virtual ICollection<SOFTWARE_SKILL> SOFTWARE_SKILLs { get; set; }
        public virtual ICollection<LANGUAGE> LANGUAGEs { get; set; }
        public virtual ICollection<INTEREST> INTERESTs { get; set; }
    }
    
    public class SOFTWARE_SKILL
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("USER")]
        public int USER_NAME { get; set; }
        public virtual USER USER { get; set; }
        public string TITLE { get; set; }
        public int RATING { get; set; }

    }

    public class LANGUAGE
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("USER")]
        public int USER_NAME { get; set; }
        public virtual USER USER { get; set; }
        public string TITLE { get; set; }
        public int RATING { get; set; }
    }

    public class INTEREST
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("USER")]
        public int USER_NAME { get; set; }
        public virtual USER USER { get; set; }
        public string USER_INTEREST { get; set; }
    }

    public class SALARY
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("USER")]
        public int USER_NAME { get; set; }
        public virtual USER USER { get; set; }
        public DateTime FROM_DATE { get; set; }
        public DateTime TO_DATE { get; set; }
        public double USER_SALARY { get; set; }
    }

    public class ATTENDANCE
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("USER")]
        public int USER_NAME { get; set; }
        public virtual USER USER { get; set; }
        public DateTime DATETIME_NOW { get; set; }

    }
}
