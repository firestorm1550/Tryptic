using System.IO;
using UnityEngine;

namespace DASUnityFramework.Scripts.Utilities
{
    public static class MathUtility3D
    {
        public static void CalculatePreciseBoundingSphere(out Vector3 center, out float radius, params MeshRenderer[] meshRenderers)
        {
            if (meshRenderers.Length == 0)
                throw new InvalidDataException("Must pass at least one mesh renderer");
            
            Vector3 max = Vector3.negativeInfinity;
            Vector3 min = Vector3.positiveInfinity;
            
            foreach (MeshRenderer meshRenderer in meshRenderers)
            {
                max = Vector3.Max(max, meshRenderer.bounds.max);
                min = Vector3.Min(min, meshRenderer.bounds.min);
            }

            center = (min + max) / 2f;
            radius = 0;

            foreach (MeshRenderer meshRenderer in meshRenderers)
            {
                MeshFilter meshFilter = meshRenderer.GetComponent<MeshFilter>();
                var vertices = Application.isPlaying ? meshFilter.mesh.vertices : meshFilter.sharedMesh.vertices; 
                foreach (var vertex in vertices)
                {
                    Vector3 worldPoint = meshFilter.transform.TransformPoint(vertex);
                    Vector3 centerToPoint = worldPoint - center;
                    radius = Mathf.Max(radius, centerToPoint.magnitude);
                }
            }
        }
    }
}