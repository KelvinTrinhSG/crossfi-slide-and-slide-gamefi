using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MyGame.Web3.API;

namespace MyGame.Web3.UI
{
    public class WalletInfoView : MonoBehaviour
    {
        [Header("Text Fields")]
        public TMP_Text userNameValue;
        public TMP_Text walletAddressValue;
        public TMP_Text mnemonicsValue;
        public TMP_Text balanceValue;

        [Header("Buttons")]
        public Button playGameButton;

        [Header("Scene To Load")]
        [SerializeField] private string sceneToLoad = "MainScene";

        private void Start()
        {
            DisplayUserInfo();

            if (playGameButton != null)
                playGameButton.onClick.AddListener(OnPlayGameClicked);
        }

        private void DisplayUserInfo()
        {
            userNameValue.text = GlobalUser.Username;
            walletAddressValue.text = GlobalUser.WalletAddress;
            mnemonicsValue.text = GlobalUser.Mnemonic;
        }

        private void OnPlayGameClicked()
        {
            if (!string.IsNullOrEmpty(sceneToLoad))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}
