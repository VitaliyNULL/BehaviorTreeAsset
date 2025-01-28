using VitaliyNULL.Runtime.Core;

namespace VitaliyNULL.Runtime.Nodes.Conditions
{
    public abstract class ConditionNode : BehaviorTreeNode
    {
        protected ConditionNode(BehaviorTree behaviorTree) : base(behaviorTree)
        {
        }
    }
}