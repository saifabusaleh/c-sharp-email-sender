using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw1
{
    class SubjectCommand : ICommand
    {
        public String Name { get; set; }

        public SubjectCommand()
        {
            this.Name = "Subject";
        }
        public string Execute(string parameters, State state)
        {
            state.SubjectParameter = parameters;
            return $"Subject updated to '{state.SubjectParameter}'";
        }
    }
}
