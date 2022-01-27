using AquaSharp.data;

namespace AquaSharp.features {
    /**<summary>Simulation feature used to calculate the <see cref="AerationStressCoefficient"/>.</summary>*/
    public class AerationStressFeature : SimulationFeature {
        public void step(Properties crop, SimulationData simulation, Properties output) {
            AerationStressCoefficient.calculateCoefficient(
                simulation.environment.getProperty(RootZoneWater.ActualWaterContent),
                simulation.environment.getProperty(RootZoneWater.WaterContentAtStressThreshold),
                simulation.environment.getProperty(RootZoneWater.WaterContentAtSaturation),
                crop.getProperty(CropAeration.AerationStuntThreshold),
                simulation.environment.getProperty(SimulationEnvironment.AerationDays),
                out var aerationDays
            );
            
            output.setProperty(SimulationEnvironment.AerationDays, aerationDays);
        }
    }
}