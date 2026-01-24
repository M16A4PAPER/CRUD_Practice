namespace CRUD_Practice.Models.Constants
{
    public static class AppStatusCodes
    {
        public const int Success = 200;
        public const int EmptyResponse = 204;
        public const int UserNotFound = 205;
        public const int NoteNotFound = 206;
        public const int UserAlreadyExist = 207;
        public const int WrongPassword = 209;
        public const int UserBlocked = 210;
        public const int AdminUser = 211;
        public const int InvalidEmailForOTP = 212;
        public const int InvalidResetPasswordToken = 213;
        public const int AttachmentNotFound = 215;
        public const int AccessTokenExpired = 218;
        public const int DataNotModified = 230;
        public const int QrGenerationFailed = 237;
        public const int InvalidOrExpiredQr = 238;
        public const int EmptyImages = 257;
        public const int EmptyQuotesInCategory = 258;
        public const int EmptyCategories = 259;
        public const int EmptyUserSettings = 260;
        public const int NotAuthorizedToDelete = 265;
        public const int BadRequest = 400;
        public const int UnauthorizedAccess = 401;
        public const int InvalidOrMissingParameter = 421;
        public const int ServerError = 500;
        public const int InvalidOTP = 601;
    }
}
