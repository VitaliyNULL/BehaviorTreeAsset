using UnityEngine;
using VitaliyNULL.Runtime.Core;
using VitaliyNULL.Runtime.Nodes;
using VitaliyNULL.Runtime.Nodes.Conditions;
using VitaliyNULL.Test.Enemy.Interfaces;

namespace VitaliyNULL.Test.Enemy.Node
{
    public class CheckForTargetNode: ConditionNode
    {
        public CheckForTargetNode(BehaviorTree behaviorTree) : base(behaviorTree)
        {
        }

        protected override NodeState TickNode()
        {
            if (!BehaviorTree.TryGetData(out IFollowData followData)) return NodeState.Failed;
            Debug.Log(followData.Target);
            return followData.Target != null ? NodeState.Success : NodeState.Failed;
        }
    }
}