using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using MyGame.Web3.API;

public class SignupPanelController : MonoBehaviour
{
    [Header("Scene")]
    [SerializeField] private string sceneToLoad = "WalletManager";

    [Header("View")]
    public SignupView view;

    private void Start()
    {
        view.signupButton.onClick.AddListener(OnSignupClicked);
    }

    private void OnSignupClicked()
    {
        view.ClearFeedback();

        string username = view.Username;
        string password = view.Password;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            view.ShowFeedback("Please enter both username and password.");
            return;
        }

        Debug.Log($"Signup requested: {username}");

        view.SetButtonsInteractable(false);
        view.ShowFeedback("Signing up...");

        StartCoroutine(SignupRoutine(username, password));
    }

    private IEnumerator SignupRoutine(string username, string password)
    {
        bool isDone = false;
        string errorMessage = "";
        string resultJson = "";

        yield return StartCoroutine(UserAPI.Signup(
            username,
            password,
            onSuccess: res =>
            {
                Debug.Log("🔽 JSON returned from Signup:\n" + res); // ✅ THÊM DÒNG NÀY
                resultJson = res;
                isDone = true;
            },
            onError: err =>
            {
                errorMessage = err;
                isDone = true;
            }
        ));

        yield return new WaitUntil(() => isDone);

        view.SetButtonsInteractable(true);

        if (!string.IsNullOrEmpty(errorMessage))
        {
            view.ShowFeedback(errorMessage);
        }
        else
        {
            SignupModel.SaveUser(username);
            view.ShowFeedback("Signup successful!");

            yield return new WaitForSeconds(1.5f);
            if (!string.IsNullOrEmpty(sceneToLoad))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}
