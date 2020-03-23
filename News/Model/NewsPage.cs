using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Model
{
    public class NewsPage
    {
        public IList<News> Newses { get; set; }
        public int AddCount { get; set; }

    }
}
