using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;

namespace WebApplication1.Module
{
    public class UserLite
    {
        #region Properties

        public long UserID { get; set; }

        public string Name { get; set; }

        public string MobileNumber { get; set; }

        public string Organization { get; set; }

        public string Address { get; set; }

        public string EmailAddress { get; set; }

        public string Location { get; set; }

        public string Photopath { get; set; }

        #endregion Properties

        #region UserPost
        public static string Post(UserLite user, out int statusCode)
        {
            string scopeKey = null;
            statusCode = StatusCodes.Status400BadRequest;

            if (user == null)
                return scopeKey;

            // Insert record into database.
            scopeKey = user.Insert(user);
            return scopeKey;
        }
        #endregion UserPost

        #region InsertUser
        private string Insert(UserLite user)
        {
            try
            {
                #region Functionality
                string scopeKey = "201";
                long UserID = user.UserID;
                string Name = user.Name;
                string MobileNumber = user.MobileNumber;
                string Organization = user.Organization;
                string Address = user.Address;
                string EmailAddress = user.EmailAddress;
                string Location = user.Location;
                string Photopath = user.Photopath;

                SqlConnection sqlConnection1 = new SqlConnection("DefaultConnection");

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT into User (UserID,Name,MobileNumber,Organization,Address,EmailAddress,Location,Photopath) VALUES (" + UserID + "," + Name + "," + MobileNumber + "," + Organization + "," + Address + "," + EmailAddress + "," + Location + "," + Photopath + ")";
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
                return scopeKey;
                #endregion Functionality
            }
            catch (SqlException ex)
            {
                return "Data not inserted !" + ex;
            }

            
        }
        #endregion InsertUser

        #region UserPut
        public static string Update(UserLite user, out int statusCode)
        {
            string scopeKey = null;
            statusCode = StatusCodes.Status400BadRequest;

            if (user == null)
                return scopeKey;

            // Insert record into database.
            scopeKey = user.Update(user);
            return scopeKey;
        }
        #endregion UserUpdate

        #region UpdateUser
        private string Update(UserLite user)
        {
            try
            {
                #region Functionality
                string scopeKey = "201";
                long UserID = user.UserID;
                string Name = user.Name;
                string MobileNumber = user.MobileNumber;
                string Organization = user.Organization;
                string Address = user.Address;
                string EmailAddress = user.EmailAddress;
                string Location = user.Location;
                string Photopath = user.Photopath;

                SqlConnection sqlConnection1 = new SqlConnection("DefaultConnection");

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "update User set Name=" + Name + ",MobileNumber=" + MobileNumber + ",Organization=" + Organization + ",Address=" + Address + ",EmailAddress=" + EmailAddress + ",Location=" + Location + ",Photopath=" + Photopath + " Where UserID=" + UserID + "";
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
                return scopeKey;
                #endregion Functionality
            }
            catch (SqlException ex)
            {
                return "Data not inserted !" + ex;
            }


        }
        #endregion UpdateUser
    }
}
