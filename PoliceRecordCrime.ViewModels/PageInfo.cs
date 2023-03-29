using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliceRecordCrime.ViewModels
{
    public class PageInfo
    {//Web sayfasinda verilerin sayfalandirilmasi islemi
        //public int PageNumber { get; set; }
        //public int PageSize { get; set; }
        public int TotalItems { get; set; }

        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalItems / CurrentPage);
        public bool HasPreviosPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
    }
}
