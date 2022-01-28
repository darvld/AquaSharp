using System;
using System.Collections.Generic;
using AquaSharp.data;
using AquaSharp.utils;

namespace AquaSharp.features {
    public static class PreIrrigation {
        /**
         * <summary>Calculates pre-irrigation value based on the provided input when in net irrigation mode.</summary>
         * 
         * <param name="rootZoneDepth">Depth of the roots for the compartment.</param>
         * <param name="cropMinRootDepth">Minimum effective rooting depth for the evaluated crop.</param>
         * <param name="netIrrigationFactor">Percentage of total available water to retain when in net irrigation mode.</param>
         * <param name="waterContent">Current water content of the compartment. Updated during the calculation.</param>
         * <param name="compartmentLayers">Layer composition of the compartment.</param>
         *
         * <returns>Pre-irrigation value.</returns>
         */
        public static double calculatePreIrrigation(
            double rootZoneDepth,
            double cropMinRootDepth,
            double netIrrigationFactor,
            ref double waterContent,
            List<SoilLayer> compartmentLayers
        ) {
            // TODO: when calling, make sure this is the first day of the simulation and irrigation method is not set to NetCalculation.

            // Determine compartments covered by the root zone
            var rootDepth = Math.Max(rootZoneDepth, cropMinRootDepth);
            rootDepth = Math.Round(rootDepth * 100, MidpointRounding.AwayFromZero) / 100;

            var coveredCompartments = compartmentLayers.FindIndex(layer => layer.depth >= rootDepth);

            // Calculate pre-irrigation requirements
            double preIrrigation = 0;
            for (var i = 0; i <= coveredCompartments; i++) {
                var currentLayer = compartmentLayers[i];

                var wiltingPointWater = SoilHydrology.WaterContentAtWilting.from(currentLayer.properties);
                var fieldCapacityWater = SoilHydrology.WaterContentAtCapacity.from(currentLayer.properties);

                var threshold = wiltingPointWater +
                                netIrrigationFactor / 100 * (fieldCapacityWater - wiltingPointWater);

                if (waterContent < threshold) {
                    preIrrigation += (threshold - waterContent) * 1_000 * currentLayer.thickness;
                    waterContent = threshold;
                }
            }

            return preIrrigation;
        }
    }
}