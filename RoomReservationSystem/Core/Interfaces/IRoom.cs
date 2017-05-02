using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRoom
    {
        char Building { get; set; }
        int Floor { get; set; }
        string ID { get; }
        int MaxPeople { get; set; }
        Permission MinPermissionLevel { get; set; }
        int Nr { get; set; }


    }
}
