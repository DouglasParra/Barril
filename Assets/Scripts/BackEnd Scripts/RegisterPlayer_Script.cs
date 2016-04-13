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
            .SetEventAttribute("TIME_1_1", 999999)
            .SetEventAttribute("TIME_1_2", 999999)
            .SetEventAttribute("TIME_1_3", 999999)
            .SetEventAttribute("TIME_1_4", 999999)
            .SetEventAttribute("TIME_1_5", 999999)
            .SetEventAttribute("TIME_1_6", 999999)
            .SetEventAttribute("TIME_1_7", 999999)
            .SetEventAttribute("TIME_1_8", 999999)
            .SetEventAttribute("TIME_1_9", 999999)
            .SetEventAttribute("TIME_1_10", 999999)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    Debug.Log("Player records initiated to GameSparks...");

                    // Jogar pro records[] do GameManager
                    GameSparksManager.records = new int[GameSparksManager.NUMERO_FASES];
                    for (int i=0; i < GameSparksManager.NUMERO_FASES; i++) {
                        GameSparksManager.records[i] = 999999;
                    }
                }
                else
                {
                    Debug.Log("Error Saving Player Data...");
                }
            });
    }

}