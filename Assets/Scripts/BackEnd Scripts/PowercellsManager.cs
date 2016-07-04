using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GameSparks.Core;

public class PowercellsManager : MonoBehaviour {
    
    public Text powercells;
    public Text powercellsLoja;

	// Use this for initialization
	void Start () {

        // Se está online, carrega o valor de powercells
        if (!GameObject.Find("GameSparks Manager").GetComponent<ModoOffline>().getModoOffline())
        {
            LoadPowercells();
        }
	}

    private void LoadPowercells()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("RETRIEVE_RECORDS")
                .Send((response) =>
                {
                    if (!response.HasErrors)
                    {
                        GSData data = response.ScriptData.GetGSData("player_Data");
                        powercells.text = data.GetInt("powercell").ToString();
                        powercellsLoja.text = powercells.text;

                        //Debug.Log("Recieved Player Powercells Data From GameSparks...");
                    }
                    else
                    {
                        //Debug.Log("Error Loading Player Data...");
                    }
                });        
    }

    public void SavePowercells(int value)
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("SAVE_POWERCELLS")
            .SetEventAttribute("POWERCELL", int.Parse(powercells.text) + value)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Adicionou " + value + " powercells");
                    powercells.text = (int.Parse(powercells.text) + value).ToString();
                    powercellsLoja.text = powercells.text;
                }
                else
                {
                    //Debug.Log("Error Saving Player Data...");
                }
            });
    }
}
