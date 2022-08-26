using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace worxflow360.Global
{
    static class Common
    {
        static public PagedResultDto<T> GetPagedResult<T>(List<T> entity)
        {
            var results = new PagedResultDto<T>()
            {
                Items = entity,
                TotalCount = entity.Count
            };

            return results;
        }
    }
}
