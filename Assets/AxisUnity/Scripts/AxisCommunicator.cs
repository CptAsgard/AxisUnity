using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HTTP;

public class AxisCommunicator
{
    public string WebApiUrl { get; private set; }

    public AxisUser CurrentUser { get; private set; }

    public AxisCommunicator(string webApiUrl)
    {
        WebApiUrl = webApiUrl;
    }

    public void Authenticate(string ticket, Action<HTTP.Response> onResponseAction)
    {
        var url = this.WebApiUrl + "/authenticate";

        var form = new WWWForm();
        form.AddField("ticket", ticket);

        HTTP_Post(url, form, onResponseAction);
    }

    public void CreateAccount(string username, string password, string email, Action<HTTP.Response> onResponseAction)
    {
        var url = this.WebApiUrl + "/account";

        var form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);
        form.AddField("email", email);

        HTTP_Post(url, form, onResponseAction);
    }

    public void GetAccount(string username, Action<HTTP.Response> onResponseAction)
    {
        var url = this.WebApiUrl + "/account";

        var query = UrlEncode(new Hashtable()
        {
            { "username", username }
        });

        HTTP_Get(url + "?" + query, onResponseAction);
    }

    public void SignIn( string username, string password, Action<HTTP.Response> onResponseAction)
    {
        var url = this.WebApiUrl + "/signin";

        var form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        // Hook into response so I can set the current user
        onResponseAction += delegate(Response response)
        {
            var user = AccountToUser(username);
            CurrentUser = user;
        };

        HTTP_Post(url, form, onResponseAction);
    }

    public AxisUser AccountToUser( string info )
    {
        return new AxisUser(info, "", "");
    }

    #region Helpers

    private static string UrlEncode(ICollection data)
    {
        var strings = new List<string>(data.Count);
        strings.AddRange(from DictionaryEntry entry in data select entry.Key + "=" + entry.Value);

        return string.Join("&", strings.ToArray());
    }

    private static void HTTP_Post( string url, WWWForm body, Action<HTTP.Response> onResponseAction )
    {
        var request = new HTTP.Request("post", url, body);
        request.Send((r) =>
        {
            onResponseAction(r.response);
        });
    }

    private static void HTTP_Get( string url, Action<HTTP.Response> onResponseAction)
    {
        var request = new HTTP.Request("get", url);
        request.Send((r) =>
        {
            onResponseAction(r.response);
        });
    }

    #endregion
}