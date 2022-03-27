using System;
using DASUnityFramework.Scripts.Utilities;
using UnityEngine;

namespace DASUnityFramework.Scripts.ExtensionMethods
{
    public static class MaterialExtensionMethods
    {
        private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");
        private static readonly int Color = Shader.PropertyToID("_Color");
        private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");
        private static readonly int Tint = Shader.PropertyToID("_Tint");

        public static bool HasColor(this Material material, ShaderPropertyName propertyName)
        {
#if UNITY_2021_2_OR_NEWER
            return material.HasColor(propertyName.GetShaderPropertyID());
#else
            return material.HasProperty(propertyName.GetShaderPropertyID());
#endif
        }
        
        /// <summary>
        /// Retrieve material's color for a given shader property. Throws an Exception if
        /// the property does not exist.
        /// </summary>
        public static Color GetColor(this Material material, ShaderPropertyName propertyName)
        {
            if (material.HasColor(propertyName))
                return material.GetColor(propertyName.GetShaderPropertyID());
            else
                throw new Exception("material " + material.name + " doesn't have property \""+ propertyName + "\"");

        }
        
        /// <summary>
        /// Set the color of a shader property on a material. Throws an Exception if the
        /// property does not exist.
        /// </summary>
        public static void SetColor(this Material material, Color color, ShaderPropertyName propertyName)
        {
            if (material.HasColor(propertyName))
                material.SetColor(propertyName.GetShaderPropertyID(), color);
            else
                throw new Exception("material " + material.name + " doesn't have property \""+ propertyName + "\"");
        }

        /// <summary>
        /// Multiply the color of a given shader property by a given Color.
        /// Throws an Exception if the property does not exist.
        /// </summary>
        public static void MultiplyColor(this Material material, Color multiplier, ShaderPropertyName propertyName)
        {
            Color currentColor = GetColor(material, propertyName);
            SetColor(material, currentColor * multiplier, propertyName);
        }
        
        /// <summary>
        /// Divide the color of a given shader property by a given Color. Throws
        /// an Exception if the property does not exist.
        /// </summary>
        public static void DivideColor(this Material material, Color divisor, ShaderPropertyName propertyName)
        {
            Color currentColor = GetColor(material, propertyName);
            SetColor(material, currentColor.Divide(divisor), propertyName);
        }

        public static int GetShaderPropertyID(this ShaderPropertyName shaderPropertyName)
        {
            switch (shaderPropertyName)
            {
                case ShaderPropertyName._EmissionColor:
                    return EmissionColor;
                case ShaderPropertyName._Color:
                    return Color;
                case ShaderPropertyName._Tint:
                    return Tint;
                case ShaderPropertyName._BaseColor:
                    return BaseColor;
                default:
                    throw new ArgumentOutOfRangeException(nameof(shaderPropertyName), shaderPropertyName, null);
            }
        }
        
    }
}