namespace LtInfo.Common.Security
{
    /// <summary>
    /// If you create an implementer of this class please add it to PasswordHashTest.  Feel free to use an explicit interface, ie the actual method is done in a static, just as the
    /// current 2 implementers do.
    /// </summary>
    public interface IPasswordHash
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>The hash of the password.</returns>
        string CreateHash(string password);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password">The password to check.</param>
        /// <param name="correctHash">A hash of the correct password.</param>
        /// <returns>True if the password is correct. False otherwise.</returns>
        bool ValidatePassword(string password, string correctHash);
    }
}