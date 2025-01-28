using UnityEngine;
using VitaliyNULL.Runtime.Interfaces;

namespace VitaliyNULL.Test.Enemy.Interfaces
{
    public interface IFollowData: IBehaviorTreeData
    {
        public Transform Target { get; set; }
    }
}