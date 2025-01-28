using VitaliyNULL.Runtime.Interfaces;
using VitaliyNULL.Runtime.Nodes;

namespace VitaliyNULL.Runtime.Core
{
    public abstract class BehaviorTree
    {
        #region Public fields

        private BehaviorTreeNode _rootNode;

        #endregion

        #region Private fields

        private bool _isPaused;

        #endregion

        #region Public methods

        public void InitializeTree()
        {
            _rootNode = SetupBehaviourTree();
        }

        #endregion

        #region Virtual methods

        public virtual NodeState Tick()
        {
            if (_isPaused) return NodeState.Failed;
            var state = _rootNode.Tick();
            return state;
        }

        public virtual void PauseBehaviorTree()
        {
            _isPaused = true;
        }

        public virtual void ResumeBehaviorTree()
        {
            _isPaused = false;
        }

        #endregion

        #region Abstract methods

        protected abstract BehaviorTreeNode SetupBehaviourTree();
        protected abstract void SetData<T>(T data) where T : IBehaviorTreeData;
        public abstract bool TryGetData<T>(out T data) where T : IBehaviorTreeData;

        #endregion
    }
}