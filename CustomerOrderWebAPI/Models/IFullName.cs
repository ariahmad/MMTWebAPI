using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderWebAPI.Models
{
    public interface IFullName
    {
        string firstName { get; set; }
        string lastName { get; set; }
    }
}
