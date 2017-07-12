using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PullRequest
    {
        public string title { get; set; }
        public string updated_at { get; set; }
        public string body { get; set; }
        public User user { get; set; }
        public string html_url { get; set; }
    }
}
