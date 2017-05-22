using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw1
{
    class Repl
    {
        private readonly ICommand[] commands;
        public enum ICommandIndexes { SubjectIndex, ToIndex, BodyIndex, SendIndex }
        private State state = new hw1.State();
        public const int NUMBER_OF_COMMANDS = 4;
        public Repl()
        {
            //initalize commands array
            commands = new ICommand[NUMBER_OF_COMMANDS];
            commands[(int)ICommandIndexes.SubjectIndex] = new SubjectCommand();
            commands[(int)ICommandIndexes.ToIndex] = new ToCommand();
            commands[(int)ICommandIndexes.BodyIndex] = new BodyCommand();
            commands[(int)ICommandIndexes.SendIndex] = new SendCommand();
        }
        public void Start()
        {
            String command;
            Console.Write("Welcome to Email REPL\n-------------------- -\nUse the following commands to send emails:\nsubject < subject > -update the message subject\nbody < body > -update the message body\nto < email >[,< email >] * -update the message recipient list\nsend - send the email using the current subject, body and recipient list\nType 'exit' to exit \n");
            command = ReadLine();

            while (command != "exit")
            {
                //execute command after parse
                Execute(ParseCommand(command));
                command = ReadLine();
            }
        }
        private string ReadLine()
        {
            return Console.ReadLine();
        }
        private ParsedInput ParseCommand(string text)
        {
            ParsedInput parsedInput = new ParsedInput(text);
            return parsedInput;
        }
        private void Execute(ParsedInput parsedInput)
        {
            switch (parsedInput.command)
            {
                //run relevant execute depending on the the command
                case "subject":
                    Console.WriteLine($"Command output: { commands[(int)ICommandIndexes.SubjectIndex].Execute(parsedInput.parameters, state)}");
                    break;
                case "to":
                    Console.WriteLine($"Command output: {commands[(int)ICommandIndexes.ToIndex].Execute(parsedInput.parameters, state)}");
                    break;
                case "body":
                    Console.WriteLine($"Command output: {commands[(int)ICommandIndexes.BodyIndex].Execute(parsedInput.parameters, state)}");
                    break;
                case "send":
                    Console.WriteLine($"Command output: {commands[(int)ICommandIndexes.SendIndex].Execute(parsedInput.parameters, state)}");
                    break;
            }
        }
    }
}
