using AquaSharp.features;
using NUnit.Framework;

namespace AquaSharp.test {
    public class AerationStressCoefficientTest {
        [Test]
        public void matches_matlab_impl() {
            // setup inputs according to the matlab example
            const double actualWaterContent = 0.3962; // Act
            const double contentAtStressThreshold = 0.3600; // Aer
            const double contentAtSaturation = 0.4100; // Sat
            const double stuntThresholdDays = 3; // LagAer
            const double refAerationDays = 0; // AerDays

            // calculate using matlab inputs
            double calculatedCoefficient = AerationStressCoefficient.calculateCoefficient(
                actualWaterContent,
                contentAtStressThreshold,
                contentAtSaturation,
                refAerationDays,
                stuntThresholdDays,
                // secondary output (AerDays)
                out var finalAerationDays
            );

            // check result against matlab implementation
            Assert.That(finalAerationDays, Is.EqualTo(1));
            Assert.That(calculatedCoefficient, Is.EqualTo(1));
        }
    }
}