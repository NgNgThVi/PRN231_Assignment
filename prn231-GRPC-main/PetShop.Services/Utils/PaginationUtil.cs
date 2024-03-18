using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services.Utils
{
    public static class PaginationUtil
    {
        public static IQueryable<TEntity> Paging<TEntity>(this IQueryable<TEntity> query, int page, int pageSize)
        {
            if(page <= 0)
            {
                return query;
            }
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
