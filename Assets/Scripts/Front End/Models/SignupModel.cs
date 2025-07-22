using UnityEngine;

namespace MyGame.Web3.API
{
    public static class SignupModel
    {
        public static void SaveUser(string username)
        {
            GlobalUser.Username = username;

            Debug.Log("✅ GlobalUser saved:");
            Debug.Log("👤 Username: " + GlobalUser.Username);
        }
    }
}
