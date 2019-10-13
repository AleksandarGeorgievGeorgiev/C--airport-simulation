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



namespace ProCP.Abstractions
{
    public abstract class TransportingNode : ChainNode, ITransportingNode, IStartStop
    {
        protected readonly int _length;
        protected IBaggage[] _conveyorBelt;

        public TransportingNode(int legth, string nodeId, Timer timer) : base(nodeId, timer)
        {
            _length = legth;
            timer = new Timer();
            _conveyorBelt = new IBaggage[_length];
            timer.Elapsed += (sender, args) => Move();
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
            if (NextNode.NodeStatus == Status.Free)
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
            TimerService.Interval = MovingSpeed;
            if (!TimerService.Enabled)
            {
                TimerService.Start();
            }
        }

        public void Stop()
        {
            if (TimerService.Enabled)
            {
                TimerService.Stop();
            }
        }
    }
}
