using System;

namespace AquaSharp.utils {
    public static class PropertiesExtensions {
        public static T of<T>(this PropertyKey<T> key, Properties properties) {
            return properties.getProperty(key) ??
                   throw new MissingFieldException(
                       $"Property {key} not found in container {properties} (was null or wrong type)."
                   );
        }
    }
}