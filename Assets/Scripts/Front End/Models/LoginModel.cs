using UnityEngine;

namespace MyGame.Web3.API
{
    public static class LoginModel
    {
        public static void ParseAndSave(string json)
        {
            LoginResponse data = JsonUtility.FromJson<LoginResponse>(json);

            GlobalUser.Username = data.username;
            GlobalUser.WalletAddress = data.wallet_address;
            GlobalUser.PrivateKey = data.privateKey;
            GlobalUser.Mnemonic = data.mnemonic;

            Debug.Log("🌐 GlobalUser (from login):");
            Debug.Log($"👤 {GlobalUser.Username}");
            Debug.Log($"💼 {GlobalUser.WalletAddress}");
        }
    }
}
