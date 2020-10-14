using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Module
{
    public class PagesLite
    {
        #region Properties

        public string VehicleNumber { get; set; }
        public string VehicleType { get; set; }
        public string ChassisNumber { get; set; }
        public string EngineNumber {get;set;}
        public string ManufacturingYear { get; set; }
        public string MakeofVehicle { get; set; }
        public string ModelNumber { get; set; }
        public string BodyType { get; set; }
        public string OrganisationName { get; set; }
        public int DeviceID { get; set; }
        public long UserID { get; set; }

       


        #endregion Properties

        #region VList

        public static dynamic GetVehiclsList(string prms)
        {
            #region Prerequisites          

            // Decode prms and mapping with custom serializer.
            CustomSerializer serializer = JsonConvert.DeserializeObject<CustomSerializer>(Methods.PrmsBase64Decode(prms));
            return GetList(serializer);

            #endregion Prerequisites
        }


        #endregion VList

        private static List<object> GetList(CustomSerializer serializer)
        {
            #region Functionality
            using (SqlConnection con = new SqlConnection("DefaultConnection"))
            {
                using (SqlCommand cmd = new SqlCommand("GetVehiclsList", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Offset", SqlDbType.VarChar).Value = serializer.Offset;
                    cmd.Parameters.Add("@Max", SqlDbType.VarChar).Value = serializer.Max;
                    cmd.Parameters.Add("@VehicleType", SqlDbType.VarChar).Value = serializer.VehicleType;
                    con.Open();                   
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {                                                
                        List<object> Vlist = new List<object>();
                        long total = 0;

                        while (reader.Read())
                        total = Methods.GetInt64FromReader(reader, "Total");
                        Vlist.Add(new PagesLite(reader));                      
                        return Vlist;
                    }
                }
            }
            #endregion Functionality   
        }

        public PagesLite(SqlDataReader reader)
        {
            VehicleNumber = Methods.GetStringFromReader(reader, "VehicleNumber");
            VehicleType= Methods.GetStringFromReader(reader, "VehicleType");
            ChassisNumber = Methods.GetStringFromReader(reader, "ChassisNumber");
            EngineNumber= Methods.GetStringFromReader(reader, "EngineNumber");
            ManufacturingYear= Methods.GetStringFromReader(reader, "ManufacturingYear");
            MakeofVehicle = Methods.GetStringFromReader(reader, "MakeofVehicle");
            ModelNumber= Methods.GetStringFromReader(reader, "ModelNumber");
            BodyType= Methods.GetStringFromReader(reader, "BodyType");
            OrganisationName = Methods.GetStringFromReader(reader, "OrganisationName");
            DeviceID = Methods.GetInt32FromReader(reader, "DeviceID");
            UserID = Methods.GetInt64FromReader(reader, "UserID");
        }

    }
}
