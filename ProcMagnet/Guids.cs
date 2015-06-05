// Guids.cs
// MUST match guids.h
using System;

namespace Company.ProcMagnet
{
    static class GuidList
    {
        public const string guidProcMagnetPkgString = "4d59b076-6a56-4ad6-a2ed-81f3a8df0454";
        public const string guidProcMagnetCmdSetString = "27b790a0-43d4-4c9c-9f53-48b18a054478";
        public const string guidToolWindowPersistanceString = "6c2bf2ea-dc69-43ff-a597-c695ac18340f";

        public static readonly Guid guidProcMagnetCmdSet = new Guid(guidProcMagnetCmdSetString);
    };
}