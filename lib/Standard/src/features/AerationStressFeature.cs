using AquaSharp.data;
using AquaSharp.utils;

namespace AquaSharp.features {
    /**<summary>Simulation feature used to calculate the <see cref="AerationStressCoefficient"/>.</summary>*/
    public class AerationStressFeature : SimulationFeature {
        public void step(Properties crop, SimulationData simulation, Properties output) {
            var coefficient = AerationStressCoefficient.calculateCoefficient(
                RootZoneWater.ActualWaterContent.of(simulation.environment),
                RootZoneWater.WaterContentAtStressThreshold.of(simulation.environment),
                RootZoneWater.WaterContentAtSaturation.of(simulation.environment),
                SimulationEnvironment.AerationDays.of(simulation.environment),
                CropAeration.AerationStuntThreshold.of(simulation.environment),
                out var aerationDays
            );

            output.setProperty(SimulationEnvironment.AerationDays, aerationDays);
            output.setProperty(CropAeration.AerationStressCoefficient, coefficient);
        }
    }
}