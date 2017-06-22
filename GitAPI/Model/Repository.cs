using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Repository
    {
        public string full_name { get; set; }
        public string description { get; set; }
        public string forks { get; set; }
        public string stargazers_count { get; set; }
        public Owner owner { get; set; }
    }
}
