/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Extensions;

public static class PaginationExtensions
{
    public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source)
    {

        int pageSize = 50;
        int currentPage = 1;

        foreach (var item in source)
        {
            currentPage.Add(item);

            if (currentPage.Count == pageSize)
            {
                yield return currentPage.ToList();
                currentPage.Clear();
            }
        }

        if (currentPage.Any())
            yield return currentPage;
    }
}
*/