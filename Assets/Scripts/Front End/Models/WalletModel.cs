using UnityEngine;

namespace MyGame.Web3.API
{
    public static class WalletModel
    {
        public static CreateWalletResponse ParseWalletCreated(string json)
        {
            CreateWalletResponse data = JsonUtility.FromJson<CreateWalletResponse>(json);

            GlobalUser.Username = data.username;
            GlobalUser.WalletAddress = data.address;
            GlobalUser.PrivateKey = data.privateKey;
            GlobalUser.Mnemonic = data.mnemonic;

            return data;
        }

        public static ImportWalletResponse ParseWalletImported(string json)
        {
            ImportWalletResponse data = JsonUtility.FromJson<ImportWalletResponse>(json);

            GlobalUser.Username = data.username;
            GlobalUser.WalletAddress = data.walletAddress;
            GlobalUser.PrivateKey = data.privateKey;
            GlobalUser.Mnemonic = data.mnemonic;

            return data;
        }
    }
}
