namespace AquaSharp {
    /**
     * <summary>Marker interface implemented by each algorithm (step) in a simulation.</summary>
     */
    public interface SimulationFeature {
        /**
         * <summary>Performs a single-step calculation with the given input and writes the result to the output.</summary>
         */
        public void step(Properties crop, SimulationData simulation, Properties output);
    }
}