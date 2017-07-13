using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Persistence
    {
        private static Persistence instance = new Persistence();
        public List<Repository> resultList { get; set; }
        public String language { get; set; }
        public int page { get; set; }
        public int position { get; set; }

        private Persistence()
        {
            this.language = "";
            this.page = 0;
            resultList = new List<Repository>();
            this.position = 0;
        }

        public static Persistence getInstance()
        {
            return instance;
        }

        
    }
}
