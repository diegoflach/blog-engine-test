namespace BlogEngineApi.Domain.Statics
{
    public class Message
    {
        public static string AccountLockedOut = "Your account is locked out. Try again in @Minutes minutes.";
        public static string IncorrectPassword = "Incorrect password.";
        public static string InvalidAccount = "Invalid account. Username/email provided is not from a valid account.";
        public static string InvalidEmailAddress = "Invalid email address.";
        public static string InvalidLoginAttempt = "Either your email address or your password is incorrect. Please try again.";
        public static string TokenExpiredOrAlreadyUsed = "This link is expired or was already used to set this account password.";
        public static string TwoFactorIsRequired = "Two Factor Authorization is required.";
        public static string UnknownError = "Unknown error.";
        public static string UserNotAllowedToSignIn = "Either your email address or your password is incorrect. Please try again.";
    }
}