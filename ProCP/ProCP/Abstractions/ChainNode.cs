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
        private NodeStatus _NodeStatus;
        public string NodeId { get; set; }
        public Action OnNodeStatusChangedToFree { get; set; }
        public Timer TimerService { get; set; }
        public virtual NodeStatus NodeNodeStatus
        {
            get
            {
                return _NodeStatus;
            }
            set
            {
                _NodeStatus = value;
                if (value == NodeStatus.Free)
                {
                    OnNodeStatusChangedToFree?.Invoke();
                }
            }
        }
        public IChainNode NextNode { get; set; }
        public abstract string Destination { get; }

        public ChainNode(string nodeId, Timer timer)
        {
            TimerService = timer;
            _NodeStatus = NodeStatus.Free;
            NodeId = nodeId;
        }
        public abstract void PassBaggage(IBaggage b);
    }
}
