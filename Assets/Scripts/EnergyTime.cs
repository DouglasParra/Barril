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
    public Text lifeLoja;

    public GameObject energyTimeBox;

    [HideInInspector]
    public GameObject gameSparksManager;

    private int MAX_VIDAS = 5;

	// Use this for initialization
	void Awake () {
        Time.timeScale = 1;
        //Debug.Log("Valor de Vidas em PlayerPrefs = " + PlayerPrefs.GetInt("Vidas"));
    }

    void Start()
    {
        gameSparksManager = GameObject.Find("GameSparks Manager");
        life.text = gameSparksManager.GetComponent<EnergyTimeValues>().getVidas().ToString();
    }
	
	// Update is called once per frame
	void Update () {
        time.text = gameSparksManager.GetComponent<EnergyTimeValues>().getMinutos().ToString("00") + ":" + gameSparksManager.GetComponent<EnergyTimeValues>().getSegundos().ToString("00");
        life.text = gameSparksManager.GetComponent<EnergyTimeValues>().getVidas().ToString();
        lifeLoja.text = gameSparksManager.GetComponent<EnergyTimeValues>().getVidas().ToString();

        if (int.Parse(life.text) >= MAX_VIDAS)
        {
            gameSparksManager.GetComponent<EnergyTimeValues>().PararCountdownTimer();
            gameSparksManager.GetComponent<EnergyTimeValues>().setMinutos(10);
            gameSparksManager.GetComponent<EnergyTimeValues>().setSegundos(0);
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
}
