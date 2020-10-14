using System;

namespace WebApplication1.Module
{
    public class CustomSerializer
    {
        #region Properties

        public string VehicleNumber { get; set; }
        public string VehicleType { get; set; }
        public string ChassisNumber { get; set; }
        public string EngineNumber { get; set; }
        public DateTime ManufacturingYear { get; set; }
        public string MakeofVehicle { get; set; }
        public string ModelNumber { get; set; }
        public string BodyType { get; set; }
        public string OrganisationName { get; set; }
        public int DeviceID { get; set; }
        public long UserID { get; set; }

        public int Offset { get; set; }
        public int Max { get; set; }


        #endregion Properties
    }
}
