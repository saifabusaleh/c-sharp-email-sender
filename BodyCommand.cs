using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw1
{
    class BodyCommand : ICommand
    {
        public String Name { get; set; }

        public BodyCommand()
        {
            this.Name = "Body";
        }
        public string Execute(string parameters, State state)
        {
            state.BodyParameter = parameters;
            if(state.BodyParameter.Length > 15)
            {
                return $"Body updated to '{state.BodyParameter.Substring(0,14)}...'";
            }
            return $"Body updated to '{parameters}'";
        }
    }
}
