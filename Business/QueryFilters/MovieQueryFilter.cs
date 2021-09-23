using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.QueryFilters
{
    public class MovieQueryFilter
    {
        public int? genre { get; set; }
        public string name { get; set; }
        public string  order { get; set; }
        public int pageSize { get; set; }
        public int pageNumber { get; set; }

    }
}
