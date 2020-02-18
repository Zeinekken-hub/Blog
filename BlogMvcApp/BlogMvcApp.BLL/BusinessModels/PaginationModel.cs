using System;

namespace BlogMvcApp.BLL.BusinessModels
{
    public class PaginationModel
    {
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int PagerLength { get; set; }

        /// <summary>
        /// Create pagination model
        /// </summary>
        /// <param name="totalItems">[Constant] Total count of items, that will be use in pagination</param>
        /// <param name="page">Number of page with which pagination will be create</param>
        /// <param name="pageSize">[Constant] How many items can be placed on the page</param>
        /// <param name="pagerLength">[Constant] Length of pagination pages for example [1]...[3][4][5]...[7]
        /// length equals 7</param>
        /// <returns>PaginationModel it's help to work with pagination in view</returns>
        public PaginationModel(int totalItems, int? page, int pageSize, int pagerLength)
        {
            var currentPage = page ?? 1;
            var totalPages = GetTotalPages(totalItems, pageSize);
            pagerLength = GetValidatePagerLength(pagerLength, totalItems);
            var startPage = GetStartPage(currentPage, pagerLength);
            var endPage = GetEndPage(currentPage, pagerLength);

            if (startPage <= 0)
            {
                startPage = 1;
                endPage = pagerLength;
            }

            if (endPage >= totalPages)
            {
                endPage = totalPages;
                startPage = totalPages - pagerLength + 1;
            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
            PagerLength = pagerLength;
        }

        private static int GetTotalPages(int totalItems, int pageSize)
        {
            if (pageSize <= 0) pageSize = 1;

            return (int)Math.Ceiling(totalItems / (decimal)pageSize);
        }

        private static int GetEndPage(int currentPage, int pagerLength)
        {
            if (pagerLength % 2 == 0)
            {
                return currentPage + pagerLength / 2;
            }

            return currentPage + (int)Math.Ceiling((decimal)pagerLength / 2) - 1;
        }

        private static int GetStartPage(int currentPage, int pagerLength)
        {
            if (pagerLength % 2 == 0)
            {
                return currentPage - pagerLength / 2 + 1;
            }

            return currentPage - (int)Math.Floor((decimal)pagerLength / 2);
        }

        private static int GetValidatePagerLength(int pagerLength, int totalItems)
        {
            if (pagerLength <= 0) pagerLength = 1;

            ++pagerLength;

            if (pagerLength >= totalItems) pagerLength = totalItems - 1;

            return pagerLength;
        }
    }
}
