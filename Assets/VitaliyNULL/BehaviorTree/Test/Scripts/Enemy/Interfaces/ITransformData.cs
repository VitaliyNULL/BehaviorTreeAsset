using UnityEngine;
using VitaliyNULL.Runtime.Interfaces;

namespace VitaliyNULL.Test.Enemy.Interfaces
{
    public interface ITransformData: IBehaviorTreeData
    {
        public Transform Transform { get; set; }
    }
}