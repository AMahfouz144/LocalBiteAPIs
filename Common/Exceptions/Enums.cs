namespace Common
{
    public enum ExceptionType
    {
        General = 1,
        Validation = 2,
        Business = 3,
        Permission = 4,
        Auth = 5,
        EntityNotFound = 6
    }

    public enum AuthExceptionType
    {
        NotFound = 1,
        NotAvailable = 2,
        Expired = 3,
    }
}