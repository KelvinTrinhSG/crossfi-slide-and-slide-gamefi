using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginView : MonoBehaviour
{
    [Header("UI References")]
    public TMP_InputField playerIDInput;
    public TMP_InputField passwordInput;
    public Button loginButton;
    public Button switchToSignupButton;
    public TMP_Text feedbackText;

    public string Username => playerIDInput.text.Trim();
    public string Password => passwordInput.text;

    public void SetButtonsInteractable(bool state)
    {
        loginButton.interactable = state;
        switchToSignupButton.interactable = state;
    }

    public void ShowFeedback(string message)
    {
        feedbackText.text = message;
    }

    public void ClearFeedback()
    {
        feedbackText.text = "";
    }
}
