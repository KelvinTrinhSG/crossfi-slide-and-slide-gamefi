// Scripts/Debug/GlobalUserViewer.cs
using UnityEngine;

namespace MyGame.Web3.API
{
    public class GlobalUserViewer : MonoBehaviour
    {
        [Header("🔎 Realtime View (Read-Only)")]

        [SerializeField] string username;
        [SerializeField] string walletAddress;
        [SerializeField] string privateKey;
        [SerializeField] string mnemonic;
        [SerializeField] string balance;

        void Update()
        {
            username = GlobalUser.Username;
            walletAddress = GlobalUser.WalletAddress;
            privateKey = GlobalUser.PrivateKey;
            mnemonic = GlobalUser.Mnemonic;
            balance = GlobalUser.WalletBalance;
        }
    }
}
