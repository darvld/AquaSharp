using AquaSharp.data;
using AquaSharp.utils;

namespace AquaSharp.features {
    public class PreIrrigationFeature : SimulationFeature {
        public void step(Properties crop, SimulationData simulation, Properties output) {
            var method = IrrigationManagement.IrrigationMethod.of(simulation.environment);

            if (
                method != IrrigationManagement.CropIrrigationMethod.NetIrrigation ||
                CropTimers.DaysAfterPlanting.of(simulation.environment) != 1
            ) {
                // No pre-irrigation as not in net irrigation mode or not on first day of the growing season
                output.setProperty(IrrigationManagement.PreIrrigation, 0);
                return;
            }

            var waterContent = SimulationEnvironment.WaterContent.of(simulation.environment);

            var preIrrigation = PreIrrigation.calculatePreIrrigation(
                rootZoneDepth: SimulationEnvironment.RootingDepth.of(simulation.environment),
                cropMinRootDepth: CropRooting.MinRootDepth.of(crop),
                netIrrigationFactor: IrrigationManagement.NetIrrigationFactor.of(simulation.environment),
                waterContent: ref waterContent,
                compartmentLayers: SimulationEnvironment.SoilLayers.of(simulation.environment)
            );

            output.setProperty(SimulationEnvironment.WaterContent, waterContent);
            output.setProperty(IrrigationManagement.PreIrrigation, preIrrigation);
        }
    }
}