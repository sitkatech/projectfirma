using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace LtInfo.Common.Security
{
    public class PasswordSaltAndHash
    {
        public string PasswordSalt;
        public string PasswordHashed;

        public PasswordSaltAndHash(string passwordSalt, string passwordHashed)
        {
            PasswordSalt = passwordSalt;
            PasswordHashed = passwordHashed;
        }
    }

    // Lifted from Keystone. (Also closely resembles
    // Gemini's code, but this is the specific code from Keystone.)
    // -- SLG 03/17/2021

    /// <summary>
    ///     Salted password hashing with PBKDF2-SHA1.
    ///     Author: havoc AT defuse.ca
    ///     www: http://crackstation.net/hashing-security.htm
    ///     Compatibility: .NET 3.0 and later.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public static class PBKDF2PasswordHash
    {
        // The following constants may be changed without breaking existing hashes.
        public const int SALT_BYTE_SIZE = 32;
        public const int HASH_BYTE_SIZE = 32;
        public const int PBKDF2_ITERATIONS = 10000;

        public const int ITERATION_INDEX = 0;
        public const int SALT_INDEX = 1;
        public const int PBKDF2_INDEX = 2;

        /// <summary>
        ///     Creates a salted PBKDF2 hash of the password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>The hash of the password.</returns>
        public static PasswordSaltAndHash CreateHash(string password)
        {
            // Generate a random salt
            var csprng = new RNGCryptoServiceProvider();
            var salt = new byte[SALT_BYTE_SIZE];
            csprng.GetBytes(salt);

            // Hash the password and encode the parameters
            var hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
            var passwordSaltAndHash = new PasswordSaltAndHash(string.Format("{0}:{1}", PBKDF2_ITERATIONS, Convert.ToBase64String(salt)), Convert.ToBase64String(hash));
            return passwordSaltAndHash;
        }

        /// <summary>
        ///     Creates a salted PBKDF2 hash of the password.
        /// </summary>
        /// <param name="iterationsAndSalt">the salt of the password.</param>
        /// <param name="password">The password to check.</param>
        /// <param name="correctHash">A hash of the correct password.</param>
        /// <returns>True if the password is correct. False otherwise.</returns>
        public static bool ValidatePassword(string iterationsAndSalt, string password, string correctHash)
        {
            // Extract the parameters from the hash
            char[] delimiter = { ':' };
            var split = iterationsAndSalt.Split(delimiter);
            var iterations = Int32.Parse(split[ITERATION_INDEX]);
            var salt = Convert.FromBase64String(split[SALT_INDEX]);
            var hash = Convert.FromBase64String(correctHash);

            var testHash = PBKDF2(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }

        /// <summary>
        ///     Validates a password given a hash of the correct one.
        /// </summary>
        /// <param name="password">The password to check.</param>
        /// <param name="correctHash">A hash of the correct password.</param>
        /// <returns>True if the password is correct. False otherwise.</returns>
        public static bool ValidatePassword(string password, string correctHash)
        {
            // Extract the parameters from the hash
            char[] delimiter = { ':' };
            var split = correctHash.Split(delimiter);
            var iterations = Int32.Parse(split[ITERATION_INDEX]);
            var salt = Convert.FromBase64String(split[SALT_INDEX]);
            var hash = Convert.FromBase64String(split[PBKDF2_INDEX]);

            var testHash = PBKDF2(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }

        /// <summary>
        ///     Compares two byte arrays in length-constant time. This comparison
        ///     method is used so that password hashes cannot be extracted from
        ///     on-line systems using a timing attack and then attacked off-line.
        /// </summary>
        /// <param name="a">The first byte array.</param>
        /// <param name="b">The second byte array.</param>
        /// <returns>True if both byte arrays are equal. False otherwise.</returns>
        private static bool SlowEquals(IList<byte> a, IList<byte> b)
        {
            var diff = (uint)a.Count ^ (uint)b.Count;
            for (var i = 0; i < a.Count && i < b.Count; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }

        /// <summary>
        ///     Computes the PBKDF2-SHA1 hash of a password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="iterations">The PBKDF2 iteration count.</param>
        /// <param name="outputBytes">The length of the hash to generate, in bytes.</param>
        /// <returns>A hash of the password.</returns>
        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }
    }
}

/*
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace LtInfo.Common.Security
{
    /// <summary>
    ///     Salted password hashing with PBKDF2-SHA1.
    ///     Author: havoc AT defuse.ca
    ///     www: http://crackstation.net/hashing-security.htm
    ///     Compatibility: .NET 3.0 and later.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class PBKDF2PasswordHash : IPasswordHash
    {
        // The following constants may be changed without breaking existing hashes.
        public const int SALT_BYTE_SIZE = 32;
        public const int HASH_BYTE_SIZE = 32;
        public const int PBKDF2_ITERATIONS = 10000;

        public const int ITERATION_INDEX = 0;
        public const int SALT_INDEX = 1;
        public const int PBKDF2_INDEX = 2;

        string IPasswordHash.CreateHash(string password)
        {
            return PBKDF2PasswordHash.CreateHash(password);
        }

        bool IPasswordHash.ValidatePassword(string password, string correctHash)
        {
            return PBKDF2PasswordHash.ValidatePassword(password, correctHash);
        }

        /// <summary>
        ///     Creates a salted PBKDF2 hash of the password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>The hash of the password.</returns>
        public static string CreateHash(string password)
        {
            // Generate a random salt
            var csprng = new RNGCryptoServiceProvider();
            var salt = new byte[SALT_BYTE_SIZE];
            csprng.GetBytes(salt);

            // Hash the password and encode the parameters
            var hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
            return PBKDF2_ITERATIONS + ":" + Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
        }

        /// <summary>
        ///     Validates a password given a hash of the correct one.
        /// </summary>
        /// <param name="password">The password to check.</param>
        /// <param name="correctHash">A hash of the correct password.</param>
        /// <returns>True if the password is correct. False otherwise.</returns>
        public static bool ValidatePassword(string password, string correctHash)
        {
            // Extract the parameters from the hash
            char[] delimiter = { ':' };
            var split = correctHash.Split(delimiter);
            var iterations = Int32.Parse(split[ITERATION_INDEX]);
            var salt = Convert.FromBase64String(split[SALT_INDEX]);
            var hash = Convert.FromBase64String(split[PBKDF2_INDEX]);

            var testHash = PBKDF2(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }

        /// <summary>
        ///     Compares two byte arrays in length-constant time. This comparison
        ///     method is used so that password hashes cannot be extracted from
        ///     on-line systems using a timing attack and then attacked off-line.
        /// </summary>
        /// <param name="a">The first byte array.</param>
        /// <param name="b">The second byte array.</param>
        /// <returns>True if both byte arrays are equal. False otherwise.</returns>
        private static bool SlowEquals(IList<byte> a, IList<byte> b)
        {
            var diff = (uint)a.Count ^ (uint)b.Count;
            for (var i = 0; i < a.Count && i < b.Count; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }

        /// <summary>
        ///     Computes the PBKDF2-SHA1 hash of a password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="iterations">The PBKDF2 iteration count.</param>
        /// <param name="outputBytes">The length of the hash to generate, in bytes.</param>
        /// <returns>A hash of the password.</returns>
        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }
    }
}
*/