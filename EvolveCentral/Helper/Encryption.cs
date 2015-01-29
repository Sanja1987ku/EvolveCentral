using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace EvolveCentral.Helper
{
    public static class Encryption
    {

        public static string Encrypt(string password)
        {
            string retval = null;

            MD5CryptoServiceProvider md5hasher = new MD5CryptoServiceProvider();
            Byte[] hashedBytes = null;
            UTF8Encoding encoder = new UTF8Encoding();
            hashedBytes = md5hasher.ComputeHash(encoder.GetBytes(password));
            retval = Convert.ToBase64String(hashedBytes);

            return retval;
        }

    }
}