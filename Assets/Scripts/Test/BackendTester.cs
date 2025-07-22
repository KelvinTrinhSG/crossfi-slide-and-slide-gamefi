// Scripts/Test/BackendTester.cs
using UnityEngine;

namespace MyGame.Web3.API
{
    public class BackendTester : MonoBehaviour
    {
        [Header("🔐 User Info")]
        [SerializeField] private string username = Config.DefaultUsername;
        [SerializeField] private string password = Config.DefaultPassword;

        [Header("🔗 Blockchain Info")]
        [SerializeField] private int chainId = Config.DefaultChainId;

        [Header("📥 Mnemonic để import")]
        [SerializeField] [TextArea(2, 5)] private string mnemonic = "";

        public void Signup()
        {
            StartCoroutine(UserAPI.Signup(
                username,
                password,
                onSuccess: res => Debug.Log("✅ Signup success: " + res),
                onError: err => Debug.LogError("❌ Signup failed: " + err)
            ));
        }

        public void Login()
        {
            StartCoroutine(UserAPI.Login(
                username,
                password,
                res =>
                {
                    Debug.Log("✅ Login success: " + res);
                    ParseLoginAndSave(res);
                },
                err => Debug.LogError("❌ Login failed: " + err)
            ));
        }

        public void CreateWallet()
        {
            StartCoroutine(WalletAPI.CreateWallet(
                username,
                chainId, // vì WalletAPI mới dùng string cho chainId
                onSuccess: res =>
                {
                    Debug.Log("✅ Wallet created: " + res);
                    ParseWalletCreated(res);
                },
                onError: err => Debug.LogError("❌ Wallet creation failed: " + err)
            ));
        }

        public void ImportWallet()
        {
            StartCoroutine(WalletAPI.ImportWallet(
                username,
                mnemonic,
                chainId,
                onSuccess: res =>
                {
                    Debug.Log("✅ Wallet imported: " + res);
                    ParseWalletAndSave(res);
                },
                onError: err => Debug.LogError("❌ Wallet import failed: " + err)
            ));
        }

        public void GetBalance()
        {
            StartCoroutine(WalletAPI.GetBalance(
                GlobalUser.WalletAddress,
                chainId,
                res =>
                {
                    Debug.Log("💰 Balance result: " + res);

                    GetBalanceResponse data = JsonUtility.FromJson<GetBalanceResponse>(res);
                    if (data.success)
                    {
                        GlobalUser.WalletBalance = data.balance;
                        Debug.Log($"💎 Wallet Balance: {GlobalUser.Coins} ETH");
                    }
                    else
                    {
                        Debug.LogError("❌ Failed to get balance (backend returned false).");
                    }
                },
                err => Debug.LogError("❌ GetBalance error: " + err)
            ));
        }


        private void ParseLoginAndSave(string json)
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


        private void ParseWalletCreated(string json)
        {
            CreateWalletResponse data = JsonUtility.FromJson<CreateWalletResponse>(json);

            GlobalUser.Username = data.username;
            GlobalUser.WalletAddress = data.address;
            GlobalUser.PrivateKey = data.privateKey;
            GlobalUser.Mnemonic = data.mnemonic;
        }

        private void ParseWalletAndSave(string json)
        {
            ImportWalletResponse data = JsonUtility.FromJson<ImportWalletResponse>(json);

            GlobalUser.Username = data.username;
            GlobalUser.WalletAddress = data.walletAddress;
            GlobalUser.PrivateKey = data.privateKey;
            GlobalUser.Mnemonic = data.mnemonic;

            Debug.Log("🌐 GlobalUser updated:");
            Debug.Log($"👤 {GlobalUser.Username}");
            Debug.Log($"💼 {GlobalUser.WalletAddress}");
        }
    }
}
