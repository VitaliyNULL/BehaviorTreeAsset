using UnityEngine;
using VitaliyNULL.Runtime.Core;
using VitaliyNULL.Runtime.Nodes.Actions;

namespace VitaliyNULL.Runtime.Nodes.Conditions
{
    public class WaitNode : ActionNode
    {
        #region Private Fields

        private readonly float _waitTime;
        private float _timer;
        private readonly bool _loaded;

        #endregion

        #region Constructor

        public WaitNode(BehaviorTree behaviorTree, float waitTime, bool loaded = false) : base(behaviorTree)
        {
            _waitTime = waitTime;
            _loaded = loaded;
            _timer = loaded ? waitTime : 0;
        }

        #endregion

        #region Override methods

        protected override NodeState TickNode()
        {
            _timer += Time.deltaTime;
            return _timer >= _waitTime ? NodeState.Success : NodeState.Running;
        }

        public override void ResetNode()
        {
            _timer = _loaded ? _waitTime : 0;
        }

        #endregion
    }
}