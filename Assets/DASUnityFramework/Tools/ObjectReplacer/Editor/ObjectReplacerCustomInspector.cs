using System;
using System.Collections.Generic;
using DASUnityFramework.Scripts.ExtensionMethods;
using DASUnityFramework.Scripts.Types;
using UnityEditor;
using UnityEngine;

namespace DASUnityFramework.Tools.ObjectReplacer.Editor
{
	[CustomEditor(typeof(ObjectReplacer))]
	public class ObjectReplacerCustomInspector : UnityEditor.Editor
	{
		//todo: display this in custom inspector
		private Dictionary<GameObject, GameObject> _replacementToOriginal = new Dictionary<GameObject, GameObject>();
		public override void OnInspectorGUI()
		{
			EditorGUILayout.HelpBox(new GUIContent(
				"This object is used to replace copies of an object with Prefab references.\n" +

				"Instructions:\n" +
				"- Place the prefab you'd like to use in the slot below.\n" +
				"- Lock this inspector window.\n" +
				"- Select the objects in the scene you want to replace.\n" +
				"- Click create replacements\n" +
				"- Check that all the replacements look good.\n" +
				"- Click the finalize button to delete originals and set object names."));

			base.OnInspectorGUI();

			if (GUILayout.Button("Create Replacements"))
				CreateReplacements();
			if (GUILayout.Button("Finalize Replacement and Delete Originals"))
				FinalizeReplacementAndDeleteOriginals();
		}

		private void CreateReplacements()
		{
			ObjectReplacer objectReplacer = (ObjectReplacer)target;
			AssertPreconditions(objectReplacer);

			// delete existing replacements
			foreach (GameObject key in _replacementToOriginal.Keys)
				if (key)
					DestroyImmediate(key);

			_replacementToOriginal = new Dictionary<GameObject, GameObject>();
			foreach (GameObject original in Selection.gameObjects)
			{
				GameObject replacement = (GameObject) PrefabUtility.InstantiatePrefab(objectReplacer.prefab, original.transform.parent);
				replacement.name = "Replacement for " + original.name;
				replacement.transform.SetLocal(new TransformData(original.transform));
				replacement.transform.SetSiblingIndex(original.transform.GetSiblingIndex() + 1);
				_replacementToOriginal.Add(replacement, original);
			}
		}

		private void FinalizeReplacementAndDeleteOriginals()
		{
			foreach (GameObject replacement in _replacementToOriginal.Keys)
			{
				if (replacement)
				{
					GameObject original = _replacementToOriginal[replacement];
					replacement.gameObject.name = original.name;
					DestroyImmediate(original);
				}
			}
			_replacementToOriginal.Clear();
		}

		private void AssertPreconditions(ObjectReplacer objectReplacer)
		{
			if (Selection.gameObjects.Length == 0)
				throw new Exception("No objects are selected.");
			if (objectReplacer.prefab == null)
				throw new Exception("No prefab set in " + objectReplacer.gameObject.name);
		}
	}
}
