namespace Exams.Core.DTOs
{
    public class PagingViewModel
    {
        public int ModelsCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }

        public PagingViewModel()
        {

        }
        public PagingViewModel(int modelsCount, int page, int pageSize = 10)
        {
            int totalPages = (int)Math.Ceiling((decimal)modelsCount / (decimal)pageSize);
            int currentPage = page;
            int startPage = currentPage - 5;
            int endPage = currentPage + 4;
            if (startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }
            TotalPages = totalPages;
            CurrentPage = currentPage;
            StartPage = startPage;
            EndPage = endPage;
            PageSize = pageSize;
            ModelsCount = modelsCount;
        }
    }
}
