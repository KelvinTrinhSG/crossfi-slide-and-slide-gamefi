using UnityEngine;
using System.Collections;
using MyGame.Web3.API;

namespace MyGame.Web3.Controllers
{
    public class GetBalanceController : MonoBehaviour
    {
        [Header("Balance View")]
        public GetBalanceView view;

        [Header("Chain Info")]
        [SerializeField] private int chainId = Config.DefaultChainId;

        private void Start()
        {
            StartCoroutine(FetchAndDisplayBalance());
        }

        private IEnumerator FetchAndDisplayBalance()
        {
            bool isDone = false;
            string result = "";
            string error = "";

            yield return StartCoroutine(WalletAPI.GetBalance(
                GlobalUser.WalletAddress,
                chainId,
                res =>
                {
                    result = res;
                    isDone = true;
                },
                err =>
                {
                    error = err;
                    isDone = true;
                }
            ));

            yield return new WaitUntil(() => isDone);

            if (!string.IsNullOrEmpty(error))
            {
                Debug.LogError("❌ Balance error: " + error);
                view.ShowError(error);
            }
            else
            {
                GetBalanceResponse data = JsonUtility.FromJson<GetBalanceResponse>(result);
                if (data.success)
                {
                    GlobalUser.WalletBalance = data.balance; // Optional if you want to cache it
                    view.ShowBalance(data.balance);
                }
                else
                {
                    view.ShowError("Failed to get balance (backend returned false).");
                }
            }
        }
    }
}
