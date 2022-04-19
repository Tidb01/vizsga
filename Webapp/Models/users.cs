using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZAZ.Models
{
    public class users
    {
        public int ID  { get; set; }
        public string username { get; set; }
        public int score { get; set; }
        public bool ban { get; set; }

        public users()
        {

        }
    }
}
