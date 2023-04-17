namespace Diary
{
    interface IAccountHandler
    {
        public abstract void SignIn(string username, string password);
        public abstract void LogIn(string username, string password);
    }
}
