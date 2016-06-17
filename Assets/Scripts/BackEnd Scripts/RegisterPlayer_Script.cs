using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RegisterPlayer_Script : MonoBehaviour
{
    public Canvas registerPlayerCanvas;

    // Username generator
    private string characters = "0123456789abcdefghijklmnopqrstuvwx";
    private int DESIRED_CODE_LENGTH = 8;

    public Text displayNameInput; // these are set through the editor
    // , userNameInput, passwordInput

    private string userName;

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

    public void RegisterPlayerBttn()
    {
        Debug.Log("Registering Player...");

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
                    Debug.Log("Player Registered \n Player Name: " + response.DisplayName);
                    registerPlayerCanvas.gameObject.SetActive(false);

                    InitiateRecords();
                }
                else if (response.Errors.JSON.Equals("{\"USERNAME\":\"TAKEN\"}"))
                {
                    Debug.Log("Username iguais, deveria gerar outro...");
                }
                else
                {
                    Debug.Log("Error Registering Player... \n " + response.Errors.JSON.ToString());
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
                    Debug.Log("Player records initiated to GameSparks...");

                    // Jogar pro records[] do GameManager
                    GameSparksManager.records = new int[GameSparksManager.NUMERO_FASES];
                    for (int i=0; i < GameSparksManager.NUMERO_FASES; i++) {
                        GameSparksManager.records[i] = 9999999;
                    }

                    InitiateLife();
                }
                else
                {
                    Debug.Log("Error Saving Player Data...");
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
                    Debug.Log("Inicializou vida com 5...");

                    PlayerPrefs.SetString("Minutos", "10");
                    PlayerPrefs.SetString("Segundos", "00");

                    PlayerPrefs.SetFloat("sfxVol", -10.0f);
                    PlayerPrefs.SetFloat("musicVol", -10.0f);
                    PlayerPrefs.SetInt("soundOnOff", 1);

                    PlayerPrefs.SetInt("Laser", 0);
                    PlayerPrefs.SetInt("MiniMapa", 0);

                    InitiatePowercells();
                }
                else
                {
                    Debug.Log("Error Saving Player Data...");
                }
            });
    }

    private void InitiatePowercells()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("SAVE_POWERCELLS")
            .SetEventAttribute("POWERCELL", 5)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    Debug.Log("Inicializou powercells com 5...");
                    InitiateLaser();
                }
                else
                {
                    Debug.Log("Error Saving Player Data...");
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
                    Debug.Log("Inicializou laser com 0...");
                    InitiateMinimap();
                }
                else
                {
                    Debug.Log("Error Saving Player Data...");
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
                    Debug.Log("Inicializou minimapa com 0...");
                }
                else
                {
                    Debug.Log("Error Saving Player Data...");
                }
            });
    }

}