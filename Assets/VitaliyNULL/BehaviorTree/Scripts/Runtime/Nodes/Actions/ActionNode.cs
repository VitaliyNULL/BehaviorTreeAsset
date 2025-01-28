using VitaliyNULL.Runtime.Core;

namespace VitaliyNULL.Runtime.Nodes.Actions
{
    public abstract class ActionNode: BehaviorTreeNode
    {
        protected ActionNode(BehaviorTree behaviorTree) : base(behaviorTree)
        {
        }

    }
}