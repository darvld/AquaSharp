namespace AquaSharp.data {
    /**<summary>A group of property keys used to configure the simulation environment.</summary>*/
    public static class SimulationEnvironment {
        /**<summary>Number of aeration days for the current crop.</summary>*/
        public static readonly PropertyKey<double> AerationDays = new();
    }
}