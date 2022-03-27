using UnityEngine;

namespace DASUnityFramework.VectorMathDebugger
{
    public abstract class VectorSourceBehaviour : MonoBehaviour
    {
        public abstract Vector3 Output { get; }
        public abstract Color Color { get; }
    }
}
