using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw1
{
    class ToCommand : ICommand
    {
        public String Name { get; set; }

        public ToCommand ()
        {
            this.Name = "To";
        }
        public string Execute(string parameters, State state)
        {
            state.ToParameter = parameters;
            return $"To updated to {state.ToParameter}";
        }
    }
}
