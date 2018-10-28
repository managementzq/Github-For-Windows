using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tianyue.EventHandler
{
    public interface IEventHandler<TEvent> where TEvent : Event.Event
    {
        void Handle(TEvent handle);
    }
}
