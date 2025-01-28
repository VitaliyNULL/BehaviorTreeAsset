using UnityEngine;
using VitaliyNULL.Test.Enemy.Interfaces;

namespace VitaliyNULL.Test.Enemy
{
    public class EnemyBehaviorTreeData : IEnemyBehaviorTreeData
    {
        public Transform Transform { get; set; }
        public Transform Target { get; set; }

        public EnemyBehaviorTreeData(Transform transform)
        {
            Transform = transform;
        }
    }
}