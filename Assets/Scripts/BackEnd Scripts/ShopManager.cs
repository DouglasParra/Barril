using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GameSparks.Core;

public class ShopManager : MonoBehaviour {

    public Text energyText;
    public Text energyTextLoja;
    public GameObject powercellsManager;
    public GameObject gameSparksManager;
    public GameObject confirmarCompraPanel;

    [Space(10)]
    [Header("Vidas")]
    public Button comprar5Vidas;
    public Button comprar10Vidas;
    public Button comprar20Vidas;
    public Button comprar50Vidas;

    [Space(10)]
    [Header("Skins")]
    public Button comprarSkin1;
    public Button comprarSkin2;
    public Button comprarSkin3;
    public Button comprarSkin4;
    public Button comprarSkin5;
    public Button comprarSkin6;
    public Button comprarSkin7;
    public Button comprarSkin8;
    public Button comprarSkin9;
    public Button comprarSkin10;
    public Button comprarSkin11;
    public Button comprarSkin12;
    public Button comprarSkin13;

    public Toggle skin1Toggle;
    public Toggle skin2Toggle;
    public Toggle skin3Toggle;
    public Toggle skin4Toggle;
    public Toggle skin5Toggle;
    public Toggle skin6Toggle;
    public Toggle skin7Toggle;
    public Toggle skin8Toggle;
    public Toggle skin9Toggle;
    public Toggle skin10Toggle;
    public Toggle skin11Toggle;
    public Toggle skin12Toggle;
    public Toggle skin13Toggle;

    [Space(10)]
    [Header("Boosts")]
    public Button comprarLaser;
    public Button comprarMinimapa;
    public Button comprarMark;
    public Toggle laserToggle;
    public Toggle minimapToggle;
    public Toggle markToggle;

    [Space(10)]
    public GameObject notEnoughPowercell;
    public GameObject buyLife;

    private const int MAX_VIDAS = 99;

    private const int CUSTO_5_VIDAS = 7;
    private const int CUSTO_10_VIDAS = 13;
    private const int CUSTO_20_VIDAS = 24;
    private const int CUSTO_50_VIDAS = 68;

    private const int CUSTO_SKIN1 = 30;
    private const int CUSTO_SKIN2 = 30;
    private const int CUSTO_SKIN3 = 30;
    private const int CUSTO_SKIN4 = 30;
    private const int CUSTO_SKIN5 = 30;
    private const int CUSTO_SKIN6 = 30;
    private const int CUSTO_SKIN7 = 30;
    private const int CUSTO_SKIN8 = 30;
    private const int CUSTO_SKIN9 = 30;
    private const int CUSTO_SKIN10 = 30;
    private const int CUSTO_SKIN11 = 30;
    private const int CUSTO_SKIN12 = 30;
    private const int CUSTO_SKIN13 = 30;

    private const int CUSTO_LASER = 80;
    private const int CUSTO_MINIMAPA = 130;
    private const int CUSTO_MARK = 80;

    private string itemPurchased;

    void Start() {
        gameSparksManager = GameObject.Find("GameSparks Manager");
        energyTextLoja.text = energyText.text;

        VerificarVidas();

        StartCoroutine("CarregarInformacoesBoosts");

        // Se não está no modo offline
        /*if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            // Não carrega as informações de boosts e skins
            LoadBoostsInfo();
        }*/
    }

    void Update()
    {
        VerificarVidas();
    }

    private void VerificarVidas() {
        if (int.Parse(energyText.text) + 5 > MAX_VIDAS)
        {
            comprar5Vidas.interactable = false;
        }

        if (int.Parse(energyText.text) + 10 > MAX_VIDAS)
        {
            comprar10Vidas.interactable = false;
        }

        if (int.Parse(energyText.text) + 20 > MAX_VIDAS)
        {
            comprar20Vidas.interactable = false;
        }

        if (int.Parse(energyText.text) + 50 > MAX_VIDAS)
        {
            comprar50Vidas.interactable = false;
        }
    }

    private bool haveEnoughPowercells(int value) { 
        if(int.Parse(powercellsManager.GetComponent<PowercellsManager>().powercells.text) - value >= 0) return true;

        notEnoughPowercell.GetComponent<AudioSource>().Play();
        return false;
    }
    
	public void Comprar5Vidas () {
        StartCoroutine("VerificarConexaoComprar5Vidas");
	}

    public void Comprar10Vidas()
    {
        StartCoroutine("VerificarConexaoComprar10Vidas");
    }

    public void Comprar20Vidas()
    {
        StartCoroutine("VerificarConexaoComprar20Vidas");
    }

    public void Comprar50Vidas()
    {
        StartCoroutine("VerificarConexaoComprar50Vidas");
    }

    public void ComprarSkin1()
    {
        StartCoroutine("VerificarConexaoComprarSkin1");
    }

    public void ComprarSkin2()
    {
        StartCoroutine("VerificarConexaoComprarSkin2");
    }

    public void ComprarSkin3()
    {
        StartCoroutine("VerificarConexaoComprarSkin3");
    }

    public void ComprarSkin4()
    {
        StartCoroutine("VerificarConexaoComprarSkin4");
    }

    public void ComprarSkin5()
    {
        StartCoroutine("VerificarConexaoComprarSkin5");
    }

    public void ComprarSkin6()
    {
        StartCoroutine("VerificarConexaoComprarSkin6");
    }

    public void ComprarSkin7()
    {
        StartCoroutine("VerificarConexaoComprarSkin7");
    }

    public void ComprarSkin8()
    {
        StartCoroutine("VerificarConexaoComprarSkin8");
    }

    public void ComprarSkin9()
    {
        StartCoroutine("VerificarConexaoComprarSkin9");
    }

    public void ComprarSkin10()
    {
        StartCoroutine("VerificarConexaoComprarSkin10");
    }

    public void ComprarSkin11()
    {
        StartCoroutine("VerificarConexaoComprarSkin11");
    }

    public void ComprarSkin12()
    {
        StartCoroutine("VerificarConexaoComprarSkin12");
    }

    public void ComprarSkin13()
    {
        StartCoroutine("VerificarConexaoComprarSkin13");
    }

    public void ComprarLaser()
    {
        StartCoroutine("VerificarConexaoComprarLaser");
    }

    public void ComprarMinimapa()
    {
        StartCoroutine("VerificarConexaoComprarMinimapa");
    }

    public void ComprarMark()
    {
        StartCoroutine("VerificarConexaoComprarMark");
    }

    public void RetirarPowercells(int value) {
        powercellsManager.GetComponent<PowercellsManager>().SavePowercells(-value);
    }

    public void AdicionarVidas(int value) {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("SAVE_LIFES")
            .SetEventAttribute("LIFE", (int.Parse(energyText.text) + value))
            .Send((respons) =>
            {

                if (!respons.HasErrors)
                {
                    gameSparksManager.GetComponent<EnergyTimeValues>().setVidas(int.Parse(energyText.text) + value);
                    energyText.text = (int.Parse(energyText.text) + value).ToString();
                    energyTextLoja.text = energyText.text;
                    //Debug.Log("Adicionou " + value + " vidas");
                }
                else
                {
                    //Debug.Log("Error Saving Player Data...");
                }
            });
    }

    private void LoadBoostsInfo()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("RETRIEVE_RECORDS")
                .Send((response) =>
                {
                    if (!response.HasErrors)
                    {
                        GSData data = response.ScriptData.GetGSData("player_Data");
                        int laser = (int)data.GetInt("laser");
                        int minimapa = (int)data.GetInt("minimap");
                        int mark = (int)data.GetInt("mark");

                        int skin1 = (int)data.GetInt("skin1");
                        int skin2 = (int)data.GetInt("skin2");
                        int skin3 = (int)data.GetInt("skin3");
                        int skin4 = (int)data.GetInt("skin4");
                        int skin5 = (int)data.GetInt("skin5");
                        int skin6 = (int)data.GetInt("skin6");
                        int skin7 = (int)data.GetInt("skin7");
                        int skin8 = (int)data.GetInt("skin8");
                        int skin9 = (int)data.GetInt("skin9");
                        int skin10 = (int)data.GetInt("skin10");
                        int skin11 = (int)data.GetInt("skin11");
                        int skin12 = (int)data.GetInt("skin12");
                        int skin13 = (int)data.GetInt("skin13");

                        // Se o laser foi comprado
                        if (laser != 0)
                        {
                            // Pode ligar / desligar laser
                            laserToggle.interactable = true;
                            comprarLaser.interactable = false;
                        }
                        else 
                        {
                            // Só pode ligar / desligar laser depois de comprar
                            laserToggle.interactable = false;
                            comprarLaser.interactable = true;
                        }

                        // Se o minimapa foi comprado
                        if (minimapa != 0)
                        {
                            // Pode ligar / desligar minimapa
                            minimapToggle.interactable = true;
                            comprarMinimapa.interactable = false;
                        }
                        else
                        {
                            // Só pode ligar / desligar minimapa depois de comprar
                            minimapToggle.interactable = false;
                            comprarMinimapa.interactable = true;
                        }

                        // Se a marca foi comprada
                        if (mark != 0)
                        {
                            // Pode ligar / desligar marca
                            markToggle.interactable = true;
                            comprarMark.interactable = false;
                        }
                        else
                        {
                            // Só pode ligar / desligar marca depois de comprar
                            markToggle.interactable = false;
                            comprarMark.interactable = true;
                        }

                        // Se skin 1 foi comprada
                        if (skin1 != 0)
                        {
                            // Pode ligar / desligar skin1
                            skin1Toggle.interactable = true;
                            comprarSkin1.interactable = false;
                        }
                        else
                        {
                            // Só pode ligar / desligar skin1 depois de comprar
                            skin1Toggle.interactable = false;
                            comprarSkin1.interactable = true;
                        }

                        // Se skin 2 foi comprada
                        if (skin2 != 0)
                        {
                            // Pode ligar / desligar skin2
                            skin2Toggle.interactable = true;
                            comprarSkin2.interactable = false;
                        }
                        else
                        {
                            // Só pode ligar / desligar skin2 depois de comprar
                            skin2Toggle.interactable = false;
                            comprarSkin2.interactable = true;
                        }

                        // Se skin 3 foi comprada
                        if (skin3 != 0)
                        {
                            // Pode ligar / desligar skin3
                            skin3Toggle.interactable = true;
                            comprarSkin3.interactable = false;
                        }
                        else
                        {
                            // Só pode ligar / desligar skin3 depois de comprar
                            skin3Toggle.interactable = false;
                            comprarSkin3.interactable = true;
                        }

                        // Se skin 4 foi comprada
                        if (skin4 != 0)
                        {
                            // Pode ligar / desligar skin4
                            skin4Toggle.interactable = true;
                            comprarSkin4.interactable = false;
                        }
                        else
                        {
                            // Só pode ligar / desligar skin4 depois de comprar
                            skin4Toggle.interactable = false;
                            comprarSkin4.interactable = true;
                        }

                        // Se skin 5 foi comprada
                        if (skin5 != 0)
                        {
                            // Pode ligar / desligar skin5
                            skin5Toggle.interactable = true;
                            comprarSkin5.interactable = false;
                        }
                        else
                        {
                            // Só pode ligar / desligar skin5 depois de comprar
                            skin5Toggle.interactable = false;
                            comprarSkin5.interactable = true;
                        }

                        // Se skin 6 foi comprada
                        if (skin6 != 0)
                        {
                            // Pode ligar / desligar skin6
                            skin6Toggle.interactable = true;
                            comprarSkin6.interactable = false;
                        }
                        else
                        {
                            // Só pode ligar / desligar skin6 depois de comprar
                            skin6Toggle.interactable = false;
                            comprarSkin6.interactable = true;
                        }

                        // Se skin 6 foi comprada
                        if (skin7 != 0)
                        {
                            // Pode ligar / desligar skin6
                            skin7Toggle.interactable = true;
                            comprarSkin7.interactable = false;
                        }
                        else
                        {
                            // Só pode ligar / desligar skin6 depois de comprar
                            skin7Toggle.interactable = false;
                            comprarSkin7.interactable = true;
                        }

                        // Se skin 6 foi comprada
                        if (skin8 != 0)
                        {
                            // Pode ligar / desligar skin6
                            skin8Toggle.interactable = true;
                            comprarSkin8.interactable = false;
                        }
                        else
                        {
                            // Só pode ligar / desligar skin6 depois de comprar
                            skin8Toggle.interactable = false;
                            comprarSkin8.interactable = true;
                        }

                        // Se skin 6 foi comprada
                        if (skin9 != 0)
                        {
                            // Pode ligar / desligar skin6
                            skin9Toggle.interactable = true;
                            comprarSkin9.interactable = false;
                        }
                        else
                        {
                            // Só pode ligar / desligar skin6 depois de comprar
                            skin9Toggle.interactable = false;
                            comprarSkin9.interactable = true;
                        }

                        // Se skin 6 foi comprada
                        if (skin10 != 0)
                        {
                            // Pode ligar / desligar skin6
                            skin10Toggle.interactable = true;
                            comprarSkin10.interactable = false;
                        }
                        else
                        {
                            // Só pode ligar / desligar skin6 depois de comprar
                            skin10Toggle.interactable = false;
                            comprarSkin10.interactable = true;
                        }

                        // Se skin 6 foi comprada
                        if (skin11 != 0)
                        {
                            // Pode ligar / desligar skin6
                            skin11Toggle.interactable = true;
                            comprarSkin11.interactable = false;
                        }
                        else
                        {
                            // Só pode ligar / desligar skin6 depois de comprar
                            skin11Toggle.interactable = false;
                            comprarSkin11.interactable = true;
                        }

                        // Se skin 6 foi comprada
                        if (skin12 != 0)
                        {
                            // Pode ligar / desligar skin6
                            skin12Toggle.interactable = true;
                            comprarSkin12.interactable = false;
                        }
                        else
                        {
                            // Só pode ligar / desligar skin6 depois de comprar
                            skin12Toggle.interactable = false;
                            comprarSkin12.interactable = true;
                        }

                        // Se skin 6 foi comprada
                        if (skin13 != 0)
                        {
                            // Pode ligar / desligar skin6
                            skin13Toggle.interactable = true;
                            comprarSkin13.interactable = false;
                        }
                        else
                        {
                            // Só pode ligar / desligar skin6 depois de comprar
                            skin13Toggle.interactable = false;
                            comprarSkin13.interactable = true;
                        }

                        //Debug.Log("Recieved Player Laser/Minimap Data From GameSparks...");
                    }
                    else
                    {
                        //Debug.Log("Error Loading Player Data...");
                    }
                });
    }

    private void ComprarLaserGS()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_LASER")
            .SetEventAttribute("LASER", 1)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Comprou laser...");
                }
                else
                {
                    //Debug.Log("Error Saving Player Data...");
                }
            });
    }

    private void ComprarMinimapaGS()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_MINIMAP")
            .SetEventAttribute("MINIMAP", 1)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Comprou minimapa...");
                }
                else
                {
                    //Debug.Log("Error Saving Player Data...");
                }
            });
    }

    private void ComprarMarkGS()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_MARK")
            .SetEventAttribute("MARK", 1)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Comprou minimapa...");
                }
                else
                {
                    //Debug.Log("Error Saving Player Data...");
                }
            });
    }

    public void BuySkin1()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN1")
            .SetEventAttribute("SKIN1", 1)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Comprou skin1...");
                }
                else
                {
                    //Debug.Log("Error Saving Skin1 Data...");
                }
            });
    }

    public void BuySkin2()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN2")
            .SetEventAttribute("SKIN2", 1)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Comprou skin2...");
                }
                else
                {
                    //Debug.Log("Error Saving Skin2 Data...");
                }
            });
    }

    public void BuySkin3()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN3")
            .SetEventAttribute("SKIN3", 1)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Comprou skin3...");
                }
                else
                {
                    //Debug.Log("Error Saving Skin3 Data...");
                }
            });
    }

    public void BuySkin4()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN4")
            .SetEventAttribute("SKIN4", 1)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Comprou skin4...");
                }
                else
                {
                    //Debug.Log("Error Saving Skin4 Data...");
                }
            });
    }

    public void BuySkin5()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN5")
            .SetEventAttribute("SKIN5", 1)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Comprou skin5...");
                }
                else
                {
                    //Debug.Log("Error Saving Skin5 Data...");
                }
            });
    }

    public void BuySkin6()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN6")
            .SetEventAttribute("SKIN6", 1)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Comprou skin6...");
                }
                else
                {
                    //Debug.Log("Error Saving Skin6 Data...");
                }
            });
    }

    public void BuySkin7()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN7")
            .SetEventAttribute("SKIN7", 1)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Comprou skin6...");
                }
                else
                {
                    //Debug.Log("Error Saving Skin6 Data...");
                }
            });
    }

    public void BuySkin8()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN8")
            .SetEventAttribute("SKIN8", 1)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Comprou skin6...");
                }
                else
                {
                    //Debug.Log("Error Saving Skin6 Data...");
                }
            });
    }

    public void BuySkin9()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN9")
            .SetEventAttribute("SKIN9", 1)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Comprou skin6...");
                }
                else
                {
                    //Debug.Log("Error Saving Skin6 Data...");
                }
            });
    }

    public void BuySkin10()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN10")
            .SetEventAttribute("SKIN10", 1)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Comprou skin6...");
                }
                else
                {
                    //Debug.Log("Error Saving Skin6 Data...");
                }
            });
    }

    public void BuySkin11()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN11")
            .SetEventAttribute("SKIN11", 1)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Comprou skin6...");
                }
                else
                {
                    //Debug.Log("Error Saving Skin6 Data...");
                }
            });
    }

    public void BuySkin12()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN12")
            .SetEventAttribute("SKIN12", 1)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Comprou skin6...");
                }
                else
                {
                    //Debug.Log("Error Saving Skin6 Data...");
                }
            });
    }

    public void BuySkin13()
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("BUY_SKIN13")
            .SetEventAttribute("SKIN13", 1)
            .Send((response) =>
            {

                if (!response.HasErrors)
                {
                    //Debug.Log("Comprou skin6...");
                }
                else
                {
                    //Debug.Log("Error Saving Skin6 Data...");
                }
            });
    }

    IEnumerator CarregarInformacoesBoosts() {
        // Chama o teste de conexão em ModoOffline
        gameSparksManager.GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => gameSparksManager.GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            //Debug.Log("Acao - Online");
            LoadBoostsInfo();
        }
    }

    IEnumerator VerificarConexaoComprar5Vidas()
    {
        // Chama o teste de conexão em ModoOffline
        gameSparksManager.GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => gameSparksManager.GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            //Debug.Log("Acao - Online");
            // Verifica se tem powercells suficiente pra compra
            if (haveEnoughPowercells(CUSTO_5_VIDAS))
            {
                // Adicionar 5 Vidas no GS
                AdicionarVidas(5);

                PlayerPrefs.SetInt("Vidas", PlayerPrefs.GetInt("Vidas") + 5);

                buyLife.GetComponent<AudioSource>().Play();
                
                // Retirar pc
                RetirarPowercells(CUSTO_5_VIDAS);
            }
        }
    }

    IEnumerator VerificarConexaoComprar10Vidas()
    {
        // Chama o teste de conexão em ModoOffline
        gameSparksManager.GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => gameSparksManager.GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            //Debug.Log("Acao - Online");
            // Verifica se tem powercells suficiente pra compra
            if (haveEnoughPowercells(CUSTO_10_VIDAS))
            {
                // Adicionar 10 Vidas no GS
                AdicionarVidas(10);

                PlayerPrefs.SetInt("Vidas", PlayerPrefs.GetInt("Vidas") + 10);

                buyLife.GetComponent<AudioSource>().Play();

                // Retirar pc
                RetirarPowercells(CUSTO_10_VIDAS);
            }
        }
    }

    IEnumerator VerificarConexaoComprar20Vidas()
    {
        // Chama o teste de conexão em ModoOffline
        gameSparksManager.GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => gameSparksManager.GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            //Debug.Log("Acao - Online");
            // Verifica se tem powercells suficiente pra compra
            if (haveEnoughPowercells(CUSTO_20_VIDAS))
            {
                // Adicionar 20 Vidas no GS
                AdicionarVidas(20);

                PlayerPrefs.SetInt("Vidas", PlayerPrefs.GetInt("Vidas") + 20);

                buyLife.GetComponent<AudioSource>().Play();

                // Retirar pc
                RetirarPowercells(CUSTO_20_VIDAS);
            }
        }
    }

    IEnumerator VerificarConexaoComprar50Vidas()
    {
        // Chama o teste de conexão em ModoOffline
        gameSparksManager.GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => gameSparksManager.GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            //Debug.Log("Acao - Online");
            // Verifica se tem powercells suficiente pra compra
            if (haveEnoughPowercells(CUSTO_50_VIDAS))
            {
                // Adicionar 50 Vidas no GS
                AdicionarVidas(50);

                PlayerPrefs.SetInt("Vidas", PlayerPrefs.GetInt("Vidas") + 50);

                buyLife.GetComponent<AudioSource>().Play();

                // Retirar pc
                RetirarPowercells(CUSTO_50_VIDAS);
            }
        }
    }

    IEnumerator VerificarConexaoComprarSkin1()
    {
        // Chama o teste de conexão em ModoOffline
        gameSparksManager.GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => gameSparksManager.GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            //Debug.Log("Acao - Online");
            // Se ainda não comprou a skin, não pode ligar / desligar
            if (skin1Toggle.interactable == false)
            {
                // Verifica se tem powercells suficiente pra compra
                if (haveEnoughPowercells(CUSTO_SKIN1))
                {
                    // Retirar pc
                    RetirarPowercells(CUSTO_SKIN1);

                    // Indica no GS que comprou a skin
                    BuySkin1();

                    // Daqui em diante pode ligar / desligar a skin
                    skin1Toggle.interactable = true;

                    ZerarSkins();
                    PlayerPrefs.SetInt("Skin1", 1);
                    skin1Toggle.isOn = true;

                    // E não pode comprar mais ela
                    comprarSkin1.interactable = false;
                }
            }
        }
    }

    IEnumerator VerificarConexaoComprarSkin2()
    {
        // Chama o teste de conexão em ModoOffline
        gameSparksManager.GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => gameSparksManager.GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            //Debug.Log("Acao - Online");
            // Se ainda não comprou a skin, não pode ligar / desligar
            if (skin2Toggle.interactable == false)
            {
                // Verifica se tem powercells suficiente pra compra
                if (haveEnoughPowercells(CUSTO_SKIN2))
                {
                    // Retirar pc
                    RetirarPowercells(CUSTO_SKIN2);

                    // Indica no GS que comprou a skin
                    BuySkin2();

                    // Daqui em diante pode ligar / desligar a skin
                    skin2Toggle.interactable = true;

                    ZerarSkins();
                    PlayerPrefs.SetInt("Skin2", 1);
                    skin2Toggle.isOn = true;

                    // E não pode comprar mais ela
                    comprarSkin2.interactable = false;
                }
            }
        }
    }

    IEnumerator VerificarConexaoComprarSkin3()
    {
        // Chama o teste de conexão em ModoOffline
        gameSparksManager.GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => gameSparksManager.GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            //Debug.Log("Acao - Online");
            // Se ainda não comprou a skin, não pode ligar / desligar
            if (skin3Toggle.interactable == false)
            {
                // Verifica se tem powercells suficiente pra compra
                if (haveEnoughPowercells(CUSTO_SKIN3))
                {
                    // Retirar pc
                    RetirarPowercells(CUSTO_SKIN3);

                    // Indica no GS que comprou a skin
                    BuySkin3();

                    // Daqui em diante pode ligar / desligar a skin
                    skin3Toggle.interactable = true;

                    ZerarSkins();
                    PlayerPrefs.SetInt("Skin3", 1);
                    skin3Toggle.isOn = true;

                    // E não pode comprar mais ela
                    comprarSkin3.interactable = false;
                }
            }
        }
    }

    IEnumerator VerificarConexaoComprarSkin4()
    {
        // Chama o teste de conexão em ModoOffline
        gameSparksManager.GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => gameSparksManager.GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            //Debug.Log("Acao - Online");
            // Se ainda não comprou a skin, não pode ligar / desligar
            if (skin4Toggle.interactable == false)
            {
                // Verifica se tem powercells suficiente pra compra
                if (haveEnoughPowercells(CUSTO_SKIN4))
                {
                    // Retirar pc
                    RetirarPowercells(CUSTO_SKIN4);

                    // Indica no GS que comprou a skin
                    BuySkin4();

                    // Daqui em diante pode ligar / desligar a skin
                    skin4Toggle.interactable = true;

                    ZerarSkins();
                    PlayerPrefs.SetInt("Skin4", 1);
                    skin4Toggle.isOn = true;

                    // E não pode comprar mais ela
                    comprarSkin4.interactable = false;
                }
            }
        }
    }

    IEnumerator VerificarConexaoComprarSkin5()
    {
        // Chama o teste de conexão em ModoOffline
        gameSparksManager.GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => gameSparksManager.GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            //Debug.Log("Acao - Online");
            // Se ainda não comprou a skin, não pode ligar / desligar
            if (skin5Toggle.interactable == false)
            {
                // Verifica se tem powercells suficiente pra compra
                if (haveEnoughPowercells(CUSTO_SKIN5))
                {
                    // Retirar pc
                    RetirarPowercells(CUSTO_SKIN5);

                    // Indica no GS que comprou a skin
                    BuySkin5();

                    // Daqui em diante pode ligar / desligar a skin
                    skin5Toggle.interactable = true;

                    ZerarSkins();
                    PlayerPrefs.SetInt("Skin5", 1);
                    skin5Toggle.isOn = true;

                    // E não pode comprar mais ela
                    comprarSkin5.interactable = false;
                }
            }
        }
    }

    IEnumerator VerificarConexaoComprarSkin6()
    {
        // Chama o teste de conexão em ModoOffline
        gameSparksManager.GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => gameSparksManager.GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            //Debug.Log("Acao - Online");
            // Se ainda não comprou a skin, não pode ligar / desligar
            if (skin6Toggle.interactable == false)
            {
                // Verifica se tem powercells suficiente pra compra
                if (haveEnoughPowercells(CUSTO_SKIN6))
                {
                    // Retirar pc
                    RetirarPowercells(CUSTO_SKIN6);

                    // Indica no GS que comprou a skin
                    BuySkin6();

                    // Daqui em diante pode ligar / desligar a skin
                    skin6Toggle.interactable = true;

                    ZerarSkins();
                    PlayerPrefs.SetInt("Skin6", 1);
                    skin6Toggle.isOn = true;

                    // E não pode comprar mais ela
                    comprarSkin6.interactable = false;
                }
            }
        }
    }

    IEnumerator VerificarConexaoComprarSkin7()
    {
        // Chama o teste de conexão em ModoOffline
        gameSparksManager.GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => gameSparksManager.GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            //Debug.Log("Acao - Online");
            // Se ainda não comprou a skin, não pode ligar / desligar
            if (skin7Toggle.interactable == false)
            {
                // Verifica se tem powercells suficiente pra compra
                if (haveEnoughPowercells(CUSTO_SKIN7))
                {
                    // Retirar pc
                    RetirarPowercells(CUSTO_SKIN7);

                    // Indica no GS que comprou a skin
                    BuySkin7();

                    // Daqui em diante pode ligar / desligar a skin
                    skin7Toggle.interactable = true;

                    ZerarSkins();
                    PlayerPrefs.SetInt("Skin7", 1);
                    skin7Toggle.isOn = true;

                    // E não pode comprar mais ela
                    comprarSkin7.interactable = false;
                }
            }
        }
    }

    IEnumerator VerificarConexaoComprarSkin8()
    {
        // Chama o teste de conexão em ModoOffline
        gameSparksManager.GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => gameSparksManager.GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            //Debug.Log("Acao - Online");
            // Se ainda não comprou a skin, não pode ligar / desligar
            if (skin8Toggle.interactable == false)
            {
                // Verifica se tem powercells suficiente pra compra
                if (haveEnoughPowercells(CUSTO_SKIN8))
                {
                    // Retirar pc
                    RetirarPowercells(CUSTO_SKIN8);

                    // Indica no GS que comprou a skin
                    BuySkin8();

                    // Daqui em diante pode ligar / desligar a skin
                    skin8Toggle.interactable = true;

                    ZerarSkins();
                    PlayerPrefs.SetInt("Skin8", 1);
                    skin8Toggle.isOn = true;

                    // E não pode comprar mais ela
                    comprarSkin8.interactable = false;
                }
            }
        }
    }

    IEnumerator VerificarConexaoComprarSkin9()
    {
        // Chama o teste de conexão em ModoOffline
        gameSparksManager.GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => gameSparksManager.GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            //Debug.Log("Acao - Online");
            // Se ainda não comprou a skin, não pode ligar / desligar
            if (skin9Toggle.interactable == false)
            {
                // Verifica se tem powercells suficiente pra compra
                if (haveEnoughPowercells(CUSTO_SKIN9))
                {
                    // Retirar pc
                    RetirarPowercells(CUSTO_SKIN9);

                    // Indica no GS que comprou a skin
                    BuySkin9();

                    // Daqui em diante pode ligar / desligar a skin
                    skin9Toggle.interactable = true;

                    ZerarSkins();
                    PlayerPrefs.SetInt("Skin9", 1);
                    skin9Toggle.isOn = true;

                    // E não pode comprar mais ela
                    comprarSkin9.interactable = false;
                }
            }
        }
    }

    IEnumerator VerificarConexaoComprarSkin10()
    {
        // Chama o teste de conexão em ModoOffline
        gameSparksManager.GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => gameSparksManager.GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            //Debug.Log("Acao - Online");
            // Se ainda não comprou a skin, não pode ligar / desligar
            if (skin10Toggle.interactable == false)
            {
                // Verifica se tem powercells suficiente pra compra
                if (haveEnoughPowercells(CUSTO_SKIN10))
                {
                    // Retirar pc
                    RetirarPowercells(CUSTO_SKIN10);

                    // Indica no GS que comprou a skin
                    BuySkin10();

                    // Daqui em diante pode ligar / desligar a skin
                    skin10Toggle.interactable = true;

                    ZerarSkins();
                    PlayerPrefs.SetInt("Skin10", 1);
                    skin10Toggle.isOn = true;

                    // E não pode comprar mais ela
                    comprarSkin10.interactable = false;
                }
            }
        }
    }

    IEnumerator VerificarConexaoComprarSkin11()
    {
        // Chama o teste de conexão em ModoOffline
        gameSparksManager.GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => gameSparksManager.GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            //Debug.Log("Acao - Online");
            // Se ainda não comprou a skin, não pode ligar / desligar
            if (skin11Toggle.interactable == false)
            {
                // Verifica se tem powercells suficiente pra compra
                if (haveEnoughPowercells(CUSTO_SKIN11))
                {
                    // Retirar pc
                    RetirarPowercells(CUSTO_SKIN11);

                    // Indica no GS que comprou a skin
                    BuySkin11();

                    // Daqui em diante pode ligar / desligar a skin
                    skin11Toggle.interactable = true;

                    ZerarSkins();
                    PlayerPrefs.SetInt("Skin11", 1);
                    skin11Toggle.isOn = true;

                    // E não pode comprar mais ela
                    comprarSkin11.interactable = false;
                }
            }
        }
    }

    IEnumerator VerificarConexaoComprarSkin12()
    {
        // Chama o teste de conexão em ModoOffline
        gameSparksManager.GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => gameSparksManager.GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            //Debug.Log("Acao - Online");
            // Se ainda não comprou a skin, não pode ligar / desligar
            if (skin12Toggle.interactable == false)
            {
                // Verifica se tem powercells suficiente pra compra
                if (haveEnoughPowercells(CUSTO_SKIN12))
                {
                    // Retirar pc
                    RetirarPowercells(CUSTO_SKIN12);

                    // Indica no GS que comprou a skin
                    BuySkin12();

                    // Daqui em diante pode ligar / desligar a skin
                    skin12Toggle.interactable = true;

                    ZerarSkins();
                    PlayerPrefs.SetInt("Skin12", 1);
                    skin12Toggle.isOn = true;

                    // E não pode comprar mais ela
                    comprarSkin12.interactable = false;
                }
            }
        }
    }

    IEnumerator VerificarConexaoComprarSkin13()
    {
        // Chama o teste de conexão em ModoOffline
        gameSparksManager.GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => gameSparksManager.GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            //Debug.Log("Acao - Online");
            // Se ainda não comprou a skin, não pode ligar / desligar
            if (skin13Toggle.interactable == false)
            {
                // Verifica se tem powercells suficiente pra compra
                if (haveEnoughPowercells(CUSTO_SKIN13))
                {
                    // Retirar pc
                    RetirarPowercells(CUSTO_SKIN13);

                    // Indica no GS que comprou a skin
                    BuySkin13();

                    // Daqui em diante pode ligar / desligar a skin
                    skin13Toggle.interactable = true;

                    ZerarSkins();
                    PlayerPrefs.SetInt("Skin13", 1);
                    skin13Toggle.isOn = true;

                    // E não pode comprar mais ela
                    comprarSkin13.interactable = false;
                }
            }
        }
    }

    IEnumerator VerificarConexaoComprarLaser()
    {
        // Chama o teste de conexão em ModoOffline
        gameSparksManager.GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => gameSparksManager.GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            //Debug.Log("Acao - Online");
            // Se ainda não comprou o laser, não pode ligar / desligar
            if (laserToggle.interactable == false)
            {
                // Verifica se tem powercells suficiente pra compra
                if (haveEnoughPowercells(CUSTO_LASER))
                {
                    // Retirar pc
                    RetirarPowercells(CUSTO_LASER);

                    // Indica no GS que comprou laser
                    ComprarLaserGS();

                    // Daqui em diante pode ligar / desligar laser
                    laserToggle.interactable = true;

                    laserToggle.isOn = true;
                    PlayerPrefs.SetInt("Laser", 1);
                    laserToggle.transform.GetChild(1).GetComponent<Text>().text = "     Laser ligado";

                    // E não pode comprar mais ele
                    comprarLaser.interactable = false;
                }
            }
        }
    }

    IEnumerator VerificarConexaoComprarMinimapa()
    {
        // Chama o teste de conexão em ModoOffline
        gameSparksManager.GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => gameSparksManager.GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            //Debug.Log("Acao - Online");
            // Se ainda não comprou o minimapa, não pode ligar / desligar
            if (minimapToggle.interactable == false)
            {
                // Verifica se tem powercells suficiente pra compra
                if (haveEnoughPowercells(CUSTO_MINIMAPA))
                {
                    // Retirar pc
                    RetirarPowercells(CUSTO_MINIMAPA);

                    // Indica no GS que comprou minimapa
                    ComprarMinimapaGS();

                    // Daqui em diante pode ligar / desligar minimapa
                    minimapToggle.interactable = true;

                    minimapToggle.isOn = true;
                    PlayerPrefs.SetInt("MiniMapa", 1);
                    minimapToggle.transform.GetChild(1).GetComponent<Text>().text = "     Radar ligado";

                    // E não pode comprar mais ele
                    comprarMinimapa.interactable = false;
                }
            }
        }
    }

    IEnumerator VerificarConexaoComprarMark()
    {
        // Chama o teste de conexão em ModoOffline
        gameSparksManager.GetComponent<ModoOffline>().TestarConexao();

        // Aguarda até terminar o teste
        yield return new WaitUntil(() => gameSparksManager.GetComponent<ModoOffline>().getTestandoConexao() == false);

        // Age de acordo com o resultado, offline ou online
        if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            //Debug.Log("Acao - Online");
            // Se ainda não comprou a marca, não pode ligar / desligar
            if (markToggle.interactable == false)
            {
                // Verifica se tem powercells suficiente pra compra
                if (haveEnoughPowercells(CUSTO_MARK))
                {
                    // Retirar pc
                    RetirarPowercells(CUSTO_MARK);

                    // Indica no GS que comprou marca
                    ComprarMarkGS();

                    // Daqui em diante pode ligar / desligar minimapa
                    markToggle.interactable = true;

                    markToggle.isOn = true;
                    PlayerPrefs.SetInt("Mark", 1);
                    markToggle.transform.GetChild(1).GetComponent<Text>().text = "     Marca ligada";

                    // E não pode comprar mais ele
                    comprarMark.interactable = false;
                }
            }
        }
    }

    public void ComprarItem(string s)
    {
        itemPurchased = s;
        confirmarCompraPanel.SetActive(true);
    }

    // Setar uma string privada e mudar de acordo com a compra a ser feita
    public void ConfirmarCompra()
    {
        SendMessage(itemPurchased);
    }

    public void ZerarSkins()
    {
        PlayerPrefs.SetInt("Skin1", 0);
        PlayerPrefs.SetInt("Skin2", 0);
        PlayerPrefs.SetInt("Skin3", 0);
        PlayerPrefs.SetInt("Skin4", 0);
        PlayerPrefs.SetInt("Skin5", 0);
        PlayerPrefs.SetInt("Skin6", 0);
        PlayerPrefs.SetInt("Skin7", 0);
        PlayerPrefs.SetInt("Skin8", 0);
        PlayerPrefs.SetInt("Skin9", 0);
        PlayerPrefs.SetInt("Skin10", 0);
        PlayerPrefs.SetInt("Skin11", 0);
        PlayerPrefs.SetInt("Skin12", 0);
        PlayerPrefs.SetInt("Skin13", 0);
    }
}
