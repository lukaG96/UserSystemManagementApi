using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementSystemAPI.Shared.Exceptions
{
    public class DataFromDbNotFound : Exception
    {
        public DataFromDbNotFound(string message) : base(message) { }
    }
}
