using System.Collections;
using System.Collections.Generic;
using DASUnityFramework.Scripts.ExtensionMethods;
using DASUnityFramework.Scripts.ExtensionMethods.VectorExtensions;
using UnityEngine;


[ExecuteAlways]
public class GridLayout3D : MonoBehaviour
{
    public int rowLength = 7;
    public Vector2 spacing = new Vector2(3, 3);
    public bool reverseOrder;

    // Update is called once per frame
    void Update()
    {
        int rowIndex = 0;
        int rowNumber = 0;

        foreach (Transform child in transform)
        {
            child.localPosition = new Vector3(rowIndex * spacing.x, 0, rowNumber * spacing.y);
            if (reverseOrder)
                child.localPosition = child.localPosition.Multiply(new Vector3(1,1,-1));

            rowIndex++;
            if (rowIndex >= rowLength)
            {
                rowIndex = 0;
                rowNumber++;
            }
        }
    }
}
