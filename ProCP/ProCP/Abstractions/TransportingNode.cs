using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ProCP.Contracts;
using ProCP.FlightAndBaggage;
using System.Diagnostics;
using CuttingEdge.Conditions;
using ProCP.Services;

namespace ProCP.Abstractions
{
    public abstract class TransportingNode : ChainNode, ITransportingNode, IStartStop
    {
        protected readonly int _length;
        protected IBaggage[] _conveyorBelt;
        protected Timer _timer;

        public TransportingNode(int legth, string nodeId, ITimerTracker timer) : base(nodeId, timer)
        {
            _length = legth;
            _timer = new Timer();
            _conveyorBelt = new IBaggage[_length];
            _timer.Elapsed += (sender, args) => Move();
        }

        protected int LastIndex => _length - 1;
        protected IBaggage LastBaggage => _conveyorBelt[LastIndex];
        protected bool HasLastItem => LastBaggage != null;
        public int Length { get; set; }
        public int MovingSpeed { get; set; }

        public void SetNextNode(IChainNode node)
        {
            NextNode = node;
        }
        public abstract void Move();

        public bool CanMove()
        {
            if (NextNode.NodeNodeStatus == NodeStatus.Free)
            {
                return true;
            }

            if (!HasLastItem)
            {
                return true;
            }

            return false;
        }

        public bool CanAdd(int index = 0)
        {
            return _conveyorBelt[index] == null;
        }

        public void Add(IBaggage bag, int index = 0)
        {
            Condition.Requires(CanAdd(), "conveyor").IsEqualTo(true, "Trying to add to a full conveyor");
            _conveyorBelt[index] = bag;
        }

        public void Start()
        {
            _timer.Interval = MovingSpeed;
            if (!_timer.Enabled)
            {
                TimerService.Start();
            }
        }

        public void Stop()
        {
            if (_timer.Enabled)
            {
                TimerService.Stop();
            }
        }
    }
}
