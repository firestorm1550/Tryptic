using System.Collections.Generic;
using System.Linq;
using DASUnityFramework.Scripts.Types;
using UnityEngine;

namespace DASUnityFramework.Scripts.ExtensionMethods
{
    public static class GameObjectAndTransformExtensionMethods
    {
        //=============== Transform and GameObject Extensions ==========================================

        /// <summary>
        /// Destroy all children of a Transform.
        /// </summary>
        /// <param name="obj">Root Transform</param>
        /// <param name="destroyImmediate">Use Destroy or DestroyImmediate</param>
        public static void DestroyAllChildren(this Transform obj, bool destroyImmediate = false)
        {
            int numChildren = obj.childCount;
            for (int i = numChildren - 1; i >= 0; i--)
            {
                if(destroyImmediate)
                    Object.DestroyImmediate(obj.GetChild(i).gameObject);
                else
                    Object.Destroy(obj.GetChild(i).gameObject);
            }
        }

        /// <summary>
        /// Recursively set all of a GameObject's children to active.
        /// </summary>
        /// <param name="obj">Root object</param>
        /// <param name="value">Modifies root object's active state</param>
        public static void SetAllChildrenActive(this GameObject obj, bool value)
        {
            obj.SetActive(value);
            for (int i = 0; i < obj.transform.childCount; i++)
            {
                obj.transform.GetChild(i).gameObject.SetAllChildrenActive(true);
            }
        }

        public static List<GameObject> GetThisAndAllChildrenRecursively(this GameObject gameObject)
        {
            return gameObject.GetComponentsInChildren<Transform>().Select(t => t.gameObject).ToList();
        }
        
        public static List<GameObject> GetTheseAndAllChildrenRecursively(this IEnumerable<GameObject> gameObjects)
        {
            return gameObjects.SelectMany(g => g.GetThisAndAllChildrenRecursively()).ToList();
        }

        public static void SetActiveAll(this IEnumerable<GameObject> objs, bool value)
        {
	        foreach (GameObject o in objs) o.SetActive(value);
        }

        public static string GetPath(this GameObject gameObject)
        {
            return GetPath(gameObject.transform);
        }

        public static string GetPath(this Transform current) {
            if (current.parent == null)
                return "/" + current.name;
            return current.parent.GetPath() + "/" + current.name;
        }

        // Call base function with Transform's GameObject.
        public static void SetLayerRecursively(this Transform transform, int layer)
        {
            SetLayerRecursively(transform.gameObject, layer);
        }

        /// <summary>
        /// Calculate the average position of the given transforms either in local space or world space
        /// </summary>
        public static Vector3 GetAveragePosition(this IEnumerable<Transform> transforms, bool localSpace = true)
        {
            Vector3 sum = Vector3.zero;
            int num = 0;

            foreach (Transform transform in transforms)
            {
                sum += localSpace ? transform.localPosition : transform.position;
                num++;
            }

            return sum / num;
        }


        /// <summary>
        /// Set layer of GameObject and all of its children. Includes inactive
        /// children.
        /// </summary>
        public static void SetLayerRecursively(this GameObject objectToSet, int layer)
        {
            foreach (Transform transform in objectToSet.GetComponentsInChildren<Transform>(true))
                transform.gameObject.layer = layer;
        }

        /// <summary>
        /// Set layer of GameObject and all of its children. Includes inactive
        /// children.
        /// </summary>
        /// <param name="objectToSet">Root object</param>
        /// <param name="layer">New layer</param>
        /// <param name="intitialLayers">Mapping of GameObjects to their initial layers</param>
        public static void SetLayerRecursively(this GameObject objectToSet, int layer, out Dictionary<GameObject, int> intitialLayers)
        {
            intitialLayers = new Dictionary<GameObject, int>();

            foreach (Transform transform in objectToSet.GetComponentsInChildren<Transform>(true))
            {
                GameObject g = transform.gameObject;
                intitialLayers[g] = g.layer;
                g.layer = layer;
            }
        }

        /// <summary>
        /// Reset Transform's local scale, rotation and position to defaults.
        /// </summary>
        public static void Reset(this Transform t)
        {
            t.localScale = Vector3.one;
            t.localRotation = Quaternion.identity;
            t.localPosition = Vector3.zero;
        }

        /// <summary>
        /// Set Transform's local scale, rotation and position to match given
        /// TransformData.
        /// </summary>
        public static void SetLocal(this Transform t, TransformData transformData)
        {
            t.localScale = transformData.scale;
            t.localRotation = transformData.rotation;
            t.localPosition = transformData.position;
        }

        /// <summary>
        /// Find all children of a Transform. Does not include given Transform.
        /// </summary>
        public static List<Transform> GetChildren(this Transform transform)
        {
            List<Transform> children = new List<Transform>();
            for (int i = 0; i < transform.childCount; i++)
            {
                children.Add(transform.GetChild(i));
            }

            return children;
        }

        /// <summary>
        /// Convert collection of GameObjects to list of TransformDatas.
        /// </summary>
        public static List<TransformData> GetTransformData(this IEnumerable<GameObject> gameObjects)
        {
            return gameObjects.Select(g => new TransformData(g.transform)).ToList();
        }

        /// <summary>
        /// Convert collection of Transforms to list of TransformDatas.
        /// </summary>
        public static List<TransformData> GetTransformData(this IEnumerable<Transform> transforms)
        {
            return transforms.Select(t => new TransformData(t)).ToList();
        }

        /// <summary>
        /// Scales the target around an arbitrary point by scaleFactor.
        /// This is relative scaling, meaning using  scale Factor of Vector3.one
        /// will not change anything and new Vector3(0.5f,0.5f,0.5f) will reduce
        /// the object size by half.
        /// The pivot is assumed to be the position in the space of the target.
        /// Scaling is applied to localScale of target.
        /// </summary>
        /// <param name="target">The object to scale.</param>
        /// <param name="pivot">The point to scale around in space of target.</param>
        /// <param name="scaleFactor">The factor with which the current localScale of the target will be multiplied with.</param>
        public static void ScaleAroundRelative(this GameObject target, Vector3 pivot, Vector3 scaleFactor)
        {
            // pivot
            var pivotDelta = target.transform.localPosition - pivot;
            pivotDelta.Scale(scaleFactor);
            target.transform.localPosition = pivot + pivotDelta;

            // scale
            var finalScale = target.transform.localScale;
            finalScale.Scale(scaleFactor);
            target.transform.localScale = finalScale;
        }

        /// <summary>
        /// Scales the target around an arbitrary pivot.
        /// This is absolute scaling, meaning using for example a scale factor of
        /// Vector3.one will set the localScale of target to x=1, y=1 and z=1.
        /// The pivot is assumed to be the position in the space of the target.
        /// Scaling is applied to localScale of target.
        /// </summary>
        /// <param name="target">The object to scale.</param>
        /// <param name="pivot">The point to scale around in the space of target.</param>
        /// <param name="scaleFactor">The new localScale the target object will have after scaling.</param>
        public static void ScaleAround(this GameObject target, Vector3 pivot, Vector3 newScale)
        {
            // pivot
            Vector3 pivotDelta = target.transform.localPosition - pivot; // diff from object pivot to desired pivot/origin
            Vector3 scaleFactor = new Vector3(
                newScale.x / target.transform.localScale.x,
                newScale.y / target.transform.localScale.y,
                newScale.z / target.transform.localScale.z );
            pivotDelta.Scale(scaleFactor);
            target.transform.localPosition = pivot + pivotDelta;

            //scale
            target.transform.localScale = newScale;
        }

        #region LookAway Methods
        /// <summary>
        /// The opposite of Transform.LookAt()
        /// </summary>
        public static void LookAway(this Transform t, Vector3 point)
        {
            t.LookAt(2 * t.position - point);
        }


        /// <summary>
        /// The opposite of Transform.LookAt()
        /// </summary>
        public static void LookAway(this Transform t, Transform target)
        {
            t.LookAt(2 * t.position - target.position);
        }

        /// <summary>
        /// The opposite of Transform.LookAt()
        /// </summary>
        public static void LookAway(this Transform t, Vector3 point, Vector3 worldUp)
        {
            t.LookAt(2 * t.position - point, worldUp);
        }

        /// <summary>
        /// The opposite of Transform.LookAt()
        /// </summary>
        public static void LookAway(this Transform t, Transform target, Vector3 worldUp)
        {
            t.LookAt(2 * t.position - target.position, worldUp);
        }


        #endregion
    }
}
