using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw1
{
    class SendCommand : ICommand
    {
        public String Name { get; set; }

        public SendCommand()
        {
            this.Name = "Send";
        }
        public string Execute(string parameters, State state)
        {
            //check if there is something missing
            if (String.IsNullOrEmpty(state.ToParameter) || String.IsNullOrEmpty(state.SubjectParameter) || String.IsNullOrEmpty(state.BodyParameter))
            {
                throw new Exception("Some or more from the to,subject,body parameters is missing, therefore cant send the message");
            }
            EmailClient ec = new hw1.EmailClient("atiawaleed3@gmail.com", "qweasd123456789");
            String [] Emails = state.ToParameter.Split(',');
            //iterate through emails and send email to each to recipent 
            for(int i=0;i<Emails.Length;i++)
            { 

                ec.Send(Emails[i], state.SubjectParameter, state.BodyParameter);
            }
            
            return $"Email '{state.SubjectParameter}' sent to {state.ToParameter}";
        }
    }
}
