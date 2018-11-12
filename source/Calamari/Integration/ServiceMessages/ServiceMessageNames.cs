﻿namespace Calamari.Integration.ServiceMessages
{
    public class ServiceMessageNames
    {
        public static class SetVariable
        {
            public const string Name = "setVariable";
            public const string NameAttribute = "name";
            public const string ValueAttribute = "value";            
        }

        public static class CalamariFeatureRequired
        {
            public const string Name = "calamari-feature-required";
            public const string Feature = "feature";
            public const string Target = "target";
        }

        public static class CalamariFoundPackage
        {
            public const string Name = "calamari-found-package";
        }

        public static class FoundPackage
        {
            public const string Name = "foundPackage";
            public const string IdAttribute = "id";
            public const string VersionAttribute = "version";
            public const string HashAttribute = "hash";
            public const string RemotePathAttribute = "remotePath";
        }

        public static class PackageDeltaVerification
        {
            public const string Name = "deltaVerification";
            public const string RemotePathAttribute = "remotePath";
            public const string HashAttribute = "hash";
            public const string SizeAttribute = "size";
        }
    }
}