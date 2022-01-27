namespace AquaSharp.utils {
    public static class PropertiesExtensions {
        public static T? from<T>(this PropertyKey<T> key, Properties properties) {
            return properties.getProperty(key);
        }
    }
}