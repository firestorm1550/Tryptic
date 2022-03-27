using System.Collections.Generic;

namespace DASUnityFramework.Scripts.ActionManagement.Actions
{
    /// <summary>
    /// Handles operations for actions performed as a unit.
    /// </summary>
    public class CompoundAction : UndoableAction
    {
        public List<UndoableAction> actions;

        public CompoundAction(params UndoableAction[] actions)
        {
            this.actions = new List<UndoableAction>(actions);
        }

        public CompoundAction(List<UndoableAction> actions)
        {
            this.actions = new List<UndoableAction>(actions);
        }

        protected override void MyDo()
        {
            for (int i = 0; i < actions.Count; i++)
            {
                actions[i].Do();
            }
        }

        protected override void MyUndo()
        {
            for (int i = actions.Count - 1; i >= 0; i--)
            {
                actions[i].Undo();
            }
        }

        protected override void MyRedo()
        {
            for (int i = 0; i < actions.Count; i++)
            {
                actions[i].Redo();
            }
        }

        public override void Dispose()
        {
            foreach (UndoableAction action in actions)
            {
                action.Dispose();
            }
        }
    }
}