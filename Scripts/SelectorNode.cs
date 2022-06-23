using System.Collections.Generic;

namespace TOMICZ.TreeAI
{
    public class SelectorNode : Node
    {
        public SelectorNode() : base() { }
        public SelectorNode(List<Node> children) : base(children) { }

        public override NodeState Evaluate()
        {
            foreach (Node node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.Failure:
                        continue;
                    case NodeState.Success:
                        _nodeState = NodeState.Success;
                        return _nodeState;
                    case NodeState.Running:
                        _nodeState = NodeState.Running;
                        return _nodeState;
                    default:
                        continue;
                }
            }

            _nodeState = NodeState.Failure;

            return _nodeState;
        }
}