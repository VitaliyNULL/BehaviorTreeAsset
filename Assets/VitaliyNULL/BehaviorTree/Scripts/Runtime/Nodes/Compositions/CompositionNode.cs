using VitaliyNULL.Runtime.Core;

namespace VitaliyNULL.Runtime.Nodes.Compositions
{
    public abstract class CompositionNode : BehaviorTreeNode
    {
        protected CompositionNode(BehaviorTree behaviorTree) : base(behaviorTree)
        {
        }
        
        public override void ResetNode()
        {
            foreach (var child in Children)
            {
                child.ResetNode();
            }
        }
    }
}