using UnityEngine;
using VitaliyNULL.Runtime.Core;

namespace VitaliyNULL.Test.Enemy
{
    public class EnemyBehaviorTreeRunner : BehaviorTreeRunnerBase
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _seekRadius;
        [SerializeField] private LayerMask _targetLayer;

        public override BehaviorTree InitializeTree()
        {
            var behaviorTree = new EnemyBehaviorTree(transform, _speed, _targetLayer, _seekRadius);
            behaviorTree.InitializeTree();
            return behaviorTree;
        }
    }
}