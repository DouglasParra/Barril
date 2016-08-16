using UnityEngine;
using System.Collections;
using GameSparks.Core;

public class EnergyTimeValues : MonoBehaviour {

    private int minutos;
    private int segundos;
    private int vidas;
    [SerializeField]
    private int powercells;

    private int tempoDesdeInicio;

    void Start() {
        tempoDesdeInicio = 0;
        minutos = int.Parse(PlayerPrefs.GetString("Minutos"));
        segundos = int.Parse(PlayerPrefs.GetString("Segundos"));
    }

    public void setMinutos(int m) {
        minutos = m;
    }

    public int getMinutos() {
        return minutos;
    }

    public void setSegundos(int s)
    {
        segundos = s;
    }

    public int getSegundos()
    {
        return segundos;
    }

    public void setTempoDesdeInicio(int t)
    {
        tempoDesdeInicio = t;
    }

    public int getTempoDesdeInicio()
    {
        return tempoDesdeInicio;
    }

    public void SavePlayerPrefsMinutesSeconds() {
        tempoDesdeInicio = (int)(Time.realtimeSinceStartup - tempoDesdeInicio);

        minutos = minutos - tempoDesdeInicio / 60;
        segundos = segundos - tempoDesdeInicio % 60;

        PlayerPrefs.SetString("Minutos", minutos.ToString());
        PlayerPrefs.SetString("Segundos", segundos.ToString());
    }

    public void LoadPowercells()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("RETRIEVE_RECORDS")
                .Send((response) =>
                {
                    if (!response.HasErrors)
                    {
                        GSData data = response.ScriptData.GetGSData("player_Data");
                        powercells = (int)data.GetInt("powercell");

                        //Debug.Log("Recieved Player Powercells Data From GameSparks...");
                    }
                    else
                    {
                        //Debug.Log("Error Loading Player Powercell Data...");
                    }
                });
    }

    public void SavePowercells(int value)
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("SAVE_POWERCELLS")
            .SetEventAttribute("POWERCELL", value)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Adicionou " + value + " powercells");
                    powercells = value;
                }
                else
                {
                    //Debug.Log("Error Saving Player Data...");
                }
            });
    }

    public int getPowercells()
    {
        return powercells;
    }

    public void setPowercells(int value)
    {
        powercells = value;
    }
}
