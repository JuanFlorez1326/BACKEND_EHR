using EasyHouseRent;

namespace EHR_BACKEND.Models.Entities
{
    public class DataPassworUpdate
    {
        private string _email;
        public string email { get { return _email; } set { _email = value; } }
        private string _password;
        public string password { get { return _password; } set { _password = Encrypt.GetSHA256(value); } }

        private string _validatePassword;
        public string validatePassword { get { return _validatePassword; } set { _validatePassword = Encrypt.GetSHA256(value); } }
    }
}
