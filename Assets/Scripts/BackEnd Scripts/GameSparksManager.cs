using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using GameSparks.Core;
using System.Collections.Generic;
using System;
using GameSparks.Api.Responses;
using Facebook.Unity;

public class GameSparksManager : MonoBehaviour
{
    //singleton for the gamesparks manager so it can be called from anywhere
    private static GameSparksManager instance = null;

    //getter property for private backing field instance
    public static GameSparksManager Instance() { return instance; }

    public Canvas registerPlayerCanvas;
    public Canvas loadingInfoCanvas;

    // Vetor de strings para guardar os tempos recebidos do GS
    public static int[] records;
    public static int NUMERO_FASES = 80;

    private string loadedID = "";
    private string loadedTime = "";


    // Use this for initialization
    void Awake()
    {
        //this will create a singleton for our gamesparks manager object
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

        GS.GameSparksAvailable += GSAvailable;
        GameSparks.Api.Messages.AchievementEarnedMessage.Listener += AchievementEarnedListener;
        GameObject.Find("LoadingBar").SendMessage("goToLoading", 90);
    }

    void Update() { 
        if(SceneManager.GetActiveScene().name.Equals("TitleScene")){
            if(GetComponent<ModoOffline>().getModoOffline()){

                // Sem conexão com a internet, modo offline caso já tenha registrado jogador
                if (PlayerPrefs.HasKey("DisplayName"))
                {
                    loadingInfoCanvas.gameObject.SetActive(false);
                }
                else
                {
                    // Tenta recomeçar o jogo se jogador não registrado (aparecer uma tela antes?)
                    SceneManager.LoadScene(0);
                }
            }
        }
    }

    void GSAvailable(bool _isAvalable)
    {
        if (GetComponent<ModoOffline>().getModoOffline())
        {
            if (PlayerPrefs.HasKey("DisplayName"))
            {
                loadingInfoCanvas.gameObject.SetActive(false);
            }
            else
            {
                // Tenta recomeçar o jogo se jogador não registrado (aparecer uma tela antes?)
                SceneManager.LoadScene(0);
            }
        }

        //this method will be called only when the GS service is available or unavailable
        if (_isAvalable)
        {
            // Application.LoadLevel(1);
            //Debug.Log(">>>>>>>>>GS Conected<<<<<<<<");

            // Tenta concetar a uma conta
            new GameSparks.Api.Requests.AccountDetailsRequest()
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        // Conectou, prossegue mostrando o nome
                        if (SceneManager.GetActiveScene().name.Equals("TitleScene"))
                        {
                            GameObject.Find("LoadingBar").SendMessage("goToLoading", 100);
                        }

                        //Debug.Log("Account Details Found... - Olá, " + response.DisplayName);
                        loadingInfoCanvas.gameObject.SetActive(false);

                        RetrieveRecords();
                    }
                    else
                    {
                        // Não conectou a nenhuma conta, mostra tela de registro
                        //Debug.Log("Error Retrieving Account Details...");
                        loadingInfoCanvas.gameObject.SetActive(false);

                        registerPlayerCanvas.gameObject.SetActive(true);
                    }
                });

        }
        else
        {
            //Debug.Log(">>>>>>>>>GS Disconnected<<<<<<<<");
        }
    }

    private void RetrieveRecords()
    {
        records = new int[NUMERO_FASES];

        // Carrega o tempo da fase salvo
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("RETRIEVE_RECORDS")
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        //Debug.Log("Recieved Player Data From GameSparks...");
                        GSData data = response.ScriptData.GetGSData("player_Data");
                        loadedID = "Player ID: " + data.GetString("playerID");

                        // Joga todos os tempos do jogador no vetor records
                        int k = 0;
                        for (int i = 1; i <= 8; i++)
                        {
                            for (int j = 1; j <= 10; j++)
                            {
                                records[k] = (int)data.GetInt("playerTime_" + i + "_" + j);
                                k++;
                            }
                        }
                    }
                    else
                    {
                        //Debug.Log("Error Loading Player Data...");
                    }
                });
    }

    //Achievement message  listener
    private void AchievementEarnedListener(GameSparks.Api.Messages.AchievementEarnedMessage _message)
    {
        //Debug.LogWarning("Message Recieved" + _message.AchievementName);

    }

    #region FaceBook Authentication
    /// <summary>
    /// Below we will login with facebook.
    /// When FB is ready we will call the method that allows GS to connect to GameSparks
    /// Chamar este método em um botão para conectar com o FB
    /// Também cria usuário
    /// </summary>
    public void ConnectWithFacebook()
    {
        if (!FB.IsInitialized)
        {
            //Debug.Log("Initializing Facebook");
            FB.Init(FacebookLogin);
        }
        else
        {
            FacebookLogin();
        }
    }


    /// <summary>
    /// When Facebook is ready , this will connect the pleyer to Facebook
    /// After the Player is authenticated it will  call the GS connect
    /// </summary>
    void FacebookLogin()
    {
        if (!FB.IsLoggedIn)
        {
            //Debug.Log("Logging into Facebook");
            FB.LogInWithReadPermissions(
                new List<string>() { "public_profile", "email", "user_friends" },
                GameSparksFBConnect
                );
        }
    }

    void GameSparksFBConnect(ILoginResult result)
    {

        if (FB.IsLoggedIn)
        {
            //Debug.Log("Logging into gamesparks with facebook details");
            GSFacebookLogin(AfterFBLogin);
            UserManager.instance.UpdateInformation();
        }
        else
        {
            //Debug.Log("Something wrong with FB");
        }
    }

    //this is the callback that happens when gamesparks has been connected with FB
    private void AfterFBLogin(GameSparks.Api.Responses.AuthenticationResponse _resp)
    {
        //Debug.Log(_resp.DisplayName);
    }

    //delegate for asynchronous callbacks
    public delegate void FacebookLoginCallback(AuthenticationResponse _resp);


    //This method will connect GS with FB
    public void GSFacebookLogin(FacebookLoginCallback _fbLoginCallback)
    {
        new GameSparks.Api.Requests.FacebookConnectRequest()
            .SetAccessToken(AccessToken.CurrentAccessToken.TokenString)
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    //Debug.Log("Logged into gamesparks with facebook");
                    _fbLoginCallback(response);
                }
                else
                {
                    //Debug.Log("Error Logging into facebook");
                }

            });
    }
    #endregion

    /// <summary>
    /// If a player is registered this will log them in with GameSparks.
    /// </summary>
    public void LoginPlayer(string _userNameInput, string _passwordInput)
    {
        new GameSparks.Api.Requests.AuthenticationRequest()
            .SetUserName(_userNameInput)
            .SetPassword(_passwordInput)
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    //Debug.Log("Player Authenticated...");
                }
                else
                {
                    //Debug.Log("Error Authenticating Player\n" + response.Errors.JSON.ToString());
                }
            });
    }

    public void SaveDateTime() { 
    }

    // Ao sair do jogo, guarda o tempo em DateTime
    void OnApplicationQuit()
    {
        PlayerPrefs.SetString("DateTime", System.DateTime.Now.ToString());
    }
}