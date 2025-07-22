using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SignupView : MonoBehaviour
{
    [Header("UI References")]
    public TMP_InputField playerIDInput;
    public TMP_InputField passwordInput;
    public Button signupButton;
    public Button switchToLoginButton;
    public TMP_Text feedbackText;

    public string Username => playerIDInput.text.Trim();
    public string Password => passwordInput.text;

    public void SetButtonsInteractable(bool state)
    {
        signupButton.interactable = state;
        switchToLoginButton.interactable = state;
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
