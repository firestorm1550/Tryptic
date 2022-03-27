namespace DASUnityFramework.Scripts.ExtensionMethods
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Modifies the passed in array to assign every value to the passed in value. Returns the array for convenience.
        /// </summary>
        public static T[] Populate<T>(this T[] arr, T value ) 
        {
            for ( int i = 0; i < arr.Length;i++ ) 
                arr[i] = value;
            return arr;
        }
    }
}