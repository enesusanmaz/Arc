using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYARCH.UTILITIES.SessionOperations
{
    public class SessionContext
    {
        public int Id { get; set; }
        public string UserName { get; set; } 
        public string FullName { get; set; }
        public string Job { get; set; }
        public string ImageUrl { get; set; }
        //public Object Makale { get; set; }
    }
}
