using UnityEngine;
using VitaliyNULL.Runtime.Core;
using VitaliyNULL.Runtime.Nodes;
using VitaliyNULL.Runtime.Nodes.Actions;
using VitaliyNULL.Test.Enemy.Interfaces;

namespace VitaliyNULL.Test.Enemy.Node
{
    public class SeekTargetNode : ActionNode
    {
        private readonly Transform _transform;
        private readonly LayerMask _targetLayer;
        private readonly float _seekRadius;

        public SeekTargetNode(BehaviorTree behaviorTree, Transform transform, LayerMask targetTargetLayer,
            float seekRadius) : base(behaviorTree)
        {
            _transform = transform;
            _targetLayer = targetTargetLayer;
            _seekRadius = seekRadius;
        }

        protected override NodeState TickNode()
        {
            if (!BehaviorTree.TryGetData(out IFollowData followData)) return NodeState.Failed;
            Collider[] colliders = new Collider[10];
            int count = Physics.OverlapSphereNonAlloc(_transform.position, _seekRadius, colliders, _targetLayer);
            if (count == 0) return NodeState.Failed;
            var target = CheckForNearestTarget(colliders, count);
            if (target != null)
            {
                followData.Target = target;
                return NodeState.Success;
            }

            return NodeState.Failed;
        }

        private Transform CheckForNearestTarget(Collider[] colliders, int count)
        {
            Transform nearestTarget = null;
            float minDistance = float.MaxValue;

            for (int i = 0; i < count; i++)
            {
                var distance = Vector3.Distance(_transform.position, colliders[i].transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestTarget = colliders[i].transform;
                }
            }

            return nearestTarget;
        }
    }
}