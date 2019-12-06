namespace UserServices.Shared.Interface
{
    interface IUserRepository
    {
        bool login();
        void logout();
    }
}
