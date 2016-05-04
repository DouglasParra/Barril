using UnityEngine;
using System.Collections;

public class EnergyTimeValues : MonoBehaviour {

    private int minutos;
    private int segundos;

    private int tempoDesdeInicio;

    void Start() {
        tempoDesdeInicio = 0;
        minutos = int.Parse(PlayerPrefs.GetString("Minutos"));
        segundos = int.Parse(PlayerPrefs.GetString("Segundos"));
    }

    void Update() {

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

    void OnApplicationQuit()
    {
        tempoDesdeInicio = (int)(Time.realtimeSinceStartup - tempoDesdeInicio);

        minutos = minutos - tempoDesdeInicio / 60;
        segundos = segundos - tempoDesdeInicio % 60;

        PlayerPrefs.SetString("Minutos", minutos.ToString());
        PlayerPrefs.SetString("Segundos", segundos.ToString());
    }
}
