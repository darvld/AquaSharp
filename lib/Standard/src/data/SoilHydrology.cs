namespace AquaSharp.data {
    public static class SoilHydrology {
        /**<summary>Water content at permanent wilting point (in m3/m3).</summary>*/
        public static readonly PropertyKey<double> WaterContentAtWilting = new();
        
        /**<summary>Water content at field capacity (in m3/m3).</summary>*/
        public static readonly PropertyKey<double> WaterContentAtCapacity = new();
    }
}