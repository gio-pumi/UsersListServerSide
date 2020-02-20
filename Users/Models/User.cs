using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Users.Models
{
    public class User : IComparable<User>
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public DateTime birthdate { get; set; }
        public string gender { get; set; }

        //Comparison
        public int CompareTo(User other)
        {
            if (this.birthdate.Month > other.birthdate.Month)
                return 1;
            else if (this.birthdate.Month < other.birthdate.Month)
                return -1;
            else return 0;
        }
    }
}