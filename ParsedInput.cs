using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw1
{
    class ParsedInput
    {
        public String command { get; set; }
        public String parameters { get; set; }
        public const char charToSplit = ' ';


        public ParsedInput(String textToParse)
        {
            String[] parameters = textToParse.Split(charToSplit);
            this.command = parameters[0];
            this.command =  this.command.ToLower();
            if (this.command == "subject" || this.command == "to" || this.command == "body" || this.command == "send")
            {
                if (this.command == "send")
                {
                    return;
                }
                else if(this.command == "body" || this.command == "subject")
                {
                    if (parameters.Length == 1)
                    {
                        throw new Exception($"Command {this.command} requires 2 parameter");
                    }
                }
                else // to command
                {
                    if(parameters.Length != 2)
                    {
                        throw new Exception($"Command {this.command} requires 2 parameter emails must be splitted by ,\n For Example email1,email2,email3");
                    }
                    String[] Emails = parameters[1].Split(',');
                    for(int i = 0; i < Emails.Length; i++)
                    {
                        if (!IsValidEmail(Emails[i]))
                        {
                            throw new Exception($"Bad Email address '{Emails[i]}'");
                        }
                    }
                }
                this.parameters = textToParse.Substring(this.command.Length + 1);

            }
            else
            {
                throw new Exception($"Bad command '{command}'");
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
