using AquaSharp.data;
using AquaSharp.utils;

namespace AquaSharp.features {
    /**<summary>Simulation feature used to calculate the <see cref="AerationStressCoefficient"/>.</summary>*/
    public class AerationStressFeature : SimulationFeature {
        public void step(Properties crop, SimulationData simulation, Properties output) {
            var coefficient = AerationStressCoefficient.calculateCoefficient(
                RootZoneWater.ActualWaterContent.from(simulation.environment),
                RootZoneWater.WaterContentAtStressThreshold.from(simulation.environment),
                RootZoneWater.WaterContentAtSaturation.from(simulation.environment),
                SimulationEnvironment.AerationDays.from(simulation.environment),
                CropAeration.AerationStuntThreshold.from(simulation.environment),
                out var aerationDays
            );

            output.setProperty(SimulationEnvironment.AerationDays, aerationDays);
            output.setProperty(CropAeration.AerationStressCoefficient, coefficient);
        }
    }
}