using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationContacts.Infrastructure.Helpers
{
    public class PaginationHeader
    {
        public PaginationHeader(int currentPage, int totalPages, int pageSize, int totalItens)
        {
            CurrentPage = currentPage;
            TotalPages = totalPages;
            PageSize = pageSize;
            TotalItems = totalItens;
        }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }

    }
}
