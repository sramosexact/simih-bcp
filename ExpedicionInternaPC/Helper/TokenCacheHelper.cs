using Microsoft.Identity.Client;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;

namespace ExpedicionInternaPC.Helper
{
    static class TokenCacheHelper
    {
        public static readonly string CacheFilePath = $"{Assembly.GetExecutingAssembly().Location}.msalcache.bin3";

        public static readonly object FileLock = new object();

        public static void BeforeAccessNotification(TokenCacheNotificationArgs args)
        {
            lock (FileLock)
            {
                args.TokenCache.DeserializeMsalV3(File.Exists(CacheFilePath)
                    ? ProtectedData.Unprotect(File.ReadAllBytes(CacheFilePath), null, DataProtectionScope.CurrentUser)
                    : null);
            }
        }

        public static void AfterAccessNotificacion(TokenCacheNotificationArgs args)
        {
            //if the access operation resulted in a cache update
            if (args.HasStateChanged)
            {
                lock (FileLock)
                {
                    File.WriteAllBytes(CacheFilePath,
                        ProtectedData.Protect(args.TokenCache.SerializeMsalV3(),
                        null, DataProtectionScope.CurrentUser));
                }
            }
        }

        internal static void EnableSerialization(ITokenCache tokenCache)
        {
            tokenCache.SetBeforeAccess(BeforeAccessNotification);
            tokenCache.SetAfterAccess(AfterAccessNotificacion);
        }
    }
}
