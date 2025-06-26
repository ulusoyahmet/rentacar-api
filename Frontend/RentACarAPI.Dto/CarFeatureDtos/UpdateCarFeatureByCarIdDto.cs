namespace RentACarAPI.Dto.CarFeatureDtos
{
    public class UpdateCarFeatureByCarIdDto
    {
        public int CarFeatureID { get; set; }
        public int CarID { get; set; }
        public int FeatureID { get; set; }
        public bool Available { get; set; }
    }
}
