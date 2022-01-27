namespace AquaSharp {
    /**
     * <summary>Encapsulates a simulation set up by a specific <see cref="AquaCropEngine">engine</see>. Advance the simulation
     * by calling <see cref="step"/></summary>
     */
    public interface CropSimulation {
        /**
         * <summary>Whether the simulation has completed. If <c>true</c>, calling <see cref="step"/> will have
         * no effect and will always return <c>false</c></summary>
         */
        public bool isFinished { get; }

        /**
         * <summary>Performs a step in the simulation.</summary>
         * <returns><code>true</code> if more steps can be performed, <code>false</code> if the simulation has ended.</returns>
         */
        public bool step();
    }
}