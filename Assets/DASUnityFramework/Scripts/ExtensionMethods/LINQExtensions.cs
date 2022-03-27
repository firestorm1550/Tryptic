using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace System.Linq
{
    public static class LINQExtensions
    {
        /// <summary>
        /// Iterates through each element in <paramref name = "source"/> evaluating <paramref name="predicate"/> on
        /// each element to find which element returns the smallest value 
        /// </summary>
        /// <param name="source">A collection of objects</param>
        /// <param name="predicate">A function assigning a decimal value to each element of source</param>
        /// <returns>the element in <paramref name = "source"/> that returns the smallest value when passed into <paramref name="predicate"/></returns>
        /// <exception cref="NullReferenceException">Thrown if either source or predicate is null</exception>
        /// <exception cref="ArgumentException">Thrown if source has no elements</exception>
        [NotNull]
        public static TSource Least<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> predicate)
        {
            if (source == null)
                throw new NullReferenceException(nameof (source));
            if(predicate == null)
                throw new NullReferenceException(nameof (predicate));
            
            bool firstRun = true;
            TSource bestChoice = default;
            decimal bestValue = decimal.MaxValue;

            foreach (TSource item in source)
            {
                decimal value = predicate(item);
                if (value < bestValue || firstRun)
                {
                    bestChoice = item;
                    bestValue = value;
                    firstRun = false;
                }
            }

            if (firstRun == true)
                throw new ArgumentException("Passed IEnumerable has no elements");
            else if (bestChoice != null) 
                return bestChoice;
            else
                throw new NullReferenceException("Least() method is coded incorrectly. It should never come back with a null value.");
        }
        
        /// <summary>
        /// Iterates through each element in <paramref name = "source"/> evaluating <paramref name="predicate"/> on
        /// each element to find which element returns the largest value 
        /// </summary>
        /// <param name="source">A collection of objects</param>
        /// <param name="predicate">A function assigning a decimal value to each element of source</param>
        /// <returns>the element in <paramref name = "source"/> that returns the largest value when passed into <paramref name="predicate"/></returns>
        /// <exception cref="NullReferenceException">Thrown if either source or predicate is null</exception>
        /// <exception cref="ArgumentException">Thrown if source has no elements</exception>
        [NotNull]
        public static TSource Most<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> predicate)
        {
            if (source == null)
                throw new NullReferenceException(nameof (source));
            if(predicate == null)
                throw new NullReferenceException(nameof (predicate));

            bool firstRun = true;
            TSource bestChoice = default;
            decimal bestValue = decimal.MinValue;

            foreach (TSource item in source)
            {
                decimal value = predicate(item);
                if (value > bestValue || firstRun)
                {
                    bestChoice = item;
                    bestValue = value;
                    firstRun = false;
                }
            }

            if (firstRun == true)
                throw new ArgumentException("Passed IEnumerable has no elements");
            else if (bestChoice != null) 
                return bestChoice;
            else
                throw new NullReferenceException("Most() method is coded incorrectly. It should never come back with a null value.");
        }
    }
}