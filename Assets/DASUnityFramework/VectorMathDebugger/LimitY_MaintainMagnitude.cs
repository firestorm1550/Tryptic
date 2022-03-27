using UnityEngine;

namespace DASUnityFramework.VectorMathDebugger
{
    public class LimitY_MaintainMagnitude : VectorSourceBehaviour
    {
        public VectorSourceBehaviour inputVectorSource;
        public float yMax = 1;
        
        
        public override Vector3 Output
        {
            get
            {
                Vector3 input = inputVectorSource.Output;
                if (Mathf.Abs(input.y) > yMax)
                {
                    float magnitude = input.magnitude;
                    float currentAngle = Mathf.Asin(input.y / magnitude) * Mathf.Rad2Deg;
                    float targetAngle = Mathf.Asin(Mathf.Sign(input.y) * yMax / magnitude) * Mathf.Rad2Deg;
                    
                    float degreesToRotate = targetAngle - currentAngle;

                    Vector3 axisToRotateOn = Vector3.Cross(input, Vector3.up);
                    Quaternion rotation = Quaternion.AngleAxis(degreesToRotate, axisToRotateOn);
                    
                    input =  rotation * input;
                }

                return input;
            }
        }

        public override Color Color => Color.yellow;
    }
}