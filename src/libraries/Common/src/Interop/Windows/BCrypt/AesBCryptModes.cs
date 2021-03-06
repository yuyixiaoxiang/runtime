// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Security.Cryptography;
using Internal.NativeCrypto;

namespace Internal.Cryptography
{
    internal static class AesBCryptModes
    {
        private static readonly SafeAlgorithmHandle s_hAlgCbc = OpenAesAlgorithm(Cng.BCRYPT_CHAIN_MODE_CBC);
        private static readonly SafeAlgorithmHandle s_hAlgEcb = OpenAesAlgorithm(Cng.BCRYPT_CHAIN_MODE_ECB);

        internal static SafeAlgorithmHandle GetSharedHandle(CipherMode cipherMode) =>
            // Windows 8 added support to set the CipherMode value on a key,
            // but Windows 7 requires that it be set on the algorithm before key creation.
            cipherMode switch
            {
                CipherMode.CBC => s_hAlgCbc,
                CipherMode.ECB => s_hAlgEcb,
                _ => throw new NotSupportedException(),
            };

        internal static SafeAlgorithmHandle OpenAesAlgorithm(string cipherMode)
        {
            SafeAlgorithmHandle hAlg = Cng.BCryptOpenAlgorithmProvider(Cng.BCRYPT_AES_ALGORITHM, null, Cng.OpenAlgorithmProviderFlags.NONE);
            hAlg.SetCipherMode(cipherMode);

            return hAlg;
        }
    }
}
