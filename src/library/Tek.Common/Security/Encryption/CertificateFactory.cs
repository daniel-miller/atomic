﻿using System;
using System.Security.Cryptography.X509Certificates;

namespace Tek.Common.Security
{
    public static class CertificateFactory
    {
        public static X509Certificate2 Create(string encoded, string password)
        {
            var decoded = Convert.FromBase64String(encoded);

            var certificate = new X509Certificate2(decoded, password);

            return certificate;
        }
    }
}
