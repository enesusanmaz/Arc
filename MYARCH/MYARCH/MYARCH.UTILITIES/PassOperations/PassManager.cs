using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MYARCH.UTILITIES.PassOperations
{
    public class PassManager
    {
        public static string Base64Encrypt(string data)
        {
            try
            {
                byte[] dataByteArray = System.Text.ASCIIEncoding.ASCII.GetBytes(data);
                string encryptedData = System.Convert.ToBase64String(dataByteArray);
                return encryptedData;
            }
            catch (Exception)
            {
                return data;
            }
        }

        public static string Base64Decrypt(string descryptData)
        {
            try
            {
                byte[] descryptDataArray = System.Convert.FromBase64String(descryptData);
                string originalData = System.Text.ASCIIEncoding.ASCII.GetString(descryptDataArray);
                return originalData;
            }
            catch (Exception)
            {
                return descryptData;
            }
        }
    }

}
