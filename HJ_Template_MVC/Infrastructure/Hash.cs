using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Infrastructure
{
    public class Hash
    {
        public Hash() : base()
        {

        }
        public string GetCreateHash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = MD5.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }
        public string GetReadHash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algorithm = new SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            return Convert.ToBase64String(hashBytes);
        }
    }
}