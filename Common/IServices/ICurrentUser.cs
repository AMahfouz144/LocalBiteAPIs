using System;

namespace Common.IServices
{
    public interface ICurrentUser
    {
        long? UserId { get; }
        Guid? TokenId { get; }
        string Contact { get; }
        string DisplayName { get; }

        Language Language { get; }
        AppPlatform AppPlatform { get; }
        string AppVersion { get; }
        string InstallationId { get; }
    }
}