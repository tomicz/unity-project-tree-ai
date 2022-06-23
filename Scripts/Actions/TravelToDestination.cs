using TOMICZ.Debugger;
using UnityEngine;

namespace TOMICZ.TreeAI.Actions
{
    public class TravelToDestination : Node
    {
        private Transform _transform;
        private float _speed = 0;
        private Vector3 _destination;

        public TravelToDestination (Transform transform, float speed, Vector3 destination)
        {
            _transform = transform;
            _speed = speed;
            _destination = destination;
        }

        public override NodeState Evaluate()
        {
            RuntimeConsole.PrintMessage(MessageType.Loop, "Current node running: TravelToDestination");
            if (IsStoppingDistanceGreaterThan(1))
            {
                Travel();
                _nodeState = NodeState.Running;
            }
            else
            {
                _nodeState = NodeState.Success;
            }

            return _nodeState;
        }

        private void Travel() => _transform.position += (_transform.position + _destination).normalized * _speed * Time.deltaTime;

        private bool IsStoppingDistanceGreaterThan(float stoppingDistance)
        {
            float distance = Vector3.Distance(_transform.position, _destination);

            if(distance > stoppingDistance)
            {
                return true;
            }
            return false;
        }
    }
}