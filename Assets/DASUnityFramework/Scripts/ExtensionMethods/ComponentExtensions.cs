using System.Collections.Generic;
using UnityEngine;

namespace DASUnityFramework.Scripts.ExtensionMethods
{
    public static class ComponentExtensions
    {
        /// <summary>
        /// Get the distance between the positions of two components.
        /// </summary>
        public static float GetDistance(this Component c, Component other)
        {
            return (c.transform.position - other.transform.position).magnitude;
        }

        /// <summary>
        /// Get the squared distance between the positions of two components.
        /// </summary>
        public static float GetSquareDistance(this Component c, Component other)
        {
            return (c.transform.position - other.transform.position).sqrMagnitude;
        }


        /// <summary>
        /// Calculate the average position of the given transforms either in local space or world space
        /// </summary>
        public static Vector3 GetAveragePosition(this IEnumerable<Component> components, bool localSpace = true)
        {
            Vector3 sum = Vector3.zero;
            int num = 0;

            foreach (Component component in components)
            {
                sum += localSpace ? component.transform.localPosition : component.transform.position;
                num++;
            }

            return sum / num;
        }

        public static void SetActiveAll(this IEnumerable<Component> objs, bool value)
        {
	        foreach (Component c in objs)
		        c.gameObject.SetActive(value);
        }
    }
}
