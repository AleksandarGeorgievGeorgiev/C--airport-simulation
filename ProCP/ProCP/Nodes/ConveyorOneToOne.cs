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

        public override string Destination { get; }

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

                NextNode.OnNodeStatusChangedToFree -= Move;
                NodeNodeStatus = NodeStatus.Free;
                TimerService.Start();
            }
            else
            {
                NextNode.OnNodeStatusChangedToFree += Move;
            }
        }

        public override void PassBaggage(IBaggage b)
        {
            NodeNodeStatus = NodeStatus.Busy;
            b.TransporterId = NodeId;
            Add(b);
        }
    }
}
