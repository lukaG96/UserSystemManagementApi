using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementSystemAPI.DataLayer.DTOs.Request
{
    public class UserParametersDto
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        public string SortColumnName { get; set; } = "UserName"; // Comlumn Name
        public string SortTypeStr { get; set; } = "ASC"; // or DESC



        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
