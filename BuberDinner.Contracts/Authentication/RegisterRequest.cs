namespace BuberDinner.Contracts.Authentication
{
    public record RegisterRequest(string FirstName, string LastName, string email, string password);
}
