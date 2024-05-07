using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System;

[System.Serializable]
public class Login : MonoBehaviour {
    private string fullName;
    private string account;
    private string password;

    [SerializeField]
    private GameObject loginScreen;
    [SerializeField]
    private GameObject mainScreen;

    WWWForm formLogin, formRegister;
    void Start() {
        Debug.developerConsoleVisible = true;
    }
    public void onLogin() {
        StartCoroutine(doLogin(account, password));
    }
    public void onRegister() {
        StartCoroutine(doRegister());
    }

    public void onAccountChange(string input) {
        account = input;
    }

    public void onFullNameChange(string input) {
        fullName = input;
    }

    public void onPasswordChange(string input) {
        password = input;
    }

    IEnumerator doLogin(string account, string password) {
        formLogin = new WWWForm();
        formLogin.AddField("username", account);
        formLogin.AddField("password", password);
        WWW www = new WWW("http://localhost:4000/auth/login", formLogin);
        yield return www;

        if (www.error != null) {
            Debug.LogError(www.error);
        } else {
            var result = JsonConvert.DeserializeObject<LoginResult>(www.text);
            Static.accecc_token = result.access_token;
            loginScreen.SetActive(false);
            mainScreen.SetActive(true);
        }

    }

    IEnumerator doRegister() {
        formRegister = new WWWForm();
        formRegister.AddField("username", account);
        formRegister.AddField("password", password);
        formRegister.AddField("fullname", fullName);
        WWW www = new WWW("http://localhost:4000/auth/register", formRegister);
        yield return www;

        if (www.error != null) {
            Debug.LogError(www.error);
        } else {
            Debug.Log("Login Ok");
            loginScreen.SetActive(false);
            mainScreen.SetActive(true);
        }
    }

    class LoginResult {
        public string access_token { get; set; }
        public string refresh_token { get; set; }

        public User user { get; set; }
    }

    class User {
        public int id { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }
    }
}
