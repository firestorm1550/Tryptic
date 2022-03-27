using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace DASUnityFramework.Scripts.ExtensionMethods
{
    public static class FloatAndIntExtensionMethods
    {
        //=============== int Extensions ==========================================
        
        /// <summary>
        /// Finds the lowest-value of integer in list that's greater than the
        /// given value. 
        /// </summary>
        /// <returns>Integer value or null.</returns>
        public static int? GetClosestHigher(this IEnumerable<int> list, int value)
        {
            int? best = null;
            foreach (int d in list)
            {
                if (d > value && (best.HasValue == false || d < best.Value))
                    best = d;
            }

            return best;
        }
        
        /// <summary>
        /// Finds the highest-value of integer in list that's lower than the
        /// given value. 
        /// </summary>
        /// <returns>Integer value or null.</returns>
        public static int? GetClosestLower(this IEnumerable<int> list, int value)
        {
            int? best = null;
            foreach (int d in list)
            {
                if (d < value && (best.HasValue == false || d > best.Value))
                    best = d;
            }

            return best;
        }
        
        /// <summary>
        /// Converts given integer to a string and prepends a "0" if the value
        /// is less than 10 and non-negative.
        /// </summary>
        public static string As2Digits(this int i)
        {
            if (i >= 0 && i < 10)
            {
                return "0" + i;
            }
            else
            {
                return i + "";
            }
        }

        public static bool IsEven(this int i)
        {
            return i % 2 == 0;
        }
        
        public static bool IsOdd(this int i)
        {
            return i % 2 == 1;
        }

        public static int Abs(this int i)
        {
            return Mathf.Abs(i);
        }
        
        //=============== float Extensions ==========================================
        
        public static float Remap (this float value, float from1, float to1, float from2, float to2) {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }

        
        /// <summary>
        /// Determines the equality of two floats up to a specified precision
        /// </summary>
        /// <returns>True if the difference between f and f1 is less than precision</returns>
        public static bool RoughlyEquals(this float f, float f1, float precision = Single.Epsilon)
        {
            return Mathf.Abs(f1 - f) < Mathf.Abs(precision);
        }

        public static float Sign(this float f)
        {
            if (f == 0)
                return 0;
            if (f > 0)
                return 1;
            else
                return -1;
        }
        
        /// <summary>
        /// Round given float to nearest multiple of modulo. Modulos must be
        /// positive.
        /// </summary>
        /// <example>
        ///     .25 to nearest 1
        ///     .25 left over
        ///      we subtract .25 
        ///     Good

        ///     -.25 to nearest 1
        ///      -.25 left over
        ///     Good

        ///     .75 to nearest 1
        ///     .75 left over
        ///      add 1-.75f
        ///      = 1 good
        ///     -.75 to nearest 1
        ///     -.75 left over
        ///      retval = -.75 - 1 + .75
        ///       = -1. Good
        /// </example>
        public static float RoundToNearest(this float f, float modulo)
        {
            if (modulo <= 0)
                throw new Exception("Please don't use negative numbers as your modulo. It's probably not going to work.");

            float retval;

            float amountLeftOver = f % modulo;

            if (amountLeftOver > 0)
            {
                if (amountLeftOver > modulo / 2)
                    retval = f + modulo - amountLeftOver;
                else
                    retval = f - amountLeftOver;
            }
            else
            {
                if (Mathf.Abs(amountLeftOver) > modulo / 2)
                    retval = f - modulo - amountLeftOver;
                else
                    retval = f - amountLeftOver;
            }

            return retval;
        }
        
        /// <summary>
        /// Convert float to rounded number as a string.
        /// </summary>
        /// <param name="f">Raw float value.</param>
        /// <param name="digitsAfterDecimalPoint">Precision of rounded value.</param>
        public static string ToRoundedString(this float f, int digitsAfterDecimalPoint)
        {
            return Math.Round(f, digitsAfterDecimalPoint).ToString(CultureInfo.InvariantCulture);
        }

        public static float ReduceAngleTo0To360(this float f)
        {
            while (f < 0)
                f += 360;
            return f % 360;
        }
        
        /// <summary>
        /// Clamps <paramref name="value"/> so its absolute value is no less than absMin and no more than .
        /// </summary>
        /// <param name="value">The value being clamped.</param>
        /// <param name="absMin">The minimum absolute value (must be no less than 0)</param>
        /// <param name="absMax">The maximum absolute value (must be no less than <paramref name="absMin"/>)</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static float ClampAbs(this float value, float absMin, float absMax)
        {
            if (absMax < 0 || absMin < 0)
                throw new ArgumentException("absMin and absMax must not be negative numbers. Min: " + absMin + "; Max: " + absMax);
            if(absMin > absMax)
                throw new ArgumentException("absMin must be less than absMax. Min: " + absMin + "; Max: " + absMax);

            float sign = Mathf.Sign(value);
            float abs  = Mathf.Abs(value);

            float clampedAbs = Mathf.Clamp(abs, absMin, absMax);
            return sign * clampedAbs;
        }

        public static float Clamp01(this float f)
        {
            return Mathf.Clamp01(f);
        }

    }
}