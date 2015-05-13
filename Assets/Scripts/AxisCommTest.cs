using UnityEngine;
using System.Collections;

namespace Potion {
    public class AxisCommTest : MonoBehaviour
    {
        private AxisCommunicator comm;

        void Start()
        {
            comm = new AxisCommunicator("https://api.andrewmcwatters.com/axis");
            comm.SignIn("Asgardr", "TestPass", OnSignedIn);
        }

        void OnAccountGet( HTTP.Response response )
        {
            Debug.Log(response.Text);
        }

        void OnCreateAccount(HTTP.Response response)
        {
            Debug.Log(response.Text);
        }

        void OnSignedIn(HTTP.Response response)
        {
            Debug.Log(response.Text);
            Debug.Log(comm.CurrentUser.Username);
        }
    }
}