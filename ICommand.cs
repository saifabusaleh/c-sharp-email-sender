using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw1
{
    interface ICommand
    {
        String Name { get; set; }
        string Execute(string parameters, State state);
    }
}
