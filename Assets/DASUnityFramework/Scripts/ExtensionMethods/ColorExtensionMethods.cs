using UnityEngine;

namespace DASUnityFramework.Scripts.ExtensionMethods
{
    public static class ColorExtensionMethods
    {
        public static Color WithAlpha(this Color c, float alpha)
        {
            return new Color(c.r,c.g,c.b,alpha);
        }

        public static Color Divide(this Color n, Color d)
        {
            return new Color(n.r / d.r, n.g / d.g, n.b / d.b, n.a / d.a);
        }

        /// <summary>
        /// This method returns the input color with each component modified such that, if it was zero, it will now be minValue.
        /// This is useful because it allows you to avoid destroying information by multiplying color values by zero.
        ///
        /// For example, if I tint (multiply) the color (.75,.75,.75,1) to red (1,0,0,1), and then try to undo that by dividing,
        /// I'll get an NAN for blue and green
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Color ClampToNonZero(this Color c, float minValue)
        {
            return new Color(Mathf.Max(c.r, minValue),
                Mathf.Max(c.g, minValue),
                Mathf.Max(c.b, minValue),
                Mathf.Max(c.a, minValue));
        }
    }
}