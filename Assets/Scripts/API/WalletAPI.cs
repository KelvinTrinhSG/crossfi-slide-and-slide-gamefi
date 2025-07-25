// Scripts/API/WalletAPI.cs
using System;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

namespace MyGame.Web3.API
{
    public static class WalletAPI
    {
        public static IEnumerator CreateWallet(string username, int chainId, Action<string> onSuccess, Action<string> onError)
        {
            string url = Config.BackendBaseUrl + Config.CreateWalletEndpoint;

            var requestData = new CreateWalletRequest
            {
                username = username,
                chainId = chainId
            };

            string json = JsonUtility.ToJson(requestData);

            UnityWebRequest request = new UnityWebRequest(url, "POST");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

#if UNITY_2022_1_OR_NEWER
            if (request.result == UnityWebRequest.Result.Success)
#else
        if (!request.isNetworkError && !request.isHttpError)
#endif
            {
                onSuccess?.Invoke(request.downloadHandler.text);
            }
            else
            {
                onError?.Invoke($"Error: {request.error} | Response: {request.downloadHandler.text}");
            }
        }

        public static IEnumerator ImportWallet(string username, string mnemonic, int chainId, Action<string> onSuccess, Action<string> onError)
        {
            string url = Config.BackendBaseUrl + Config.ImportWalletEndpoint;

            var requestData = new ImportWalletRequest
            {
                username = username,
                mnemonic = mnemonic,
                chainId = chainId
            };

            string json = JsonUtility.ToJson(requestData);

            UnityWebRequest request = new UnityWebRequest(url, "POST");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

#if UNITY_2022_1_OR_NEWER
            if (request.result == UnityWebRequest.Result.Success)
#else
        if (!request.isNetworkError && !request.isHttpError)
#endif
            {
                onSuccess?.Invoke(request.downloadHandler.text);
            }
            else
            {
                onError?.Invoke($"Error: {request.error} | Response: {request.downloadHandler.text}");
            }
        }

        public static IEnumerator GetBalance(string walletAddress, int chainId, Action<string> onSuccess, Action<string> onError)
        {
            string url = Config.BackendBaseUrl + Config.GetBalanceEndpoint;

            var requestData = new GetBalanceRequest
            {
                wallet_address = walletAddress,
                chainId = chainId
            };

            string json = JsonUtility.ToJson(requestData);
            UnityWebRequest request = new UnityWebRequest(url, "POST");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

#if UNITY_2022_1_OR_NEWER
            if (request.result == UnityWebRequest.Result.Success)
#else
        if (!request.isHttpError && !request.isNetworkError)
#endif
            {
                onSuccess?.Invoke(request.downloadHandler.text);
            }
            else
            {
                onError?.Invoke($"Error: {request.error} | Response: {request.downloadHandler.text}");
            }
        }

        public static IEnumerator SendToken(string fromMnemonic, string toAddress, string amountInEth, int chainId, Action<string> onSuccess, Action<string> onError)
        {
            string url = Config.BackendBaseUrl + Config.SendTokenEndpoint;

            // Gửi amount dưới dạng số ETH, backend sẽ convert sang wei
            var requestData = new SendTokenRequest
            {
                fromMnemonic = fromMnemonic,
                toAddress = toAddress,
                amount = amountInEth,
                chainId = chainId
            };

            string json = JsonUtility.ToJson(requestData);

            UnityWebRequest request = new UnityWebRequest(url, "POST");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

#if UNITY_2022_1_OR_NEWER
            if (request.result == UnityWebRequest.Result.Success)
#else
    if (!request.isNetworkError && !request.isHttpError)
#endif
            {
                onSuccess?.Invoke(request.downloadHandler.text);
            }
            else
            {
                onError?.Invoke($"Error: {request.error} | Response: {request.downloadHandler.text}");
            }
        }

        [Serializable]
        private class CreateWalletRequest
        {
            public string username;
            public int chainId;
        }

        [Serializable]
        private class ImportWalletRequest
        {
            public string username;
            public string mnemonic;
            public int chainId;
        }

        [Serializable]
        private class GetBalanceRequest
        {
            public string wallet_address;
            public int chainId;
        }

        [Serializable]
        private class SendTokenRequest
        {
            public string fromMnemonic;
            public string toAddress;
            public string amount; // gửi dạng "0.01"
            public int chainId;
        }
    }
}
