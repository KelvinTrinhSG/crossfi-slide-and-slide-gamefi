using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using MyGame.Web3.API;

public class LoginPanelController : MonoBehaviour
{
    [Header("Scene")]
    [SerializeField] private string sceneToLoad = "WalletInform";

    [Header("View")]
    public LoginView view;

    private void Start()
    {
        view.loginButton.onClick.AddListener(OnLoginClicked);
    }

    private void OnLoginClicked()
    {
        view.ClearFeedback();

        string username = view.Username;
        string password = view.Password;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            view.ShowFeedback("Please enter both username and password.");
            return;
        }

        Debug.Log($"Login requested: {username}");

        view.SetButtonsInteractable(false);
        view.ShowFeedback("Logging in...");

        StartCoroutine(LoginRoutine(username, password));
    }

    private IEnumerator LoginRoutine(string username, string password)
    {
        bool isDone = false;
        string errorMessage = "";
        string resultJson = "";

        yield return StartCoroutine(UserAPI.Login(
            username,
            password,
            onSuccess: res =>
            {
                Debug.Log("Login success: " + res);
                resultJson = res;
                isDone = true;
            },
            onError: err =>
            {
                Debug.LogError("Login failed: " + err);
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
            LoginModel.ParseAndSave(resultJson);
            view.ShowFeedback("Login successful!");

            yield return new WaitForSeconds(1.5f);
            if (!string.IsNullOrEmpty(sceneToLoad))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}
