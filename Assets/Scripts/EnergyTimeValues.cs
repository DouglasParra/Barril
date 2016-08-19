using System;
using UnityEngine;
using UnityEngine.UI;
using GameSparks.Core;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnergyTimeValues : MonoBehaviour {

    [SerializeField]
    private int minutos;
    [SerializeField]
    private int segundos;
    [SerializeField]
    private int vidas;
    [SerializeField]
    private int powercells;

    private int MAX_VIDAS = 5;
    private int SEGUNDOS_PARA_VIDA = 600;

    	// Use this for initialization
    void Awake()
    {
        Time.timeScale = 1;
    }

    void Start() {
        if (PlayerPrefs.HasKey("Minutos"))
        {
            minutos = int.Parse(PlayerPrefs.GetString("Minutos"));
        }
        else
        {
            PlayerPrefs.SetString("Minutos", "10");
            minutos = 10;
        }

        if (PlayerPrefs.HasKey("Segundos"))
        {
            segundos = int.Parse(PlayerPrefs.GetString("Segundos"));
        }
        else
        {
            PlayerPrefs.SetString("Segundos", "00");
            segundos = 0;
        }

        if (PlayerPrefs.HasKey("Vidas"))
        {
            vidas = PlayerPrefs.GetInt("Vidas");
        }
        else
        {
            PlayerPrefs.SetInt("Vidas", 5);
            vidas = 5;
        }

        StartCoroutine("CarregarVida");
    }

    IEnumerator CarregarVida()
    {
        // Chama o teste de conexão em Modo Offline
        GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        // Se tem conexão com internet
        if (!GetComponent<ModoOffline>().getModoOffline())
        {
            // Pegar vida salva do GameSparks
            LoadLife();
            //SincronizarVidas();
            //initializeEnergyTime();
        }
        else
        {
            // Pega vida salva no PlayerPrefs
            vidas = PlayerPrefs.GetInt("Vidas");
            initializeEnergyTime();
        }
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
                        vidas = (int)data.GetInt("life");

                        //Debug.Log("Recieved Player Life Data From GameSparks...");
                        SincronizarVidas();

                        initializeEnergyTime();
                    }
                    else
                    {
                        //Debug.Log("Error Loading Player Data...");
                    }
                });
    }

    void initializeEnergyTime()
    {
        // Fazer o cálculo de quanto tempo se passou
        DateTime d1 = DateTime.Parse(PlayerPrefs.GetString("DateTime"));
        DateTime d2 = DateTime.Now;
        double d3 = (d2 - d1).TotalSeconds;

        //Debug.Log("Se passaram " + (int)d3 + " segundos desde que saiu. Vidas = " + vidas);

        // Dar vidas se passou mais de 10 minutos
        while (d3 >= SEGUNDOS_PARA_VIDA)
        {
            if (vidas < MAX_VIDAS)
            {
                vidas++;
            }
            else
            {
                break;
            }
            Debug.Log("Deu uma vida");
            d3 -= 600;
        }

        // Salva no GameSparks e no PlayerPrefs
        SaveLife(vidas);
        PlayerPrefs.SetInt("Vidas", vidas);

        // Saiu com menos de 10 minutos
        if (vidas < 5)
        {
            int s = minutos * 60 + segundos;
            int tempoRestante = s - (int)d3;
            minutos = (tempoRestante / 60);
            segundos = (tempoRestante % 60);

            // Inicia contagem
            StartCoroutine("CountdownTimer");
        }
        else
        {
            minutos = 10;
            segundos = 0;

            PlayerPrefs.SetString("Minutos", "10");
            PlayerPrefs.SetString("Segundos", "00");
        }
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
            vidas++;

            SaveLife(vidas);
            PlayerPrefs.SetInt("Vidas", vidas);

            // Verificar se está em jogo e dar vida
            if (SceneManager.GetActiveScene().name.Contains("-"))
            {
                GiveLifeInGame();
            }

            minutos = 9;

            if (vidas >= MAX_VIDAS)
            {
                minutos = 10;
                segundos = 0;
                PlayerPrefs.SetString("Minutos", "10");
                PlayerPrefs.SetString("Segundos", "00");
            }
        }

        yield return StartCoroutine("CountdownTimer");
    }

    private void GiveLifeInGame()
    {
        GameObject e = GameObject.Find("EnergyText");
        e.GetComponent<Text>().text = vidas.ToString();
    }

    public void IniciarCountdownTimer()
    {
        Time.timeScale = 1;
        StartCoroutine("CountdownTimer");
    }

    public void PararCountdownTimer()
    {
        StopCoroutine("CountdownTimer");
    }

    public void SincronizarVidas()
    {
        StartCoroutine("VerificarConexaoSincronizar");
    }

    IEnumerator VerificarConexaoSincronizar()
    {
        // Chama o teste de conexão em Modo Offline
        GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        if (!GetComponent<ModoOffline>().getModoOffline())
        {
            //LoadLife();

            //Debug.Log("Pre: SaveLife em SincronizarVidas " + life.text);

            // PlayerPrefs sempre estará com o valor certo de vidas
            if (PlayerPrefs.GetInt("Vidas") != vidas)
            {
                SaveLife(PlayerPrefs.GetInt("Vidas"));
                vidas = PlayerPrefs.GetInt("Vidas");
                //LoadLife();
            }

            //Debug.Log("Pos: SaveLife em SincronizarVidas " + life.text);
        }
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
                    //Debug.Log("Salvou o valor de vida como " + vida);
                }
                else
                {
                    //Debug.Log("Error Saving Player Data...");
                }
            });
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

    public void setVidas(int v)
    {
        vidas = v;
    }

    public int getVidas()
    {
        return vidas;
    }

    public int getPowercells()
    {
        return powercells;
    }

    public void setPowercells(int value)
    {
        powercells = value;
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


    public void GanharVida()
    {
        vidas++;
        PlayerPrefs.SetInt("Vidas", vidas);

        StartCoroutine("SaveLife", vidas);
        //Debug.Log("Pre: SaveLife em CountdownTimer " + life.text);
        /*if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            SaveLife(int.Parse(life.text));
        }*/
        //Debug.Log("Pos: SaveLife em CountdownTimer " + life.text);
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.SetString("Minutos", minutos.ToString());
        PlayerPrefs.SetString("Segundos", segundos.ToString());
        PlayerPrefs.SetInt("Vidas", vidas);
        PlayerPrefs.SetString("DateTime", DateTime.Now.ToString());		// "DateTime" no Barril
    }
}
