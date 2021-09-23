using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.QueryFilters
{
    public class CharactersQueryFilter
    {
        public int? movies { get; set; }
        public int? age { get; set; }
        public string name { get; set; }
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
    }
}
