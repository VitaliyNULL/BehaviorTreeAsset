using UnityEngine;
using VitaliyNULL.Runtime.Core;
using VitaliyNULL.Runtime.Nodes.Compositions;
using VitaliyNULL.Test.Enemy.Interfaces;
using VitaliyNULL.Test.Enemy.Node;

namespace VitaliyNULL.Test.Enemy
{
    public class EnemyBehaviorTree : BehaviorTreeGeneric<IEnemyBehaviorTreeData>
    {
        private readonly Transform _transform;
        private readonly float _speed;
        private readonly LayerMask _targetLayer;
        private readonly float _seekRadius;

        public EnemyBehaviorTree(Transform transform, float speed, LayerMask targetLayer, float seekRadius) : base()
        {
            _transform = transform;
            _speed = speed;
            _targetLayer = targetLayer;
            _seekRadius = seekRadius;
        }

        protected override BehaviorTreeNode SetupBehaviourTree()
        {
            SetData(new EnemyBehaviorTreeData(_transform));
            var rootNode = new FallbackNode(this);
            var followSequence = new SequenceNode(this);
            followSequence.AttachNode(SetupSeekNode());
            followSequence.AttachNode(SetupFollowNode());
            rootNode.AttachNode(followSequence);
            return rootNode;
        }

        private BehaviorTreeNode SetupFollowNode()
        {
            var sequence = new SequenceNode(this);
            sequence.AttachNode(new CheckForTargetNode(this));
            sequence.AttachNode(new FollowTargetNode(this, _transform, _speed));
            return sequence;
        }

        private BehaviorTreeNode SetupSeekNode()
        {
            var sequence = new SequenceNode(this);
            sequence.AttachNode(new SeekTargetNode(this, _transform, _targetLayer, _seekRadius));
            return sequence;
        }
    }
}