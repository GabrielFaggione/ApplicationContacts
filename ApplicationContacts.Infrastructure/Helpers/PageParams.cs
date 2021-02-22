using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationContacts.Infrastructure.Helpers
{
    public class PageParams
    {

        public const int MaxPageSize = 50;
        public int pageNumber { get; set; } = 1;
        public string Filtro { get; set; }
        private int pageSize { get; set; } = 10;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

    }
}
