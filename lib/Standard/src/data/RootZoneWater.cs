namespace AquaSharp.data {
    /**
     * <summary>Property keys corresponding to the RootZoneWater group.</summary>
     */
    public static class RootZoneWater {
        /**<summary>Actual water content (in m3/m3) of the root zone.</summary>*/
        public static readonly PropertyKey<double> ActualWaterContent = new();

        /**<summary>Water content (in m3/m3) of the root zone at the aeration stress threshold.</summary>*/
        public static readonly PropertyKey<double> WaterContentAtStressThreshold = new();

        /**<summary>Water content (in m3/m3) of the root zone at the saturation point.</summary>*/
        public static readonly PropertyKey<double> WaterContentAtSaturation = new();
    }
}