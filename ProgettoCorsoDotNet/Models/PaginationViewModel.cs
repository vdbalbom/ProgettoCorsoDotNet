using ProgettoCorsoDotNet.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgettoCorsoDotNet.Models
{
    public class PaginationViewModel
    {
        public List<int> PaginationList;
        public int ActualPage { get; }
        public int? NextPage { get; }
        public int? PreviousPage { get; }
        public int PerPage { get; }

        public PaginationViewModel(int actualPage, int perPage, int count)
        {
            ActualPage = actualPage;
            PerPage = perPage;
            int maxPage = (count / perPage) + (count % perPage == 0 ? 0 : 1) - 1;
            NextPage = actualPage == maxPage ? null : actualPage + 1;
            PreviousPage = actualPage == 0 ? null : actualPage - 1;
            PaginationList = PaginationHelper.GetPaginationList(actualPage, maxPage);
        }
    }
}
