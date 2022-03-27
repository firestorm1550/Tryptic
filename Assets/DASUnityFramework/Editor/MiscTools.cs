using System.Linq;
using DASUnityFramework.Scripts.ExtensionMethods;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace DASUnityFramework.Editor
{
    public class MiscTools
    {
        [MenuItem("Misc/How Many Objects Selected?")]
        static void PrintNumberOfObjectsSelected()
        {
            Debug.Log(Selection.objects.Length);
        }

        [MenuItem("Misc/Print Color Code For Selected Images")]
        static void PrintColorCodeForSelectedImages()
        {
            string output = "";

            GameObject[] objects = Selection.gameObjects;
            foreach (GameObject gameObject in objects)
            {
                Image image = gameObject.GetComponent<Image>();
                if (image)
                {
                    output += "new Color(" + image.color.r + "f, " + image.color.g + "f, " + image.color.b + "f)\n";
                }
            }
            Debug.Log(output);
        }

        [MenuItem("Misc/Append \" PLACEHOLDER\" to selected GameObjects' names")]
        static void AppendPLACEHOLDERToGameObjectNames()
        {
            string stringToAppend = " PLACEHOLDER";

            foreach (GameObject gameObject in Selection.gameObjects)
            {
                gameObject.name = gameObject.name + stringToAppend;
            }
        }

        [MenuItem("Misc/Append numbers to selected GameObjects' names")]
        static void AppendNumberToGameObjectNames()
        {
            for (var index = 0; index < Selection.gameObjects.Length; index++)
            {
                GameObject gameObject = Selection.gameObjects[index];
                gameObject.name = gameObject.name + index;
            }
        }

        [MenuItem("Misc/Print Selected Objects Bounds Size")]
        static void PrintSelectionBoundsSize()
        {
            Bounds b = Selection.gameObjects.Select(g => g.GetComponent<Renderer>()).ToArray().MakeBoundingBoxForObjectRenderers();
            Debug.Log(b);
        }

        [MenuItem("Misc/Match GameObject names to Text Content")]
        static void MatchGameObjectNameToTextContent()
        {
	        foreach (GameObject gameObject in Selection.gameObjects)
	        {
		        Text text = gameObject.GetComponent<Text>();
		        TextMeshProUGUI tmpUi = gameObject.GetComponent<TextMeshProUGUI>();
		        TextMeshPro tmpWorld = gameObject.GetComponent<TextMeshPro>();

		        if (text)
			        gameObject.name = text.text;
		        else if (tmpUi)
			        gameObject.name = tmpUi.text;
		        else if (tmpWorld)
			        gameObject.name = tmpWorld.text;
	        }
        }
    }
}
