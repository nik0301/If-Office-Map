using System;
using If.Lync;
using Microsoft.Extensions.Configuration;

namespace OfficeMap.Lync
{
    public class Config
    {
        public LyncManager LyncManager { get; }

        private Config(LyncManager lyncManager)
        {
            LyncManager = lyncManager;
        }

        public static Config Load(IConfiguration configuration)
        {
            var lyncSection = configuration.GetSection("Lync");

            var user = lyncSection["User"];
            var password = lyncSection["Password"];

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("");
            }

            return new Config(new LyncManager(user, password));
        }
    }
}
