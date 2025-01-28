using System;
using UnityEngine;
using VitaliyNULL.Runtime.Interfaces;

namespace VitaliyNULL.Runtime.Core
{
    public abstract class BehaviorTreeRunnerBase : MonoBehaviour, IBehaviorTreeRunner
    {
        private BehaviorTree _behaviorTree;

        private void Awake()
        {
            _behaviorTree = InitializeTree();
        }

        private void Update()
        {
            _behaviorTree.Tick();
        }

        public bool TryGetData<T>(T data) where T : IBehaviorTreeData
        {
            return _behaviorTree.TryGetData(out data);
        }

        public abstract BehaviorTree InitializeTree();
    }
}