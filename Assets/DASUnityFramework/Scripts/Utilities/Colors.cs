using UnityEngine;

namespace DASUnityFramework.Scripts.Utilities
{
    public static class Colors
    {
        public static Color Red => Color.red;
        public static Color Orange => new Color(1, .647f, 0);
        public static Color Yellow => Color.yellow;
        
        public static Color Green => Color.green;
        public static Color Cyan => Color.cyan;
        public static Color Blue => Color.blue;
        
        public static Color Magenta => Color.magenta;
        public static Color Purple => new Color(.627f, .125f, .941f);
        public static Color Pink => new Color(1, .553f, .796f);
        
        
        public static Color White => Color.white;
        public static Color Black => Color.black;
        public static Color Grey => Color.grey;
        public static Color Gray => Color.gray;
        public static Color Clear => Color.clear;

        public static Color HexToColor(string hex)
        {
            ColorUtility.TryParseHtmlString(hex, out var color);
            return color;
        }
    }
}