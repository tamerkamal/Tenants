using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tenants.Helpers.Extensions
{
    public static class ObjectsComparerExtensions
    {
        /// <summary>
        /// Compares the properties of two objects and return list of variances for all properties are different.
        /// </summary>
        /// <param name="source">The first object to compare.</param>
        /// <param name="destination">The second object to compare.</param>
        /// <param name="ignoreCase">To ignore case if property type is string.</param>
        /// <param name="ignoreList">To ignore list of properties.</param>
        /// <returns><c>List of variances</c> if any property values are different.</returns>
        public static List<Variance> Compare<TSource, TDestination>(this TSource source, TDestination destination, bool ignoreCase = true, params string[] ignoreList)
        {
            // Check string comparison
            var stringComparison = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;

            // Return list of variances
            return CompareObjects(source, destination, stringComparison, ignoreList).ToList();
        }

        /// <summary>
        /// Compares the properties of two objects and returns if all properties are equal.
        /// </summary>
        /// <param name="source">The first object to compare.</param>
        /// <param name="destination">The second object to compare.</param>
        /// <param name="ignoreCase">To ignore case if property type is string.</param>
        /// <param name="ignoreList">To ignore list of properties.</param>
        /// <returns><c>true</c> if all property values are equal, otherwise <c>false</c>.</returns>
        public static bool IsEqual<TSource, TDestination>(this TSource source, TDestination destination, bool ignoreCase = true, params string[] ignoreList)
        {
            if (source == null && destination == null)
                return true; // matched

            // Check string comparison
            var stringComparison = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;

            if (CanDirectlyCompare(source?.GetType()))
                return AreValuesEqual(source, destination, stringComparison);
            else
            {
                var variances = CompareObjects(source, destination, stringComparison, ignoreList).ToList();
                return !variances.Any();
            }
        }

        /// <summary>
        /// Compares the properties of two objects and return list of variances for all properties are different.
        /// </summary>
        /// <param name="source">The first object to compare.</param>
        /// <param name="destination">The second object to compare.</param>
        /// <param name="stringComparison">StringComparison to match or ignore case</param>
        /// <param name="ignoreList">To ignore list of properties.</param>
        /// <returns><c>List of variances</c> if any property values are different.</returns>
        private static IEnumerable<Variance> CompareObjects<TSource, TDestination>(TSource source, TDestination destination, StringComparison stringComparison, params string[] ignoreList)
        {
            var sourceProperties = source.GetType().GetProperties();
            var destinationType = destination.GetType();

            return from sourceProperty in sourceProperties
                   let destinationProperty = destinationType.GetProperty(sourceProperty.Name)
                   where destinationProperty != null
                   select new Variance
                   {
                       Property = sourceProperty.Name,
                       SourceValue = sourceProperty.GetValue(source, null),
                       DestinationValue = destinationProperty.GetValue(destination, null)
                   }
                   into variance
                   where !ignoreList.Contains(variance.Property) && !AreValuesEqual(variance.SourceValue, variance.DestinationValue, stringComparison)
                   select variance;
        }

        /// <summary>
        /// Compares two values and returns if they are the same.
        /// </summary>
        /// <param name="sourceValue">The first value to compare.</param>
        /// <param name="destinationValue">The second value to compare.</param>
        /// <param name="stringComparison">StringComparison to match or ignore case</param>
        /// <returns><c>true</c> if both values match, otherwise <c>false</c>.</returns>
        private static bool AreValuesEqual(object sourceValue, object destinationValue, StringComparison stringComparison)
        {
            var selfValueComparer = sourceValue as IComparable;

            if (sourceValue == null && destinationValue == null)
                return true; // matched

            if (sourceValue == null || destinationValue == null)
                return false; // one of the values is null

            if (sourceValue is string && destinationValue is string)
                return string.Equals(sourceValue.ToString(), destinationValue.ToString(), stringComparison); // the comparison using string Equals

            if (selfValueComparer != null && selfValueComparer.CompareTo(destinationValue) != 0)
                return false; // the comparison using IComparable failed

            if (sourceValue is byte[] sourceBytes && destinationValue is byte[] destinationBytes)
                return sourceBytes.SequenceEqual(destinationBytes); // the comparison using bytes[]

            if (sourceValue is IEnumerable sourceEnumerable && destinationValue is IEnumerable destinationEnumerable)
                return sourceEnumerable.Cast<object>().Count() == destinationEnumerable.Cast<object>().Count(); // the comparison using IEnumerable

            if (!Equals(sourceValue, destinationValue))
                return false; // the comparison using Equals failed

            return true; // matched
        }

        /// <summary>
        /// Determines whether value instances of the specified type can be directly compared.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// 	<c>true</c> if this value instances of the specified type can be directly compared; otherwise, <c>false</c>.
        /// </returns>
        private static bool CanDirectlyCompare(Type type)
        {
            return type == null || (typeof(IComparable).IsAssignableFrom(type) || type.IsPrimitive || type.IsValueType || type == typeof(byte[]));
        }
    }

    public class Variance
    {
        public string Property { get; set; }
        public object SourceValue { get; set; }
        public object DestinationValue { get; set; }
    }
}