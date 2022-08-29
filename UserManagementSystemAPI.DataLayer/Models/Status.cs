using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementSystemAPI.DataLayer.Models
{
    public class Status
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
