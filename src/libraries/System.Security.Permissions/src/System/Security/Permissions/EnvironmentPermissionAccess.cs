// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace System.Security.Permissions
{
    [Flags]
    public enum EnvironmentPermissionAccess
    {
        AllAccess = 3,
        NoAccess = 0,
        Read = 1,
        Write = 2,
    }
}
