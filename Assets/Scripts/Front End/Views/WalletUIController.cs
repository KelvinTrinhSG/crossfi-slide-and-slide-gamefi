using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WalletUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text walletAddressText;
    [SerializeField] private Button copyWalletButton;

    [SerializeField] private TMP_Text mnemonicText;
    [SerializeField] private Button copyMnemonicButton;

    [SerializeField] private TMP_Text privateKeyText;
    [SerializeField] public Button copyPrivateKeyButton; // 👈 Public để controller gắn listener

    private void Start()
    {
        copyWalletButton.onClick.AddListener(OnCopyWalletAddress);
        copyMnemonicButton.onClick.AddListener(OnCopyMnemonic);
        copyPrivateKeyButton.onClick.AddListener(OnCopyPrivateKey);
    }

    private void OnCopyWalletAddress()
    {
        ClipboardUtil.Copy(walletAddressText.text);
    }

    private void OnCopyMnemonic()
    {
        ClipboardUtil.Copy(mnemonicText.text);
    }

    private void OnCopyPrivateKey()
    {
        ClipboardUtil.Copy(privateKeyText.text);
    }
}
