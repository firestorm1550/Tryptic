using UnityEngine;

namespace DASUnityFramework.Scripts
{
	public class TargetFrameLimitSetter : MonoBehaviour
	{
		public int targetFrameRate;

		void Start()
		{
			Application.targetFrameRate = targetFrameRate;
		}
	}
}
