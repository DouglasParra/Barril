using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class RankingScript : MonoBehaviour {

    public Text[] record;
    //public string timestring;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < record.Length; i++) {
            record[i].text = GameSparksManager.records[i];
        }
	}

    /*public void SaveTime(string t) {
        timestring = t;

        if (SceneManager.GetActiveScene().name.Equals("1-1"))
        {
            SalvarTempoGameSparks_1_1();
        }
        else if (SceneManager.GetActiveScene().name.Equals("1-2"))
        {
            SalvarTempoGameSparks_1_2();
        }
        else if (SceneManager.GetActiveScene().name.Equals("1-3"))
        {
            SalvarTempoGameSparks_1_3();
        }
        else if (SceneManager.GetActiveScene().name.Equals("1-4"))
        {
            SalvarTempoGameSparks_1_4();
        }
        else if (SceneManager.GetActiveScene().name.Equals("1-5"))
        {
            SalvarTempoGameSparks_1_5();
        }
        else if (SceneManager.GetActiveScene().name.Equals("1-6"))
        {
            SalvarTempoGameSparks_1_6();
        }
        else if (SceneManager.GetActiveScene().name.Equals("1-7"))
        {
            SalvarTempoGameSparks_1_7();
        }
        else if (SceneManager.GetActiveScene().name.Equals("1-8"))
        {
            SalvarTempoGameSparks_1_8();
        }
        else if (SceneManager.GetActiveScene().name.Equals("1-9"))
        {
            SalvarTempoGameSparks_1_9();
        }
        else if (SceneManager.GetActiveScene().name.Equals("1-10"))
        {
            SalvarTempoGameSparks_1_10();
        }
    }

    void SalvarTempoGameSparks_1_1()
    {

        // Se arg1 > arg2, compare==1
        // Debug.Log("Tempo salvo no GS: " + loadedTime + " - Tempo desse jogo: " + timestring);
        if (string.Compare(timestring, GameSparksManager.records[0]) == -1)
        {
            GameSparksManager.records[0] = timestring;

            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_STAGE_1_1")
                .SetEventAttribute("TIME_1_1", timestring)
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Player Saved To GameSparks...");
                    }
                    else
                    {
                        Debug.Log("Error Saving Player Data...");
                    }
                });
        }
    }

    void SalvarTempoGameSparks_1_2()
    {

        // Se arg1 > arg2, compare==1
        // Debug.Log("Tempo salvo no GS: " + loadedTime + " - Tempo desse jogo: " + timestring);
        if (string.Compare(timestring, GameSparksManager.records[1]) == -1)
        {
            GameSparksManager.records[1] = timestring;

            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_STAGE_1_2")
                .SetEventAttribute("TIME_1_2", timestring)
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Player Saved To GameSparks...");
                    }
                    else
                    {
                        Debug.Log("Error Saving Player Data...");
                    }
                });
        }
    }

    void SalvarTempoGameSparks_1_3()
    {

        // Se arg1 > arg2, compare==1
        // Debug.Log("Tempo salvo no GS: " + loadedTime + " - Tempo desse jogo: " + timestring);
        if (string.Compare(timestring, GameSparksManager.records[2]) == -1)
        {
            GameSparksManager.records[2] = timestring;

            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_STAGE_1_3")
                .SetEventAttribute("TIME_1_3", timestring)
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Player Saved To GameSparks...");
                    }
                    else
                    {
                        Debug.Log("Error Saving Player Data...");
                    }
                });
        }
    }

    void SalvarTempoGameSparks_1_4()
    {

        // Se arg1 > arg2, compare==1
        // Debug.Log("Tempo salvo no GS: " + loadedTime + " - Tempo desse jogo: " + timestring);
        if (string.Compare(timestring, GameSparksManager.records[3]) == -1)
        {
            GameSparksManager.records[3] = timestring;

            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_STAGE_1_4")
                .SetEventAttribute("TIME_1_4", timestring)
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Player Saved To GameSparks...");
                    }
                    else
                    {
                        Debug.Log("Error Saving Player Data...");
                    }
                });
        }
    }

    void SalvarTempoGameSparks_1_5()
    {

        // Se arg1 > arg2, compare==1
        // Debug.Log("Tempo salvo no GS: " + loadedTime + " - Tempo desse jogo: " + timestring);
        if (string.Compare(timestring, GameSparksManager.records[4]) == -1)
        {
            GameSparksManager.records[4] = timestring;

            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_STAGE_1_5")
                .SetEventAttribute("TIME_1_5", timestring)
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Player Saved To GameSparks...");
                    }
                    else
                    {
                        Debug.Log("Error Saving Player Data...");
                    }
                });
        }
    }

    void SalvarTempoGameSparks_1_6()
    {

        // Se arg1 > arg2, compare==1
        // Debug.Log("Tempo salvo no GS: " + loadedTime + " - Tempo desse jogo: " + timestring);
        if (string.Compare(timestring, GameSparksManager.records[5]) == -1)
        {
            GameSparksManager.records[5] = timestring;

            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_STAGE_1_6")
                .SetEventAttribute("TIME_1_6", timestring)
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Player Saved To GameSparks...");
                    }
                    else
                    {
                        Debug.Log("Error Saving Player Data...");
                    }
                });
        }
    }

    void SalvarTempoGameSparks_1_7()
    {

        // Se arg1 > arg2, compare==1
        // Debug.Log("Tempo salvo no GS: " + loadedTime + " - Tempo desse jogo: " + timestring);
        if (string.Compare(timestring, GameSparksManager.records[6]) == -1)
        {
            GameSparksManager.records[6] = timestring;

            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_STAGE_1_7")
                .SetEventAttribute("TIME_1_7", timestring)
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Player Saved To GameSparks...");
                    }
                    else
                    {
                        Debug.Log("Error Saving Player Data...");
                    }
                });
        }
    }

    void SalvarTempoGameSparks_1_8()
    {

        // Se arg1 > arg2, compare==1
        // Debug.Log("Tempo salvo no GS: " + loadedTime + " - Tempo desse jogo: " + timestring);
        if (string.Compare(timestring, GameSparksManager.records[7]) == -1)
        {
            GameSparksManager.records[7] = timestring;

            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_STAGE_1_8")
                .SetEventAttribute("TIME_1_8", timestring)
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Player Saved To GameSparks...");
                    }
                    else
                    {
                        Debug.Log("Error Saving Player Data...");
                    }
                });
        }
    }

    void SalvarTempoGameSparks_1_9()
    {

        // Se arg1 > arg2, compare==1
        // Debug.Log("Tempo salvo no GS: " + loadedTime + " - Tempo desse jogo: " + timestring);
        if (string.Compare(timestring, GameSparksManager.records[8]) == -1)
        {
            GameSparksManager.records[8] = timestring;

            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_STAGE_1_9")
                .SetEventAttribute("TIME_1_9", timestring)
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Player Saved To GameSparks...");
                    }
                    else
                    {
                        Debug.Log("Error Saving Player Data...");
                    }
                });
        }
    }

    void SalvarTempoGameSparks_1_10()
    {

        // Se arg1 > arg2, compare==1
        // Debug.Log("Tempo salvo no GS: " + loadedTime + " - Tempo desse jogo: " + timestring);
        if (string.Compare(timestring, GameSparksManager.records[9]) == -1)
        {
            GameSparksManager.records[9] = timestring;

            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_STAGE_1_10")
                .SetEventAttribute("TIME_1_10", timestring)
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        Debug.Log("Player Saved To GameSparks...");
                    }
                    else
                    {
                        Debug.Log("Error Saving Player Data...");
                    }
                });
        }
    }*/

}
