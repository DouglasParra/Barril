using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class RegisterPlayer_Script : MonoBehaviour
{
    public Canvas registerPlayerCanvas;

    // Username generator
    private string characters = "0123456789abcdefghijklmnopqrstuvwxyz";
    private int DESIRED_CODE_LENGTH = 8;

    public InputField displayNameInput; // these are set through the editor
    
    // , userNameInput, passwordInput
    public Button confirmButton;
    public Text warningLabel;

    private string userName;

    void Start(){

    }

    private string UsernameGenerator()
    {
        string code = "#";

        for (int i = 0; i < DESIRED_CODE_LENGTH; i++)
        {
            int a = UnityEngine.Random.Range(0, characters.Length);
            code = code + characters[a];
        }

        return code;
    }

    public void ValidatePlayerName() {
        // Deve ser >= 3 para nome válido
        //Debug.Log(displayNameInput.text);

        if (displayNameInput.text.Length>= 3)
        {
            confirmButton.interactable = true;
            warningLabel.gameObject.SetActive(false); 
        }
        else 
        {
            confirmButton.interactable = false;
            warningLabel.gameObject.SetActive(true);
        }
    }

    private void ValidateUserName() { 
        
    }

    public void RegisterPlayerBttn()
    {
        //Debug.Log("Registering Player...");

        userName = UsernameGenerator();
        PlayerPrefs.SetString("UserName", userName);
        PlayerPrefs.SetString("DisplayName", displayNameInput.text);

        new GameSparks.Api.Requests.RegistrationRequest()
            .SetDisplayName(displayNameInput.text)
            .SetUserName(userName) 
            .SetPassword("") //passwordInput.text
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Player Registered \n Player Name: " + response.DisplayName);
                    registerPlayerCanvas.gameObject.SetActive(false);

                    GameObject.Find("GameSparks Manager").GetComponent<GooglePlayOrbe>().GooglePlayOrbeActivate();

                    InitiateRecords();
                }
                else if (response.Errors.JSON.Equals("{\"USERNAME\":\"TAKEN\"}"))
                {
                    //Debug.Log("Username iguais, deveria gerar outro...");
                    
                    // Chama de novo até um username válido ser gerado
                    RegisterPlayerBttn();
                }
                else
                {
                    //Debug.Log("Error Registering Player... \n " + response.Errors.JSON.ToString());
                }

            });
    }

    private void InitiateRecords() {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("INITIATE_RECORDS")
            .SetEventAttribute("TIME_1_1", 9999999)
            .SetEventAttribute("TIME_1_2", 9999999)
            .SetEventAttribute("TIME_1_3", 9999999)
            .SetEventAttribute("TIME_1_4", 9999999)
            .SetEventAttribute("TIME_1_5", 9999999)
            .SetEventAttribute("TIME_1_6", 9999999)
            .SetEventAttribute("TIME_1_7", 9999999)
            .SetEventAttribute("TIME_1_8", 9999999)
            .SetEventAttribute("TIME_1_9", 9999999)
            .SetEventAttribute("TIME_2_10", 9999999)
            .SetEventAttribute("TIME_2_1", 9999999)
            .SetEventAttribute("TIME_2_2", 9999999)
            .SetEventAttribute("TIME_2_3", 9999999)
            .SetEventAttribute("TIME_2_4", 9999999)
            .SetEventAttribute("TIME_2_5", 9999999)
            .SetEventAttribute("TIME_2_6", 9999999)
            .SetEventAttribute("TIME_2_7", 9999999)
            .SetEventAttribute("TIME_2_8", 9999999)
            .SetEventAttribute("TIME_2_9", 9999999)
            .SetEventAttribute("TIME_2_10", 9999999)
            .SetEventAttribute("TIME_3_1", 9999999)
            .SetEventAttribute("TIME_3_2", 9999999)
            .SetEventAttribute("TIME_3_3", 9999999)
            .SetEventAttribute("TIME_3_4", 9999999)
            .SetEventAttribute("TIME_3_5", 9999999)
            .SetEventAttribute("TIME_3_6", 9999999)
            .SetEventAttribute("TIME_3_7", 9999999)
            .SetEventAttribute("TIME_3_8", 9999999)
            .SetEventAttribute("TIME_3_9", 9999999)
            .SetEventAttribute("TIME_3_10", 9999999)
            .SetEventAttribute("TIME_4_1", 9999999)
            .SetEventAttribute("TIME_4_2", 9999999)
            .SetEventAttribute("TIME_4_3", 9999999)
            .SetEventAttribute("TIME_4_4", 9999999)
            .SetEventAttribute("TIME_4_5", 9999999)
            .SetEventAttribute("TIME_4_6", 9999999)
            .SetEventAttribute("TIME_4_7", 9999999)
            .SetEventAttribute("TIME_4_8", 9999999)
            .SetEventAttribute("TIME_4_9", 9999999)
            .SetEventAttribute("TIME_4_10", 9999999)
            .SetEventAttribute("TIME_5_1", 9999999)
            .SetEventAttribute("TIME_5_2", 9999999)
            .SetEventAttribute("TIME_5_3", 9999999)
            .SetEventAttribute("TIME_5_4", 9999999)
            .SetEventAttribute("TIME_5_5", 9999999)
            .SetEventAttribute("TIME_5_6", 9999999)
            .SetEventAttribute("TIME_5_7", 9999999)
            .SetEventAttribute("TIME_5_8", 9999999)
            .SetEventAttribute("TIME_5_9", 9999999)
            .SetEventAttribute("TIME_5_10", 9999999)
            .SetEventAttribute("TIME_6_1", 9999999)
            .SetEventAttribute("TIME_6_2", 9999999)
            .SetEventAttribute("TIME_6_3", 9999999)
            .SetEventAttribute("TIME_6_4", 9999999)
            .SetEventAttribute("TIME_6_5", 9999999)
            .SetEventAttribute("TIME_6_6", 9999999)
            .SetEventAttribute("TIME_6_7", 9999999)
            .SetEventAttribute("TIME_6_8", 9999999)
            .SetEventAttribute("TIME_6_9", 9999999)
            .SetEventAttribute("TIME_6_10", 9999999)
            .SetEventAttribute("TIME_7_1", 9999999)
            .SetEventAttribute("TIME_7_2", 9999999)
            .SetEventAttribute("TIME_7_3", 9999999)
            .SetEventAttribute("TIME_7_4", 9999999)
            .SetEventAttribute("TIME_7_5", 9999999)
            .SetEventAttribute("TIME_7_6", 9999999)
            .SetEventAttribute("TIME_7_7", 9999999)
            .SetEventAttribute("TIME_7_8", 9999999)
            .SetEventAttribute("TIME_7_9", 9999999)
            .SetEventAttribute("TIME_7_10", 9999999)
            .SetEventAttribute("TIME_8_1", 9999999)
            .SetEventAttribute("TIME_8_2", 9999999)
            .SetEventAttribute("TIME_8_3", 9999999)
            .SetEventAttribute("TIME_8_4", 9999999)
            .SetEventAttribute("TIME_8_5", 9999999)
            .SetEventAttribute("TIME_8_6", 9999999)
            .SetEventAttribute("TIME_8_7", 9999999)
            .SetEventAttribute("TIME_8_8", 9999999)
            .SetEventAttribute("TIME_8_9", 9999999)
            .SetEventAttribute("TIME_8_10", 9999999)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Player records initiated to GameSparks...");

                    // Jogar pro records[] do GameManager
                    GameSparksManager.records = new int[GameSparksManager.NUMERO_FASES];
                    for (int i=0; i < GameSparksManager.NUMERO_FASES; i++) {
                        GameSparksManager.records[i] = 9999999;
                    }

                    InitiateLife();
                }
                else
                {
                    //Debug.Log("Error Saving Player Data...");
                }
            });
    }

    private void InitiateLife()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("SAVE_LIFES")
            .SetEventAttribute("LIFE", 5)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Inicializou vida com 5...");

                    PlayerPrefs.SetString("Minutos", "10");
                    PlayerPrefs.SetString("Segundos", "00");

                    PlayerPrefs.SetFloat("sfxVol", -10.0f);
                    PlayerPrefs.SetFloat("musicVol", -10.0f);
                    PlayerPrefs.SetInt("soundOnOff", 1);

                    PlayerPrefs.SetInt("Laser", 0);
                    PlayerPrefs.SetInt("MiniMapa", 0);
                    PlayerPrefs.SetInt("Mark", 0);

                    PlayerPrefs.SetInt("Skin1", 0);
                    PlayerPrefs.SetInt("Skin2", 0);
                    PlayerPrefs.SetInt("Skin3", 0);
                    PlayerPrefs.SetInt("Skin4", 0);
                    PlayerPrefs.SetInt("Skin5", 0);
                    PlayerPrefs.SetInt("Skin6", 0);
                    PlayerPrefs.SetInt("Skin7", 0);
                    PlayerPrefs.SetInt("Skin8", 0);
                    PlayerPrefs.SetInt("Skin9", 0);
                    PlayerPrefs.SetInt("Skin10", 0);
                    PlayerPrefs.SetInt("Skin11", 0);
                    PlayerPrefs.SetInt("Skin12", 0);
                    PlayerPrefs.SetInt("Skin13", 0);

                    PlayerPrefs.SetInt("Vidas", 5);
                    PlayerPrefs.SetInt("tutorialDone", 0);
                    PlayerPrefs.SetInt("stageSelectTutorialDone", 0);

                    PlayerPrefs.SetString("ADDateTime", DateTime.Now.ToString());
                    PlayerPrefs.SetInt("ADLifes", 5);

                    PlayerPrefs.SetInt("Fases", 1);

                    InitiatePowercells();
                }
                else
                {
                    //Debug.Log("Error Saving Player Data...");
                }
            });
    }

    private void InitiatePowercells()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("SAVE_POWERCELLS")
            .SetEventAttribute("POWERCELL", 500)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Inicializou powercells com 5...");
                    InitiateLaser();
                }
                else
                {
                    //Debug.Log("Error Saving powercells Data...");
                }
            });
    }

    private void InitiateLaser()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_LASER")
            .SetEventAttribute("LASER", 0)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Inicializou laser com 0...");
                    InitiateMinimap();
                }
                else
                {
                    //Debug.Log("Error Saving Laser Data...");
                }
            });
    }

    private void InitiateMinimap()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_MINIMAP")
            .SetEventAttribute("MINIMAP", 0)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Inicializou minimapa com 0...");
                    InitiateSkin1();
                }
                else
                {
                    //Debug.Log("Error Saving Minimap Data...");
                }
            });
    }

    private void InitiateSkin1()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN1")
            .SetEventAttribute("SKIN1", 0)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Inicializou skin1 com 0...");
                    InitiateSkin2();
                }
                else
                {
                    //Debug.Log("Error Saving Skin1 Data...");
                }
            });
    }

    private void InitiateSkin2()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN2")
            .SetEventAttribute("SKIN2", 0)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Inicializou skin2 com 0...");
                    InitiateSkin3();
                }
                else
                {
                    //Debug.Log("Error Saving Skin2 Data...");
                }
            });
    }

    private void InitiateSkin3()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN3")
            .SetEventAttribute("SKIN3", 0)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Inicializou skin3 com 0...");
                    InitiateSkin4();
                }
                else
                {
                    //Debug.Log("Error Saving Skin3 Data...");
                }
            });
    }

    private void InitiateSkin4()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN4")
            .SetEventAttribute("SKIN4", 0)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Inicializou skin4 com 0...");
                    InitiateSkin5();
                }
                else
                {
                    //Debug.Log("Error Saving Skin4 Data...");
                }
            });
    }

    private void InitiateSkin5()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN5")
            .SetEventAttribute("SKIN5", 0)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Inicializou skin5 com 0...");
                    InitiateSkin6();
                }
                else
                {
                    //Debug.Log("Error Saving Skin5 Data...");
                }
            });
    }

    private void InitiateSkin6()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN6")
            .SetEventAttribute("SKIN6", 0)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    InitiateSkin7();
                    //Debug.Log("Inicializou skin6 com 0...");
                }
                else
                {
                    //Debug.Log("Error Saving Skin6 Data...");
                }
            });
    }

    private void InitiateSkin7()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN7")
            .SetEventAttribute("SKIN7", 0)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    InitiateSkin8();
                    //Debug.Log("Inicializou skin6 com 0...");
                }
                else
                {
                    //Debug.Log("Error Saving Skin6 Data...");
                }
            });
    }

    private void InitiateSkin8()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN8")
            .SetEventAttribute("SKIN8", 0)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    InitiateSkin9();
                    //Debug.Log("Inicializou skin6 com 0...");
                }
                else
                {
                    //Debug.Log("Error Saving Skin6 Data...");
                }
            });
    }

    private void InitiateSkin9()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN9")
            .SetEventAttribute("SKIN9", 0)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    InitiateSkin10();
                    //Debug.Log("Inicializou skin6 com 0...");
                }
                else
                {
                    //Debug.Log("Error Saving Skin6 Data...");
                }
            });
    }

    private void InitiateSkin10()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN10")
            .SetEventAttribute("SKIN10", 0)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    InitiateSkin11();
                    //Debug.Log("Inicializou skin6 com 0...");
                }
                else
                {
                    //Debug.Log("Error Saving Skin6 Data...");
                }
            });
    }

    private void InitiateSkin11()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN11")
            .SetEventAttribute("SKIN11", 0)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    InitiateSkin12();
                    //Debug.Log("Inicializou skin6 com 0...");
                }
                else
                {
                    //Debug.Log("Error Saving Skin6 Data...");
                }
            });
    }

    private void InitiateSkin12()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN12")
            .SetEventAttribute("SKIN12", 0)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    InitiateSkin13();
                    //Debug.Log("Inicializou skin6 com 0...");
                }
                else
                {
                    //Debug.Log("Error Saving Skin6 Data...");
                }
            });
    }

    private void InitiateSkin13()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN13")
            .SetEventAttribute("SKIN13", 0)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Inicializou skin6 com 0...");
                    InitiateMark();
                }
                else
                {
                    //Debug.Log("Error Saving Skin6 Data...");
                }
            });
    }

    private void InitiateMark()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_MARK")
            .SetEventAttribute("MARK", 0)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Inicializou minimapa com 0...");
                }
                else
                {
                    //Debug.Log("Error Saving Minimap Data...");
                }
            });
    }
}