using UnityEngine;
using TMPro;
using UnityEngine.UI;
using MyGame.Web3.API;

namespace MyGame.Web3.UI
{
    public class WalletView : MonoBehaviour
    {
        [Header("UI Text Outputs")]
        public TMP_Text walletAddressText;
        public TMP_Text privateKeyText;
        public TMP_Text mnemonicText;

        [Header("Feedback")]
        public TMP_Text feedbackText;

        [Header("Buttons")]
        public Button createWalletButton;
        public Button importWalletButton;
        public Button playGameButton;

        [Header("Panels")]
        public GameObject walletInformationPanel;

        public void ShowFeedback(string message)
        {
            feedbackText.text = message;
        }

        public void SetButtonsInteractable(bool value)
        {
            createWalletButton.interactable = value;
            importWalletButton.interactable = value;
        }

        public void HideCreateImportButtons()
        {
            createWalletButton.gameObject.SetActive(false);
            importWalletButton.gameObject.SetActive(false);
        }

        public void ShowWalletInfo(CreateWalletResponse data)
        {
            walletAddressText.text = data.address;
            privateKeyText.text = data.privateKey;
            mnemonicText.text = data.mnemonic;
            walletInformationPanel.SetActive(true);
        }
    }
}
