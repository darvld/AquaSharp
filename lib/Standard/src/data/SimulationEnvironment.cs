using System.Collections.Generic;

namespace AquaSharp.data {
    /**<summary>A group of property keys used to configure the simulation environment.</summary>*/
    public static class SimulationEnvironment {
        /**<summary>Number of aeration days for the current crop.</summary>*/
        public static readonly PropertyKey<double> AerationDays = new();
        
        /**<summary>Rooting zone depth for the compartment.</summary>*/
        public static readonly PropertyKey<double> RootingDepth = new();
        
        /**<summary>Current water content of the compartment.</summary>*/
        public static readonly PropertyKey<double> WaterContent = new();
        
        /**<summary>Layer composition of the compartment.</summary>*/
        public static readonly PropertyKey<List<SoilLayer>> SoilLayers = new();
    }
}