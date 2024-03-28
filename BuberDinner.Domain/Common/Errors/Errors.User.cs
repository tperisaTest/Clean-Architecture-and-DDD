using ErrorOr;

namespace BuberDinner.Domain.Common.Errors
{
    public static class Errors
    {
        public static class User
        {
            public static Error DuplicateEmail => Error.Conflict(code: "User.AlreadyExists", description: "User with this email already exists");
            public static Error VoidUser => Error.NotFound(code: "User.IsVoid", description: "User does not exist.");
        }
    }
}
