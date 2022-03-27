using System.IO;
using System.Linq;
using DASUnityFramework.Scripts.ExtensionMethods.VectorExtensions;
using DASUnityFramework.Scripts.Utilities;
using UnityEngine;

namespace DASUnityFramework.Scripts.ExtensionMethods
{
    public static class CameraExtensionMethods
    {
        /// <summary>
        /// Move this camera so it is looking at a collection of objects and can see the entirety of all of them. Note:
        /// this method is moderately expensive since it iterates through every vertex twice. Time Complexity: O(2N).
        /// Returns the look target.
        /// </summary>
        public static Vector3 PreciselyMoveCameraToSeeRenderers(this Camera camera, Vector3 viewFromDirection, params MeshRenderer[] meshRenderers)
        {
            if (meshRenderers.Length == 0)
                throw new InvalidDataException("Must pass at least one mesh renderer");
            
            viewFromDirection = viewFromDirection.normalized;
            float distanceToSeeWholeBounds = GetPreciseCameraDistanceToSeeMeshRenderers(camera, out Vector3 lookTarget, meshRenderers);
            Transform camTransform = camera.transform;

            lookTarget.DrawPointAndRotationInEditorGizmos(Quaternion.identity);
            
            //reposition camera based on calculated viewport size
            camTransform.position = lookTarget + distanceToSeeWholeBounds * viewFromDirection;
            camTransform.LookAt(lookTarget);
            return lookTarget;
        }
        
        /// <summary>
        /// Calculate the distance necessary to see all the passed in objects from any angle. Note:
        /// this method is moderately expensive since it iterates through every vertex twice. Time Complexity: O(2N)
        /// </summary>
        public static float GetPreciseCameraDistanceToSeeMeshRenderers(this Camera camera, out Vector3 cameraLookTarget, params MeshRenderer[] meshRenderers)
        {
            MathUtility3D.CalculatePreciseBoundingSphere(out Vector3 center, out float radius, meshRenderers);
            cameraLookTarget = center;
            return camera.GetCameraDistanceToSeeWholeSphere(radius);
        }
        
        /// <summary>
        /// Calculate the distance necessary to see the entirety of the passed in bounds from any angle.
        /// </summary>
        public static float GetCameraDistanceToSeeWholeBounds(this Camera camera, Bounds bounds)
        {
            float sphereRadius = bounds.CalculateBoundingRadius();
            return camera.GetCameraDistanceToSeeWholeSphere(sphereRadius);
        }

        
        public static float GetCameraDistanceToSeeWholeSphere(this Camera camera, float radius)
        {
            float camFov = camera.fieldOfView;
            
            float thetaOver2Vertical = camFov / 2; 
            float thetaOver2Horizontal = Camera.VerticalToHorizontalFieldOfView(camFov, camera.aspect)/2;
            float thetaOver2 = Mathf.Min(thetaOver2Horizontal, thetaOver2Vertical);
            
            // d = R/sin(thetaOver2)
            float distance = radius / Mathf.Sin(Mathf.Deg2Rad * thetaOver2);
            return distance;
        }
        
        /// <summary>
        /// move this camera to see the entirety of the passed in bounds from any angle. This is quick,
        /// but will create large distances for objects with relatively large AABBs
        /// </summary>
        public static void MoveCameraToSeeWholeBounds(this Camera camera, Bounds bounds, Vector3 viewFromDirection, float fudgeFactor = 1.2f)
        {
            viewFromDirection = viewFromDirection.normalized;
            float distanceToSeeWholeBounds = GetCameraDistanceToSeeWholeBounds(camera, bounds);
            Transform camTransform = camera.transform;
            
            //reposition camera based on calculated viewport size
            camTransform.position = bounds.center + distanceToSeeWholeBounds * viewFromDirection;
            camTransform.LookAt(bounds.center);
        }

        public static Vector2 WorldVectorToScreenVector(this Camera camera, Vector3 start, Vector3 end)
        {
            return camera.WorldToScreenPoint(end) - camera.WorldToScreenPoint(start);
        }
    
        /// <summary>
        /// Calculates the world-space position of the top-right and bottom-left corners of the viewport at the given distance.
        /// </summary>
        public static void GetViewportCornersInWorldSpace(this Camera camera, float distance, out Vector3 topRight, out Vector3 bottomLeft)
        {
            Vector3 v3ViewPort = new Vector3(0,0,distance);
            bottomLeft = camera.ViewportToWorldPoint(v3ViewPort);
            v3ViewPort.Set(1,1,distance);
            topRight = camera.ViewportToWorldPoint(v3ViewPort);
        }
        
        public static Texture2D RenderCameraToTexture2D(this Camera c)
        {
            return c.RenderCameraToTexture2D(c.targetTexture.width, c.targetTexture.height);
        }

        public static Texture2D RenderCameraToTexture2D(this Camera c, int width, int height)
        {
            //store camera's initial target and switch to the created RT
            RenderTexture initialRt = c.targetTexture;
            RenderTexture rt = new RenderTexture(width, height, 1);
            c.targetTexture = rt;
            
            // Render and convert to Texture2D
            c.Render();
            Texture2D texture2D = rt.ToTexture2D();
            
            // Restore initial camera target
            c.targetTexture = initialRt;
            return texture2D;
        }

        public static Texture2D ToTexture2D(this RenderTexture rTex)
        {
            Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGBA32, false);
            var oldRT = RenderTexture.active;
            RenderTexture.active = rTex;

            tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
            tex.Apply();

            RenderTexture.active = oldRT;
            return tex;
        }
        
        public static void SaveTextureAsPNG(this Texture2D texture, string fullPath)
        {
            if (fullPath.EndsWith(".png") == false)
                fullPath += ".png";

            byte[] bytes = texture.EncodeToPNG();
            System.IO.File.WriteAllBytes(fullPath, bytes);
            Debug.Log(bytes.Length/1024  + "Kb was saved as: " + fullPath);
        }
        
        public static Rect ViewportRectFromBounds(this Camera camera, Bounds worldBounds)
        {
            Bounds b = worldBounds;
            var extentPoints = new Vector2[]
            {
                camera.WorldToViewportPoint(b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f),
                camera.WorldToViewportPoint(b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f),
                camera.WorldToViewportPoint(b.center + new Vector3(b.size.x, -b.size.y, b.size.z) * 0.5f),
                camera.WorldToViewportPoint(b.center + new Vector3(-b.size.x, -b.size.y, b.size.z) * 0.5f),
                camera.WorldToViewportPoint(b.center + new Vector3(-b.size.x, b.size.y, -b.size.z) * 0.5f),
                camera.WorldToViewportPoint(b.center + new Vector3(b.size.x, b.size.y, -b.size.z) * 0.5f),
                camera.WorldToViewportPoint(b.center + new Vector3(b.size.x, b.size.y, b.size.z) * 0.5f),
                camera.WorldToViewportPoint(b.center + new Vector3(-b.size.x, b.size.y, b.size.z) * 0.5f)
            };
 
            Vector2 min = extentPoints[0];
            Vector2 max = extentPoints[0];
            foreach (Vector2 v in extentPoints)
            {
                min = Vector2.Min(min, v);
                max = Vector2.Max(max, v);
            }
            return new Rect(min.x, min.y, max.x - min.x, max.y - min.y);
        }
    }
}
