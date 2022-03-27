using System.Collections.Generic;
using System.Linq;
using DASUnityFramework.Scripts.Types;
using UnityEngine;

namespace DASUnityFramework.Scripts.ActionManagement.Actions
{
    public class TransformAction : UndoableAction
    {
        protected readonly List<Transform> _transforms;
        protected CompoundAction _compoundAction;
        public TransformAction(IEnumerable<Transform> transforms, List<TransformData> start, List<TransformData> end)
        {
            _transforms = new List<Transform>(transforms);
            _compoundAction = new CompoundAction(new List<UndoableAction>
            {
                new SetScaleAction(_transforms, start.Select(d=>d.scale).ToList(), end.Select(d=>d.scale).ToList()),
                new SetRotationAction(_transforms, start.Select(d=>d.rotation).ToList(), end.Select(d=>d.rotation).ToList()),
                new SetPositionAction(_transforms, start.Select(d=>d.position).ToList(), end.Select(d=>d.position).ToList()),
            });
        }

        public TransformAction(Transform t, TransformData start, TransformData end) : this(new List<Transform> {t},
            new List<TransformData> {start}, new List<TransformData> {end})
        {
            
        }

        protected override void MyDo()
        {
            _compoundAction.Do();
        }

        protected override void MyUndo()
        {
            _compoundAction.Undo();
        }

        public override void Dispose()
        {
            _compoundAction.Dispose();
        }
    }
}