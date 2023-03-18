using System.ComponentModel.DataAnnotations;

namespace Backend2.Models
{

    //Modal class - represents member in a system
    public class Member
    {
        //indicates id is the primary key for db table
        [Key]
        public int id { get; set; }

        public string mname { get; set; }

        public string role { get; set; }

        public string tstack { get; set; }

        public string blockers { get; set; }
    }

}

