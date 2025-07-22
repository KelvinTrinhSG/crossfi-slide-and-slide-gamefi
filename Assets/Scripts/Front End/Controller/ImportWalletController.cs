using UnityEngine;
using System.Collections;
using MyGame.Web3.API;
using TMPro;
using UnityEngine.SceneManagement; // 👉 THÊM

namespace MyGame.Web3.Controllers
{
    public class ImportWalletController : MonoBehaviour
    {
        [Header("UI View Reference")]
        [SerializeField] private ImportWalletView view;

        [Header("Input Data")]
        [SerializeField] private TMP_InputField mnemonicInputField;
        [SerializeField] private int chainId = Config.DefaultChainId;

        [Header("Scene to Load")]
        [SerializeField] private string nextSceneName = "WalletInform"; // 👉 THÊM

        private void Start()
        {
            view.importWalletButton.onClick.AddListener(OnImportWalletClicked);
        }

        public void OnImportWalletClicked()
        {
            StartCoroutine(ImportWalletFlow());
        }

        private IEnumerator ImportWalletFlow()
        {
            view.SetLoading("⏳ Importing wallet...");
            view.SetButtonsInteractable(false);

            bool isDone = false;
            string resultJson = "";
            string errorMessage = "";
            string mnemonic = mnemonicInputField.text;

            yield return StartCoroutine(WalletAPI.ImportWallet(
                GlobalUser.Username,
                mnemonic,
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
                view.SetFeedback("❌ " + errorMessage);
            }
            else
            {
                var data = WalletModel.ParseWalletImported(resultJson);

                view.ShowWallet(data);
                view.SetFeedback("✅ Wallet imported!");

                // 👉 THÊM: Chuyển scene khi import ví thành công
                yield return new WaitForSeconds(1f);
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
