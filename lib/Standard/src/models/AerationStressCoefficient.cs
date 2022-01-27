using System;

namespace AquaSharp.features {
    /**
     * <summary>Modelling class providing a <see cref="calculateCoefficient">method</see> to calculate the Aeration
     * Stress coefficient.</summary>
     */
    public static class AerationStressCoefficient {
        /**
         * <summary>Calculates and returns the Aeration Stress Coefficient for the given input parameters.</summary>
         * 
         * <param name="actualWaterContent">Actual root zone water content (in m3/m3). Corresponds to the
         * <c>RootZoneWater.Act</c> field in the original implementation.</param>
         * <param name="contentAtStressThreshold">Root zone water content at the aeration stress threshold (in m3/m3).
         * Corresponds to the <c>RootZoneWater.Aer</c> field in the original implementation.</param>
         * <param name="contentAtSaturation">Root zone water content at saturation point (in m3/m3). Corresponds
         * to the <c>RootZoneWater.Sat</c> field in the original implementation.</param>
         * <param name="stuntThresholdDays">Number of days before aeration stress stunts crop growth. Corresponds
         * to the <c>Crop.LagAer</c> field in the original implementation.</param>
         * <param name="refAerationDays">Number of aeration days. Corresponds to the <c>ModelState.AerDays</c> field in the
         * original implementation.</param>
         * <param name="finalAerationDays">When this method returns, the referenced value
         * is updated as follows: if no aeration stress is present, it is set to zero, otherwise, it is incremented and
         * clamped to the value of <c>stuntThresholdDays</c>. Semantically, this is the same as <c>refAerationDays</c>.</param>
         * 
         * <returns>The Aeration Stress coefficient for the given parameters.</returns>
         */
        public static double calculateCoefficient(
            double actualWaterContent,
            double contentAtStressThreshold,
            double contentAtSaturation,
            double stuntThresholdDays,
            double refAerationDays,
            out double finalAerationDays
        ) {
            if (actualWaterContent <= contentAtStressThreshold) {
                // Reset aeration days counter
                finalAerationDays = 0;

                // No stress, return a coefficient of 1
                return 1;
            }

            // Calculate the aeration stress coefficient
            double coefficient;
            if (refAerationDays < stuntThresholdDays) {
                double stress = 1 -
                                (contentAtSaturation - actualWaterContent) /
                                (contentAtSaturation - contentAtStressThreshold);

                coefficient = 1 - refAerationDays / 3 * stress;
            } else {
                coefficient = (contentAtSaturation - actualWaterContent) /
                              (contentAtSaturation - contentAtStressThreshold);
            }

            // Increment aeration counter, clamped to the growth stunt threshold
            finalAerationDays = Math.Min(refAerationDays + 1, stuntThresholdDays);

            return coefficient;
        }
    }
}