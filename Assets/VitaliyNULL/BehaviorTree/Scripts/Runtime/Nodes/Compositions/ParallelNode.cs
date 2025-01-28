using VitaliyNULL.Runtime.Core;

namespace VitaliyNULL.Runtime.Nodes.Compositions
{
    public class ParallelNode : CompositionNode
    {
        #region Private Fields

        private int _successCount;

        #endregion

        #region Constructor

        public ParallelNode(BehaviorTree behaviorTree) : base(behaviorTree)
        {
        }

        #endregion


        #region Override methods

        protected override NodeState TickNode()
        {
            foreach (var behaviorTreeNode in Children)
            {
                switch (behaviorTreeNode.Tick())
                {
                    case NodeState.Success:
                        _successCount++;
                        continue;
                    case NodeState.Running:
                        continue;
                    case NodeState.Failed:
                        continue;
                    default:
                        break;
                }
            }

            return CheckForParallelState();
        }

        #endregion

        #region Private Methods

        private NodeState CheckForParallelState()
        {
            NodeState nodeState = NodeState.Failed;
            if (_successCount == Children.Count)
            {
                nodeState = NodeState.Success;
            }

            _successCount = 0;

            if (nodeState == NodeState.Success)
            {
                OnSuccess();
            }
            else
            {
                OnFailed();
            }

            return nodeState;
        }

        #endregion
    }
}