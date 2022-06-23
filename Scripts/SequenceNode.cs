using System.Collections.Generic;

namespace TOMICZ.TreeAI
{
    public class SequenceNode : Node
    {
        public SequenceNode() : base() { }
        public SequenceNode(List<Node> children) : base(children) { }

        public override NodeState Evaluate()
        {
            bool anyChildRunning = false;

            foreach(Node node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.Failure:
                        _nodeState = NodeState.Failure;
                        return _nodeState;
                    case NodeState.Success:
                        continue;
                    case NodeState.Running:
                        anyChildRunning = true;
                        continue;
                    default:
                        _nodeState = NodeState.Success;
                        return _nodeState;
                }
            }

            _nodeState = anyChildRunning ? NodeState.Running : NodeState.Success;

            return _nodeState;
        }
    }
}