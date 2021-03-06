using System.Collections;

namespace AquaSharp {
    /**
     * <summary>A container for dynamically loaded data about a specific crop. Instances can be initialized
     * from any source using <see cref="setProperty{T}"/> with a matching key.</summary>
     */
    public class Properties {
        private readonly Hashtable properties = new();

        /**
         * <summary>Returns the value associated with the given <c>key</c>, or <c>null</c> if the
         * property has not been set.</summary>
         */
        public T? getProperty<T>(PropertyKey<T> key) {
            return (T) properties[key];
        }

        /**
         * <summary>Sets the <c>value</c> associated with the given <c>key</c>.</summary>
         */
        public void setProperty<T>(PropertyKey<T> key, T? value) {
            properties[key] = value;
        }
    }
}