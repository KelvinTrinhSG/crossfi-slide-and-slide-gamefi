using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using MyGame.Web3.API;
using MyGame.Web3.UI;

public class WalletController : MonoBehaviour
{
    public WalletView view;
    [SerializeField] private string sceneToLoad = "MainScene";

    private void Start()
    {
        view.createWalletButton.onClick.AddListener(OnCreateWalletClicked);
        view.playGameButton.onClick.AddListener(OnPlayGameClicked);
    }

    private void OnCreateWalletClicked()
    {
        StartCoroutine(CreateWalletRoutine());
    }

    private IEnumerator CreateWalletRoutine()
    {
        view.SetButtonsInteractable(false);
        view.ShowFeedback("⏳ Creating wallet...");

        string username = GlobalUser.Username;
        int chainId = Config.DefaultChainId;

        bool isDone = false;
        string resultJson = "";
        string errorMessage = "";

        yield return StartCoroutine(WalletAPI.CreateWallet(
            username,
            chainId,
            onSuccess: res =>
            {
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
            view.ShowFeedback("❌ " + errorMessage);
        }
        else
        {
            var data = WalletModel.ParseWalletCreated(resultJson);
            view.HideCreateImportButtons();
            view.ShowWalletInfo(data);
            view.ShowFeedback("🎉 Wallet created!");
        }
    }

    private void OnPlayGameClicked()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
