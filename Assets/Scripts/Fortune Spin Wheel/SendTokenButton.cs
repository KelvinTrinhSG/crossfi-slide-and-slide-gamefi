using UnityEngine;
using UnityEngine.UI;
using MyGame.Web3.API;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class SendTokenButton : MonoBehaviour
{
    [Header("UI Button")]
    public Button sendButton;
    public Button backButton;
    public TMP_Text sendButtonText;

    [Header("Transaction Settings")]
    private string amountInEth = "1"; // có thể gán cố định, hoặc lấy từ input sau này
    public int chainId = Config.DefaultChainId;
    public SpinWheelManager spinWheelManager; // 👈 Kéo SpinWheelManager từ Inspector
    private string toSceneName = "Main";

    private void Start()
    {
        if (sendButton != null)
        {
            sendButton.onClick.AddListener(OnSendTokenClicked);
        }
        if (backButton != null)
        {
            backButton.onClick.AddListener(OnBackButtonClicked);
        }
    }

    public void OnBackButtonClicked()
    {
        SceneManager.LoadScene(toSceneName);
    }

    public void OnSendTokenClicked()
    {
        sendButton.interactable = false;
        backButton.interactable = false;

        string fromMnemonic = GlobalUser.Mnemonic;
        string toAddress = Config.DefaultToAddress;

        if (string.IsNullOrEmpty(fromMnemonic) || string.IsNullOrEmpty(toAddress))
        {
            Debug.LogError("❌ Missing wallet info in GlobalUser");
            return;
        }

        Debug.Log($"🚀 Sending {amountInEth} ETH from {toAddress}");

        StartCoroutine(WalletAPI.SendToken(
            fromMnemonic,
            toAddress,
            amountInEth,
            chainId,
            onSuccess: (resultJson) =>
            {
                Debug.Log("✅ Token sent successfully: " + resultJson);

                // ✅ Gọi Spin từ script khác
                if (spinWheelManager != null)
                {
                    spinWheelManager.OnSpinButtonClick();
                }
                else
                {
                    Debug.LogError("❌ SpinWheelManager reference not set!");
                }
                // 🔁 Chờ 12 giây trước khi bật lại nút
                StartCoroutine(EnableButtonsAfterDelay(12f));
            },
            onError: (error) =>
            {
                Debug.LogError("❌ Send token error: " + error);
                sendButtonText.text = "Get More XFI";
                StartCoroutine(UpdateButtonTextAfterDelay(3f));
                sendButton.interactable = true;
                backButton.interactable = true;
            }
        ));

    }
    private IEnumerator EnableButtonsAfterDelay(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        sendButton.interactable = true;
        backButton.interactable = true;
    }
    private IEnumerator UpdateButtonTextAfterDelay(float delaySecondsForButtonText)
    {
        yield return new WaitForSeconds(delaySecondsForButtonText);
        sendButtonText.text = "Spin (1 XFI)";
    }
}
