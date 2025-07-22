// Scripts/Models/LoginResponse.cs
namespace MyGame.Web3.API
{
    [System.Serializable]
    public class LoginResponse
    {
        public string message;
        public string username;
        public string wallet_address;
        public string privateKey;
        public string mnemonic;
    }
}
