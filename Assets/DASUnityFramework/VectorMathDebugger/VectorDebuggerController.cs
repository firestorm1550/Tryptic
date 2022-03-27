using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DASUnityFramework.VectorMathDebugger
{
    public class VectorDebuggerController : MonoBehaviour
    {
        public VectorModel vectorPrefab;
        public List<VectorSourceBehaviour> vectors = new List<VectorSourceBehaviour>();
        private List<VectorModel> vectorModels = new List<VectorModel>();

        private void Update()
        {
            for (int i = vectorModels.Count; i < vectors.Count; i++)
            {
                vectorModels.Add(Instantiate(vectorPrefab, Vector3.zero, Quaternion.identity, transform));
            }

            for (var i = 0; i < vectors.Count; i++)
            {
                VectorSourceBehaviour vectorSourceBehaviour = vectors[i];

                foreach (Renderer r in vectorModels[i].renderers)
                {
                    r.material.color = vectorSourceBehaviour.Color;
                }
                
                vectorModels[i].transform.localScale = new Vector3(1,1, vectorSourceBehaviour.Output.magnitude);
                vectorModels[i].transform.LookAt(transform.TransformPoint(vectorSourceBehaviour.Output), Vector3.up);
                vectorModels[i].currentValue = vectorSourceBehaviour.Output;
            }
        }
    }
}