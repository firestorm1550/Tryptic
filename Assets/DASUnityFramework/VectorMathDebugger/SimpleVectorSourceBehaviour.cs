using UnityEngine;

namespace DASUnityFramework.VectorMathDebugger
{
    public class SimpleVectorSourceBehaviour : VectorSourceBehaviour
    {
        public Vector3 vector;
        public override Vector3 Output => vector;
        public override Color Color => Color.white;
    }
}