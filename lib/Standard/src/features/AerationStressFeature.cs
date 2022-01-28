using AquaSharp.data;
using AquaSharp.utils;

namespace AquaSharp.features {
    /**<summary>Simulation feature used to calculate the <see cref="AerationStressCoefficient"/>.</summary>*/
    public class AerationStressFeature : SimulationFeature {
        public void step(Properties crop, SimulationData simulation, Properties output) {
            var coefficient = AerationStressCoefficient.calculateCoefficient(
                actualWaterContent: RootZoneWater.ActualWaterContent.of(simulation.environment), 
                contentAtStressThreshold: RootZoneWater.WaterContentAtStressThreshold.of(simulation.environment),
                contentAtSaturation: RootZoneWater.WaterContentAtSaturation.of(simulation.environment),
                refAerationDays: SimulationEnvironment.AerationDays.of(simulation.environment),
                stuntThresholdDays: CropAeration.AerationStuntThreshold.of(simulation.environment),
                finalAerationDays: out var aerationDays
            );

            output.setProperty(SimulationEnvironment.AerationDays, aerationDays);
            output.setProperty(CropAeration.AerationStressCoefficient, coefficient);
        }
    }
}