using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tianyue.Command
{
    [Serializable]
    public class Command : ICommand
    {
        public Guid Id { get; private set; }

        public int Version { get; private set; }

        public Command(Guid id, int version)
        {
            Id = id;
            Version = version;
        }
    }
}
