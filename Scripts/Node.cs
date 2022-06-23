using System.Collections.Generic;

namespace TOMICZ.TreeAI
{
    public enum NodeState { Running, Success, Failure}

    public class Node
    {
        public Node parent;
        public List<Node> children = new List<Node>();

        protected NodeState _nodeState;

        private Dictionary<string, object> _dataContext = new Dictionary<string, object>();

        public Node()
        {
            parent = null;
        }

        public Node(List<Node> children)
        {
            foreach(var child in children)
            {
                Attach(child);
            }
        }

        public void Attach(Node node)
        {
            parent = this;
            children.Add(node);
        }

        public virtual NodeState Evaluate() => NodeState.Failure;

        public void SetData(string key, object value) => _dataContext.Add(key, value);

        public object GetData(string key)
        {
            object value = null;

            if(_dataContext.TryGetValue(key, out value))
            {
                return value;
            }

            Node node = parent;

            while(node != null)
            {
                value = node.GetData(key);
                if(value != null)
                {
                    return value;
                }

                return node.parent;
            }

            return null;
        }

        public bool ClearData(string key)
        {
            if (_dataContext.ContainsKey(key))
            {
                _dataContext.Remove(key);
                return true;
            }

            Node node = parent;

            while (node != null)
            {
                bool cleared = node.ClearData(key);

                if (cleared)
                {
                    return true;
                }

                node = node.parent;
            }

            return false;
        }
    }
}