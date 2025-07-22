// Scripts/API/UserAPI.cs
using System;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

namespace MyGame.Web3.API
{
    public static class UserAPI
    {
        public static IEnumerator Signup(string username, string password, Action<string> onSuccess, Action<string> onError)
        {
            string url = Config.BackendBaseUrl + Config.SignupEndpoint;

            // Dữ liệu gửi đi
            var requestData = new SignupRequest
            {
                username = username,
                password = password
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

        public static IEnumerator Login(string username, string password, Action<string> onSuccess, Action<string> onError)
        {
            string url = Config.BackendBaseUrl + Config.LoginEndpoint;

            var requestData = new LoginRequest
            {
                username = username,
                password = password
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

        [Serializable]
        private class SignupRequest
        {
            public string username;
            public string password;
        }

        [Serializable]
        private class LoginRequest
        {
            public string username;
            public string password;
        }
    }
}
