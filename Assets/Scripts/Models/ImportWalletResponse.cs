// Scripts/Models/ImportWalletResponse.cs
namespace MyGame.Web3.API
{
    [System.Serializable]
    public class ImportWalletResponse
    {
        public string username;
        public string walletAddress; // 👈 Đây là key trong response từ /import-wallet
        public string privateKey;
        public string mnemonic;
    }
}
