namespace AquaSharp.data {
    /**<summary>A group of property keys related to aeration for a given crop.</summary>*/
    public static class CropAeration {
        /**
         * <summary>Number of days before aeration stress stunts crop growth. Corresponds
         * to the <c>Crop.LagAer</c> field in the original implementation.</summary>
         */
        public static readonly PropertyKey<double> AerationStuntThreshold = new();
    }
}