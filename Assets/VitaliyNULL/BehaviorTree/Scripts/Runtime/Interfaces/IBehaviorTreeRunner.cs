using VitaliyNULL.Runtime.Core;

namespace VitaliyNULL.Runtime.Interfaces
{
    public interface IBehaviorTreeRunner
    {
        public bool TryGetData<T>(T data) where T : IBehaviorTreeData;
        public BehaviorTree InitializeTree();
    }
}