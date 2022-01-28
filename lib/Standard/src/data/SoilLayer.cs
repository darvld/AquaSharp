namespace AquaSharp.data {
    public class SoilLayer {
        public readonly double depth;
        public readonly double thickness;
        public readonly Properties properties;
        
        public SoilLayer(double depth, double thickness, Properties properties) {
            this.depth = depth;
            this.thickness = thickness;
            this.properties = properties;
        }
    }
}