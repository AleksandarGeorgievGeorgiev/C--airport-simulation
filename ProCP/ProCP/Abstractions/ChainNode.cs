using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ProCP.Contracts;
using ProCP.FlightAndBaggage;


namespace ProCP.Abstractions
{
    public abstract class ChainNode : IChainNode
    {
        private Status _status;
        public string NodeId { get; set; }
        public Action OnStatusChangedToFree { get; set; }
        public Timer TimerService { get; set; }
        public virtual Status NodeStatus
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                if (value == Status.Free)
                {
                    OnStatusChangedToFree?.Invoke();
                }
            }
        }
        public IChainNode NextNode { get; set; }
        public abstract string Destination { get; set; }

        public ChainNode(string nodeId, Timer timer)
        {
            TimerService = timer;
            _status = Status.Free;
            NodeId = nodeId;
        }
        public abstract void PassBaggage(IBaggage b);
    }
}
