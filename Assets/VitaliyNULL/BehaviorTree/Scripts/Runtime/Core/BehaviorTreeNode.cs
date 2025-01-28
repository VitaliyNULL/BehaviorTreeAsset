using System.Collections.Generic;
using VitaliyNULL.Runtime.Nodes;

namespace VitaliyNULL.Runtime.Core
{
    public abstract class BehaviorTreeNode
    {
        #region Public fields

        public BehaviorTreeNode ParentNode { get; set; }
        public NodeState State { get; set; }

        #endregion

        #region Protected fields

        protected BehaviorTree BehaviorTree { get; set; }
        protected List<BehaviorTreeNode> Children { get; set; } = new List<BehaviorTreeNode>();

        #endregion

        #region Constructor

        protected BehaviorTreeNode(BehaviorTree behaviorTree)
        {
            ParentNode = null;
            BehaviorTree = behaviorTree;
        }

        #endregion

        #region Public methods

        public void AttachNode(BehaviorTreeNode behaviorTreeNode)
        {
            Children.Add(behaviorTreeNode);
            behaviorTreeNode.ParentNode = this;
        }

        public void AttackChildren(List<BehaviorTreeNode> behaviorTreeNodes)
        {
            foreach (var behaviorTreeNode in behaviorTreeNodes)
            {
                behaviorTreeNode.ParentNode = this;
                Children.Add(behaviorTreeNode);
            }
        }

        public void ClearNodes()
        {
            Children.Clear();
        }

        #endregion

        #region Abstract methods

        public NodeState Tick()
        {
            State = TickNode();
            return State;
        }

        protected abstract NodeState TickNode();

        public virtual void OnFailed()
        {
            ResetNode();
        }

        public virtual void OnSuccess()
        {
            ResetNode();
        }

        public virtual void ResetNode()
        {
        }

        #endregion
    }
}