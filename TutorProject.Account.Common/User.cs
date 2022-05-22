namespace TutorProject.Account.Common
{
    public class User
    {
        public int Id { get; private init; }
        public string Name { get; private init; }
        public string Login { get; private init; }
        public string Password { get; private init; }
    }
}