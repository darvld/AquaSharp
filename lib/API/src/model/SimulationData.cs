namespace AquaSharp {
    /**
     * <summary>Contains all necessary input data to set up a <see cref="Simulation">simulation</see>.</summary>
     */
    public class SimulationData {
        /**<summary>Dynamic container for environmental properties, such as soil qualities and depth, etc.</summary>*/
        public readonly Properties environment = new();
    }
}