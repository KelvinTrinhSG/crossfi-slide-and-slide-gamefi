using UnityEngine;
using TMPro;
using UnityEngine.UI;
using MyGame.Web3.API;
using System;

namespace MyGame.Web3.Controllers
{
    public class ImportWalletView : MonoBehaviour
    {
        [Header("Wallet Info")]
        [SerializeField] private TMP_Text walletAddressText;
        [SerializeField] private TMP_Text privateKeyText; // 🔽 Thêm dòng này
        [SerializeField] private TMP_Text mnemonicText;

        [Header("Feedback")]
        [SerializeField] private TMP_Text feedbackText;

        [Header("Buttons")]
        public Button importWalletButton;
        public Button createWalletButton;

        // 👇 GÁN SỰ KIỆN CLICK TỪ CONTROLLER
        public void SetOnImportClicked(Action callback)
        {
            importWalletButton.onClick.RemoveAllListeners();
            importWalletButton.onClick.AddListener(() => callback?.Invoke());
        }

        public void SetFeedback(string message)
        {
            feedbackText.text = message;
        }

        public void SetLoading(string loadingMessage)
        {
            feedbackText.text = loadingMessage;
        }

        public void SetButtonsInteractable(bool interactable)
        {
            importWalletButton.interactable = interactable;
            createWalletButton.interactable = interactable;
        }

        public void ShowWallet(ImportWalletResponse data)
        {
            walletAddressText.text = data.walletAddress;
            privateKeyText.text = data.privateKey; // 🔽 Thêm dòng này
            mnemonicText.text = data.mnemonic;
        }
    }
}
