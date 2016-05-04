using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Net.Cache;
using System;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using GameSparks.Core;

public class EnergyTime : MonoBehaviour {

    public Text time;
    public Text life;

    public GameObject energyTimeBox;
    public GameObject gameSparksManager;

    private int MAX_VIDAS = 5;
    private int SEGUNDOS_PARA_VIDA = 600;

    private int NUMERO_TESTE = 2995;

    public int minutos;
    public int segundos;

    private bool canRunTime;

	// Use this for initialization
	void Awake () {
        Time.timeScale = 1;

        gameSparksManager = GameObject.Find("GameSparks Manager");

        // Pegar vida salva do GameSparks
        LoadLife();
    }

    IEnumerator CountdownTimer()
    {
        yield return new WaitForSeconds(1);

        segundos -= 1;

        if (segundos < 0)
        {
            segundos = 59;
            minutos -= 1;
        }

        if (minutos < 0)
        {
            life.text = (int.Parse(life.text) + 1).ToString();
            SaveLife(int.Parse(life.text));
            minutos = 9;
        }

        time.text = minutos.ToString("00") + ":" + segundos.ToString("00");

        yield return StartCoroutine("CountdownTimer");
    }
	
	// Update is called once per frame
	void Update () {

        if (int.Parse(life.text) >= MAX_VIDAS)
        {
            canRunTime = false;
            StopCoroutine("CountdownTimer");
            time.text = "10:00";
            PlayerPrefs.SetString("Minutos", "10");
            PlayerPrefs.SetString("Segundos", "00");
            energyTimeBox.SetActive(false);
        }
	}

    // Pega a informação de tempo da internet
    public static DateTime GetNistTime()
    {
        DateTime dateTime = DateTime.MinValue;

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://nist.time.gov/actualtime.cgi?lzbc=siqm9b");
        request.Method = "GET";
        request.Accept = "text/html, application/xhtml+xml, */*";
        request.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/6.0)";
        request.ContentType = "application/x-www-form-urlencoded";
        request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore); //No caching
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        if (response.StatusCode == HttpStatusCode.OK)
        {
            StreamReader stream = new StreamReader(response.GetResponseStream());
            string html = stream.ReadToEnd();//<timestamp time=\"1395772696469995\" delay=\"1395772696469995\"/>
            string time = Regex.Match(html, @"(?<=\btime="")[^""]*").Value;
            double milliseconds = Convert.ToInt64(time) / 1000.0;
            dateTime = new DateTime(1970, 1, 1).AddMilliseconds(milliseconds).ToLocalTime();
        }

        return dateTime;
    }

    // Salva no GS o valor de vida passado como argumento
    private void SaveLife(int vida)
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("SAVE_LIFES")
            .SetEventAttribute("LIFE", vida)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    Debug.Log("Salvou o valor de vida como " + vida);
                }
                else
                {
                    Debug.Log("Error Saving Player Data...");
                }
            });
    }

    // Carrega o valor da vida
    private void LoadLife()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("RETRIEVE_RECORDS")
                .Send((response) =>
                {

                    if (!response.HasErrors)
                    {
                        GSData data = response.ScriptData.GetGSData("player_Data");
                        life.text = data.GetInt("life").ToString();
                        
                        Debug.Log("Recieved Player Life Data From GameSparks...");

                        initializeEnergyTime();
                    }
                    else
                    {
                        Debug.Log("Error Loading Player Data...");
                    }
                });
    }

    void initializeEnergyTime() {
        minutos = gameSparksManager.GetComponent<EnergyTimeValues>().getMinutos();
        segundos = gameSparksManager.GetComponent<EnergyTimeValues>().getSegundos();

        time.text = minutos.ToString("00") + ":" + segundos.ToString("00");

        if (int.Parse(life.text) < MAX_VIDAS)
        {
            // Cada vez que entra na cena, calcula o tempo guardado
            DateTime myDate = System.DateTime.Now;

            if (PlayerPrefs.HasKey("DateTime"))
            {
                myDate = DateTime.Parse(PlayerPrefs.GetString("DateTime"), System.Globalization.CultureInfo.InstalledUICulture);
            }

            Debug.Log("Se passaram " + (System.DateTime.Now - myDate).TotalSeconds + " segundos desde a última sessão");

            // Dá vidas de acordo com a quantidade de tempo que se passou
            if (int.Parse(life.text) < MAX_VIDAS)
            {
                int qtdeVidas = ((int)(System.DateTime.Now - myDate).TotalSeconds) / SEGUNDOS_PARA_VIDA;
                //int qtdeVidas = NUMERO_TESTE / SEGUNDOS_PARA_VIDA;

                while (int.Parse(life.text) < MAX_VIDAS && qtdeVidas > 0)
                {
                    life.text = (int.Parse(life.text) + 1).ToString();
                    qtdeVidas--;
                }
            }

            SaveLife(int.Parse(life.text));

            // Seta o tempo para próxima vida de acordo
            if (int.Parse(life.text) < MAX_VIDAS)
            {
                //int s = int.Parse(PlayerPrefs.GetString("Minutos")) * 60 + int.Parse(PlayerPrefs.GetString("Segundos"));
                int s = gameSparksManager.GetComponent<EnergyTimeValues>().getMinutos() * 60 + gameSparksManager.GetComponent<EnergyTimeValues>().getSegundos();

                int tempoRestante = s - (((int)(System.DateTime.Now - myDate).TotalSeconds));

                minutos = (tempoRestante / 60);
                segundos = (tempoRestante % 60);

                time.text = minutos.ToString("00") + ":" + segundos.ToString("00");
            }
        }

        if (int.Parse(life.text) < MAX_VIDAS)
        {
            canRunTime = true;
            StartCoroutine("CountdownTimer");
        }
        else
        {
            canRunTime = false;
            energyTimeBox.SetActive(false);
        }
    }

    void OnApplicationQuit()
    {
        gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(minutos);
        gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(segundos);
    }
}
