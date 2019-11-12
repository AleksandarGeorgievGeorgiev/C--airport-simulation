﻿using ProCP.Abstractions;
using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using ProCP.Services;
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
        public ConveyorOneToOne(int legth, string nodeId, ITimerTracker timer, IConveyorSettings conveyorSettings) : base(legth, nodeId, timer, conveyorSettings)
        {
        }

        

        public override void Move()
        {
            TimerService.Stop();

            if (CanMove())
            {
                if (LastBaggage != null)
                {
                    System.Diagnostics.Debug.WriteLine("conveyor " + NextNode);
                    NextNode.PassBaggage(LastBaggage);
                    System.Diagnostics.Debug.WriteLine(LastBaggage.Destination);
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
            System.Diagnostics.Debug.WriteLine("conveyor" + b.Destination);
            NodeNodeStatus = NodeStatus.Busy;
            b.TransporterId = NodeId;
            Add(b);
        }
    }
}
