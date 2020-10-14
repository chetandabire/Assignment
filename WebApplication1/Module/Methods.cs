using System;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Text;

namespace WebApplication1.Module
{
    public sealed class Methods
    {
        public static string PrmsBase64Decode(string base64EncodedData)
        {
            #region Functionality
                       

            // To Decode replace Space by (+) sign to avoid spaces in Encoded String.
            base64EncodedData = base64EncodedData.Replace(" ", "+");

            // Base 64 always has length in multiple of 4 (Blocks of 4).
            int mod4 = base64EncodedData.Length % 4;

            if (mod4 > 0)
            {
                base64EncodedData += new string('=', 4 - mod4);
            }

            // Convert into byte array.
            byte[] base64EncodedBytes = Convert.FromBase64String(base64EncodedData);

            // Return string created using byte array.
            //PrmsBase64Decode(base64EncodedData);

            return Encoding.UTF8.GetString(base64EncodedBytes);

            #endregion Functionality
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string GetStringFromReader(SqlDataReader reader, string fieldName)
        {
            try
            {
                int ordinal = reader.GetOrdinal(fieldName);

                if (reader.IsDBNull(ordinal) == false)
                    return Convert.ToString(reader.GetValue(ordinal));
                return null;
            }
            catch
            {
                return null;
            }
        }
        #region Get Int64 From Reader        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long GetInt64FromReader(SqlDataReader reader, string fieldName)
        {
            try
            {
                int ordinal = reader.GetOrdinal(fieldName);

                if (reader.IsDBNull(ordinal) == false)
                    return Convert.ToInt64(reader.GetValue(ordinal));
                else
                    return 0;
            }

            catch
            {
                return 0;
            }
        }

        #endregion Get Int64 From Reader

        #region Get Int32 From Reader

        /// <summary>
        /// Returns <see cref="int"/> value of a specified field from <see cref="SqlDataReader"/>
        /// and If exception occurs or field not exists returns 0 .
        /// </summary>
        /// <param name="reader">instance of <see cref="SqlDataReader"/></param>
        /// <param name="fieldName">column name</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int GetInt32FromReader(SqlDataReader reader, string fieldName)
        {
            try
            {
                int ordinal = reader.GetOrdinal(fieldName);

                if (reader.IsDBNull(ordinal) == false)
                    return Convert.ToInt32(reader.GetValue(ordinal));
                else
                    return 0;
            }

            catch
            {
                return 0;
            }
        }

        #endregion Get Int32 From Reader
    }
}
