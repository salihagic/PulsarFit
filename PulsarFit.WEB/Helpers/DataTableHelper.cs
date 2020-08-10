using Microsoft.AspNetCore.Http;
using Pulsar.EntityFrameworkCore.BaseService;
using Pulsar.EntityFrameworkCore.Extensions;
using System.Collections.Generic;
using static Pulsar.EntityFrameworkCore.Extensions.PulsarEnumerations;

namespace PulsarFit.WEB.Helpers
{
    public static class DataTableHelper
    {
        public static PulsarPagination GetPagination(this IQueryCollection query)
        {
            int.TryParse(query["datatable[pagination][page]"].ToString(), out var page);
            if (page == 0)
            {
                int.TryParse(query["page"].ToString(), out page);
            }
            int.TryParse(query["datatable[pagination][perpage]"].ToString(), out var pageSize);
            var sortField = query["datatable[sort][field]"].ToString();
            if (string.IsNullOrEmpty(sortField))
            {
                sortField = query["sortField"].ToString();
            }
            var sortDirection = query["datatable[sort][sort]"].ToString();

            if (pageSize == 0)
                pageSize = 10;

            var pagination = new PulsarPagination
            {
                Page = page,
                Skip = (page - 1) * pageSize,
                Take = pageSize,
                ShouldTakeAllRecords = ((page - 1) * pageSize) < 0
            };

            if (!string.IsNullOrEmpty(sortField))
            {
                pagination.OrderFields = new List<OrderField>
                {
                    new OrderField
                    {
                        Field = sortField,
                        Direction = sortDirection.ToLower() == "desc" ? SortDirection.DESC : SortDirection.ASC
                    }
                };
            }

            return pagination;
        }
    }
}
