using UnityEngine;
using VitaliyNULL.Runtime.Interfaces;

namespace VitaliyNULL.Runtime.Core
{
    public abstract class BehaviorTreeGeneric<TData> : BehaviorTree where TData : IBehaviorTreeData
    {
        private TData _data;
        
        public sealed override bool TryGetData<T>(out T data)
        {
            if (_data is T value)
            {
                data = value;
                return true;
            }

            data = default;
            return false;
        }

        protected sealed override void SetData<T>(T data)
        {
            if (data is TData dataToSet)
            {
                _data = dataToSet;
            }
            else
            {
                Debug.LogError("Data is not correct");
            }
        }
    }
}