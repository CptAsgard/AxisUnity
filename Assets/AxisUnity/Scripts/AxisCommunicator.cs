using UnityEngine;
using System.Collections;

public class AxisCommunicator
{
    public string WebApiUrl;

    public AxisCommunicator( string WebApiUrl = "" )
    {
        this.WebApiUrl = WebApiUrl;
    }

    public void Authenticate( string ticket )
    {

    }

    public void CreateAccount(string username, string password, string email)
    {

    }

    public void GetAccount(string username)
    {
        var url = this.WebApiUrl + "/account";

        Hashtable data = new Hashtable();
        data.Add("username", username);

        HTTP.Request someRequest = new HTTP.Request("get", url + "?username=" + username);
        someRequest.Send((request) =>
       {
           var message = request.response.message;
           var thing = JSON.JsonDecode(request.response.Text);

           if (request.response.Text == "OK")
           {
               Debug.Log("Success! Successfully got account \"" + username + "\"");
           }
           else
           {
               Debug.Log("Could not get account \"" + username + "\"");
           }
       });
    }

    public void GetCurrentUser()
    {

    }

    public void SetCurrentUser()
    {

    }

    public void SignIn()
    {

    }
}

public class AxisUser
{
    public void GetAvatarImageUrl()
    {

    }

    public void GetUsername()
    {

    }

    public void GetEmail()
    {

    }

    public void GetEmailHash()
    {

    }

    public void GetTicket()
    {

    }
}