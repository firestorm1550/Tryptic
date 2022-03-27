using UnityEngine;

namespace DASUnityFramework.Scripts
{
    public class ObjectDocumentator : MonoBehaviour
    { 
        [TextArea(8,16)]
        public string documentation;
    }
}
