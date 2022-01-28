namespace AquaSharp.data {
    /**<summary>Defines properties used to define the irrigation model for a simulation.</summary>*/
    public static class IrrigationManagement {
        /**<summary>Enumerates irrigation methods available for simulation.</summary>*/
        public enum CropIrrigationMethod {
            Rainfed,
            SoilMoisture,
            FixedInterval,
            TimeSeries,
            NetIrrigation
        }

        /**<summary>The <see cref="CropIrrigationMethod">irrigation method</see> used for the simulation.</summary>*/
        public static readonly PropertyKey<CropIrrigationMethod> IrrigationMethod = new();

        /**<summary>Percentage of total available water to retain when in net irrigation mode.</summary>*/
        public static readonly PropertyKey<double> NetIrrigationFactor = new();
        
        /**<summary>Pre-irrigation computed during the simulation.</summary>*/   
        public static readonly PropertyKey<double> PreIrrigation = new();
    }
}