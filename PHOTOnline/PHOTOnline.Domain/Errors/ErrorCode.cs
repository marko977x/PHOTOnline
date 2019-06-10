namespace PhotoLine.Domain.Errors
{
    public enum ErrorCode
    {
        EmailTaken = 0,
        UnacceptableContentType = 1,
        WrongOldPassword = 2,
        PhotographIsNotAvailable = 3,
        AlbumNotFound = 4,
        WrongEmail = 5,
        WrongPassword = 6,
        DuplicateEmail = 7,
        DuplicateUserName = 8,
        PasswordTooShort = 9,
        InvalidEmail = 10
    }
}
