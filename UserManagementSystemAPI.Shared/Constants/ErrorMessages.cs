namespace UserManagementSystemAPI.Shared.Constants
{
    public class ErrorMessages
    {
        public static readonly string Error = "Error";
        public static readonly string EntityNotFound = "EntityNotFound";
        public static readonly string UsernameAlreadyExists = "UsernameAlreadyExists";
        public static readonly string UserNotfound = "UserNotfound";
        public static readonly string IncorrectUsername = "IncorrectUsername";
        public static readonly string IncorrectPassword = "IncorrectPassword";
        public static readonly string PasswordsDoNotMatch = "PasswordsDoNotMatch";
        public static readonly string OldPasswordCannotBeSameAsNewPassword = "OldPasswordCannotBeSameAsNewPassword";
        public static readonly string IncorrectOldPassword = "IncorrectOldPassword";
        public static readonly string IncorrectRole = "IncorrectRole";
        public static readonly string StatusAlreadyExists = "StatusAlreadyExists";

        private ErrorMessages() { }
    }
}
