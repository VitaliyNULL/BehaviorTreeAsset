using UnityEngine;
using VitaliyNULL.Runtime.Core;
using VitaliyNULL.Runtime.Nodes;
using VitaliyNULL.Runtime.Nodes.Actions;
using VitaliyNULL.Test.Enemy.Interfaces;

namespace VitaliyNULL.Test.Enemy.Node
{
    public class FollowTargetNode: ActionNode
    {
        private readonly float _speed;
        private readonly Transform _transform;
        public FollowTargetNode(BehaviorTree behaviorTree, Transform transform, float speed) : base(behaviorTree)
        {
            _transform = transform;
            _speed = speed;
        }

        protected override NodeState TickNode()
        {
            if (!BehaviorTree.TryGetData(out IFollowData followData)) return NodeState.Failed;
            var position = _transform.position;
            var direction = followData.Target.position - position;
            position += direction.normalized * (_speed * Time.deltaTime);
            _transform.position = position;
            return NodeState.Success;
        }
    }
}