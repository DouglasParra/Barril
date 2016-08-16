using UnityEngine;
using System.Collections;
using GameSparks.Core;

public class SalvarTempoOffline : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SalvarTempo();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void SalvarTempo(){
        for(int i=1; i<=8; i++){
            for(int j=1; j<=10; j++){
                if(PlayerPrefs.HasKey("LEADERBOARD_" + i + "_" + j)){
                    Debug.Log(PlayerPrefs.GetInt("LEADERBOARD_" + i + "_" + j));
                    SalvarTempoGameSparks(i, j);
                }
            }
        }
    }

    // Salva tempo no GS pro Leaderboard da fase que está jogando
    void SalvarTempoGameSparks(int i, int j)
    {
            // mudar no gs para ficar 1-1 e assim usar o nome da cena concatenado
            new GameSparks.Api.Requests.LogEventRequest()
                .SetEventKey("SAVE_STAGE_" + i + "_" + j)
                .SetEventAttribute("TIME_" + i + "_" + j, PlayerPrefs.GetInt("LEADERBOARD_" + i + "_" + j))
                .SetDurable(true)
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        //Debug.Log("Player Saved To GameSparks...");
                        //Debug.Log("Score Posted Sucessfully...");
                        Debug.Log("Salvou tempo da fase " + i + "-" + j);
                        PlayerPrefs.DeleteKey("LEADERBOARD_" + i + "_" + j);
                    }
                    else
                    {
                        //Debug.Log("Error Saving Player Data...");

                    }
                });
    }
}
