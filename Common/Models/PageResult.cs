using System;
using System.Collections.Generic;

namespace Common
{
    public class PageResult<T>
    {
        public PageResult(int rowsCount, int skip, int take)
        {
            if (rowsCount < 0)
            {
                throw new ArgumentException("value must be non-negative", nameof(rowsCount));
            }
            if (skip < 0)
            {
                throw new ArgumentException("value must be non-negative", nameof(skip));
            }
            if (take <= 0)
            {
                throw new ArgumentException("value must be greater than 0", nameof(take));
            }

            Count = rowsCount;
            Pages = (rowsCount + take - 1) / take;
            CurrentPage = skip >= rowsCount ? Pages : (skip / take) + 1;
            NextPage = Pages > CurrentPage ? CurrentPage + 1 : 0;
            PreviousPage = CurrentPage - 1;
        }

        public List<T> Data { get; set; } = new List<T>();
        public int Count { get; }
        public int Pages { get; }
        public int NextPage { get; }
        public int PreviousPage { get; }
        public int CurrentPage { get; }
    }
}