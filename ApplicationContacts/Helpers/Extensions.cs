using ApplicationContacts.Infrastructure.Helpers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationContacts.API.Helpers
{
    public static class Extensions
    {

        public static void AddPagination(this HttpResponse response,
            int currentPage, int totalPages, int pageSize, int totalItens)
        {
            var paginationHeader = new PaginationHeader(currentPage, totalPages, pageSize, totalItens);
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();

            response.Headers.Add("Pagination", JsonConvert.SerializeObject(paginationHeader, camelCaseFormatter));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }

    }
}
