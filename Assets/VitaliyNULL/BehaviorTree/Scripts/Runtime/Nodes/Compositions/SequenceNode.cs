using VitaliyNULL.Runtime.Core;

namespace VitaliyNULL.Runtime.Nodes.Compositions
{
    public class SequenceNode : CompositionNode
    {
        #region Constructor

        public SequenceNode(BehaviorTree behaviorTree) : base(behaviorTree)
        {
        }

        #endregion


        #region Override methods

        protected override NodeState TickNode()
        {
            foreach (var node in Children)
            {
                switch (node.Tick())
                {
                    case NodeState.Failed:
                        OnFailed();
                        return NodeState.Failed;
                    case NodeState.Running:
                        return NodeState.Running;
                    case NodeState.Success:
                        continue;
                    default:
                        return NodeState.Success;
                }
            }

            OnSuccess();
            return NodeState.Success;
        }

        #endregion
    }
}