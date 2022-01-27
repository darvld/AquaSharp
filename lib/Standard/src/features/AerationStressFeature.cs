using AquaSharp.data;


namespace AquaSharp.features {
    /**<summary>Simulation feature used to calculate the <see cref="AerationStressCoefficient"/>.</summary>*/
    public class AerationStressFeature : SimulationFeature {
        public void step(Properties crop, SimulationData simulation, Properties output) {
            var coefficient = AerationStressCoefficient.calculateCoefficient(
                simulation.environment.getProperty(RootZoneWater.ActualWaterContent),
                simulation.environment.getProperty(RootZoneWater.WaterContentAtStressThreshold),
                simulation.environment.getProperty(RootZoneWater.WaterContentAtSaturation),
                simulation.environment.getProperty(SimulationEnvironment.AerationDays),
                crop.getProperty(CropAeration.AerationStuntThreshold),
                out var aerationDays
            );
            
            output.setProperty(SimulationEnvironment.AerationDays, aerationDays);
            output.setProperty(CropAeration.AerationStressCoefficient, coefficient);
        }
    }
}