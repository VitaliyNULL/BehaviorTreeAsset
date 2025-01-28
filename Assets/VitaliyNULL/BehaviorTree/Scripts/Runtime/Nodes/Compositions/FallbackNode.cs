using VitaliyNULL.Runtime.Core;

namespace VitaliyNULL.Runtime.Nodes.Compositions
{
    public class FallbackNode : CompositionNode
    {
        #region Constructor

        public FallbackNode(BehaviorTree behaviorTree) : base(behaviorTree)
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
                        continue;
                    case NodeState.Running:
                        return NodeState.Running;
                    case NodeState.Success:
                        OnSuccess();
                        return NodeState.Success;
                    default:
                        continue;
                }
            }

            OnFailed();
            return NodeState.Failed;
        }

        #endregion
    }
}