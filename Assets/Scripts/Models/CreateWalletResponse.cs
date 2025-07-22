// Scripts/Models/CreateWalletResponse.cs
namespace MyGame.Web3.API
{
    [System.Serializable]
    public class CreateWalletResponse
    {
        public string username;
        public string address; // 👈 Đây là key trong response từ /create
        public string privateKey;
        public string mnemonic;
    }
}
