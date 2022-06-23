using System.Collections.Generic;
using TOMICZ.Debugger;
using UnityEngine;

namespace TOMICZ.TreeAI.Actions
{
    public class Idle : Node
    {
        private float _idleTime = 2f;
        private float _timer = 0f;

        public Idle()
        {

        }

        public Idle(List<Node> children) : base(children)
        {
            
        }

        public override NodeState Evaluate()
        {
            //RuntimeConsole.PrintMessage(MessageType.Loop, "Current node running: Idle");
            if (_timer < _idleTime)
            {
                _timer += Time.deltaTime;
                RuntimeConsole.PrintMessage(MessageType.Loop, "Timer: " + _timer);
                _nodeState = NodeState.Running;
            }
            else
            {
                _timer = 0;
                return NodeState.Success;
            }

            return _nodeState;
        }
    }
}