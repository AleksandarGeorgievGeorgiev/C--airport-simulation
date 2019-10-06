using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProCP.Contracts;
using ProCP.FlightAndBaggage;


namespace ProCP.Abstractions
{
    public abstract class ChainNode : IChainNode
    {
        private Status _status;
        public int NodeId { get; set; }
        public Action OnStatusChangedToFree { get; set; }
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
        public ChainNode NextNode { get; set; }
        public ChainNode()
        {

        }
        public abstract void PassBaggage(Baggage b);
    }
}
