using ProCP.Abstractions;
using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ProCP.Nodes
{
    public class ConveyorOneToOne : TransportingNode, IConveyorOneToOne
    {
        public ConveyorOneToOne(int legth, string nodeId, Timer timer) : base(legth, nodeId, timer)
        {
        }

        public override string Destination { get; set; }

        public override void Move()
        {
            TimerService.Stop();

            if (CanMove())
            {
                if (LastBaggage != null)
                {
                    NextNode.PassBaggage(LastBaggage);
                    _conveyorBelt[LastIndex] = null;
                }

                for (int i = LastIndex; i > 0; i--)
                {
                    _conveyorBelt[i] = _conveyorBelt[i - 1];
                    _conveyorBelt[i - 1] = null;
                }

                NextNode.OnStatusChangedToFree -= Move;
                NodeStatus = Status.Free;
                TimerService.Start();
            }
            else
            {
                NextNode.OnStatusChangedToFree += Move;
            }
        }

        public override void PassBaggage(IBaggage b)
        {
            NodeStatus = Status.Busy;
            b.TransporterId = NodeId;
            Add(b);
        }
    }
}
