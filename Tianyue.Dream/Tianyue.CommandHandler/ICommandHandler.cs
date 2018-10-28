using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tianyue.CommandHandler
{
    public interface ICommandHandler<TCommand> where TCommand : Command.Command
    {
        void Execute(TCommand command);
    }
}
