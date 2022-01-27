namespace AquaSharp {
    /**
     * <summary>Base contract used to obtain a <see cref="Simulation">simulation</see> implementation
     * from initial data.</summary>
     *
     * <seealso cref="simulate"/>
     */
    public interface AquaCropEngine {
        /**
         * <summary>Initializes and returns a new <see cref="Simulation">simulation</see> with the provided
         * input parameters.</summary>
         */
        public Simulation simulate(Properties cropData, SimulationData simulationData);
    }
}