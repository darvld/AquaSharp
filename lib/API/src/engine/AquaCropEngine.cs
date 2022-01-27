namespace AquaSharp {
    /**
     * <summary>Base contract used to obtain a <see cref="CropSimulation">simulation</see> implementation
     * from initial data.</summary>
     *
     * <seealso cref="simulate"/>
     */
    public interface AquaCropEngine {
        /**
         * <summary>Initializes and returns a new <see cref="CropSimulation">simulation</see> with the provided
         * input parameters.</summary>
         */
        public CropSimulation simulate(CropData cropData, SimulationData simulationData);
    }
}