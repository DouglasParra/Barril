using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GameSparks.Core;

public class ShopManager : MonoBehaviour {

    public Text energyText;
    public Text energyTextLoja;
    public GameObject powercellsManager;
    public GameObject gameSparksManager;

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

    public Toggle skin1Toggle;
    public Toggle skin2Toggle;
    public Toggle skin3Toggle;
    public Toggle skin4Toggle;
    public Toggle skin5Toggle;
    public Toggle skin6Toggle;

    [Space(10)]
    [Header("Boosts")]
    public Button comprarLaser;
    public Button comprarMinimapa;
    public Toggle laserToggle;
    public Toggle minimapToggle;

    [Space(10)]
    public GameObject notEnoughPowercell;
    public GameObject buyLife;

    private const int MAX_VIDAS = 99;

    private const int CUSTO_5_VIDAS = 1;
    private const int CUSTO_10_VIDAS = 1;
    private const int CUSTO_20_VIDAS = 1;
    private const int CUSTO_50_VIDAS = 1;

    private const int CUSTO_SKIN1 = 1;
    private const int CUSTO_SKIN2 = 1;
    private const int CUSTO_SKIN3 = 1;
    private const int CUSTO_SKIN4 = 1;
    private const int CUSTO_SKIN5 = 1;
    private const int CUSTO_SKIN6 = 1;

    private const int CUSTO_LASER = 1;
    private const int CUSTO_MINIMAPA = 1;

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
        /*if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            // Verifica se tem powercells suficiente pra compra
            if (haveEnoughPowercells(CUSTO_5_VIDAS))
            {
                // Adicionar 5 Vidas no GS
                AdicionarVidas(5);

                PlayerPrefs.SetInt("Vidas", PlayerPrefs.GetInt("Vidas") + 5);

                // Retirar pc
                RetirarPowercells(CUSTO_5_VIDAS);
            }
        }*/
	}

    public void Comprar10Vidas()
    {
        StartCoroutine("VerificarConexaoComprar10Vidas");
        /*if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            // Verifica se tem powercells suficiente pra compra
            if (haveEnoughPowercells(CUSTO_10_VIDAS))
            {
                // Adicionar 10 Vidas no GS
                AdicionarVidas(10);

                PlayerPrefs.SetInt("Vidas", PlayerPrefs.GetInt("Vidas") + 10);

                // Retirar pc
                RetirarPowercells(CUSTO_10_VIDAS);
            }
        }*/
    }

    public void Comprar20Vidas()
    {
        StartCoroutine("VerificarConexaoComprar20Vidas");
        /*if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            // Verifica se tem powercells suficiente pra compra
            if (haveEnoughPowercells(CUSTO_20_VIDAS))
            {
                // Adicionar 20 Vidas no GS
                AdicionarVidas(20);

                PlayerPrefs.SetInt("Vidas", PlayerPrefs.GetInt("Vidas") + 20);

                // Retirar pc
                RetirarPowercells(CUSTO_20_VIDAS);
            }
        }*/
    }

    public void Comprar50Vidas()
    {
        StartCoroutine("VerificarConexaoComprar50Vidas");
        /*if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            // Verifica se tem powercells suficiente pra compra
            if (haveEnoughPowercells(CUSTO_50_VIDAS))
            {
                // Adicionar 50 Vidas no GS
                AdicionarVidas(50);

                PlayerPrefs.SetInt("Vidas", PlayerPrefs.GetInt("Vidas") + 50);

                // Retirar pc
                RetirarPowercells(CUSTO_50_VIDAS);
            }
        }*/
    }

    public void ComprarSkin1()
    {
        StartCoroutine("VerificarConexaoComprarSkin1");
        /*if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            // Se ainda não comprou a skin, não pode ligar / desligar
            if (skin1Toggle.interactable == false)
            {
                // Verifica se tem powercells suficiente pra compra
                if (haveEnoughPowercells(CUSTO_SKIN1))
                {
                    // Retirar pc
                    RetirarPowercells(CUSTO_SKIN1);

                    // Indica no GS que comprou skin1
                    BuySkin1();

                    // Daqui em diante pode ligar / desligar skin1
                    skin1Toggle.interactable = true;

                    // E não pode comprar mais ele
                    comprarSkin1.interactable = false;
                }
            }
        }*/
    }

    public void ComprarSkin2()
    {
        StartCoroutine("VerificarConexaoComprarSkin2");
        /*if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            // Se ainda não comprou a skin, não pode ligar / desligar
            if (skin2Toggle.interactable == false)
            {
                // Verifica se tem powercells suficiente pra compra
                if (haveEnoughPowercells(CUSTO_SKIN2))
                {
                    // Retirar pc
                    RetirarPowercells(CUSTO_SKIN2);

                    // Indica no GS que comprou skin2
                    BuySkin2();

                    // Daqui em diante pode ligar / desligar skin2
                    skin2Toggle.interactable = true;

                    // E não pode comprar mais ele
                    comprarSkin2.interactable = false;
                }
            }
        }*/
    }

    public void ComprarSkin3()
    {
        StartCoroutine("VerificarConexaoComprarSkin3");
        /*if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            // Se ainda não comprou a skin, não pode ligar / desligar
            if (skin3Toggle.interactable == false)
            {
                // Verifica se tem powercells suficiente pra compra
                if (haveEnoughPowercells(CUSTO_SKIN3))
                {
                    // Retirar pc
                    RetirarPowercells(CUSTO_SKIN3);

                    // Indica no GS que comprou skin3
                    BuySkin3();

                    // Daqui em diante pode ligar / desligar skin3
                    skin3Toggle.interactable = true;

                    // E não pode comprar mais ele
                    comprarSkin3.interactable = false;
                }
            }
        }*/
    }

    public void ComprarSkin4()
    {
        StartCoroutine("VerificarConexaoComprarSkin4");
        /*if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            // Se ainda não comprou a skin, não pode ligar / desligar
            if (skin4Toggle.interactable == false)
            {
                // Verifica se tem powercells suficiente pra compra
                if (haveEnoughPowercells(CUSTO_SKIN4))
                {
                    // Retirar pc
                    RetirarPowercells(CUSTO_SKIN4);

                    // Indica no GS que comprou skin4
                    BuySkin4();

                    // Daqui em diante pode ligar / desligar skin4
                    skin4Toggle.interactable = true;

                    // E não pode comprar mais ele
                    comprarSkin4.interactable = false;
                }
            }
        }*/
    }

    public void ComprarSkin5()
    {
        StartCoroutine("VerificarConexaoComprarSkin5");
        /*if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            // Se ainda não comprou a skin, não pode ligar / desligar
            if (skin5Toggle.interactable == false)
            {
                // Verifica se tem powercells suficiente pra compra
                if (haveEnoughPowercells(CUSTO_SKIN5))
                {
                    // Retirar pc
                    RetirarPowercells(CUSTO_SKIN5);

                    // Indica no GS que comprou skin5
                    BuySkin5();

                    // Daqui em diante pode ligar / desligar skin5
                    skin5Toggle.interactable = true;

                    // E não pode comprar mais ele
                    comprarSkin5.interactable = false;
                }
            }
        }*/
    }

    public void ComprarSkin6()
    {
        StartCoroutine("VerificarConexaoComprarSkin6");
        /*if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            // Se ainda não comprou a skin, não pode ligar / desligar
            if (skin6Toggle.interactable == false)
            {
                // Verifica se tem powercells suficiente pra compra
                if (haveEnoughPowercells(CUSTO_SKIN6))
                {
                    // Retirar pc
                    RetirarPowercells(CUSTO_SKIN6);

                    // Indica no GS que comprou skin6
                    BuySkin6();

                    // Daqui em diante pode ligar / desligar skin6
                    skin6Toggle.interactable = true;

                    // E não pode comprar mais ele
                    comprarSkin6.interactable = false;
                }
            }
        }*/
    }

    public void ComprarLaser()
    {
        StartCoroutine("VerificarConexaoComprarLaser");
        /*if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
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

                    // E não pode comprar mais ele
                    comprarLaser.interactable = false;
                }
            }
        }*/
    }

    public void ComprarMinimapa()
    {
        StartCoroutine("VerificarConexaoComprarMinimapa");
        /*if (!gameSparksManager.GetComponent<ModoOffline>().getModoOffline())
        {
            // Se ainda não comprou o laser, não pode ligar / desligar
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

                    // E não pode comprar mais ele
                    comprarMinimapa.interactable = false;
                }
            }
        }*/
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

                        int skin1 = (int)data.GetInt("skin1");
                        int skin2 = (int)data.GetInt("skin2");
                        int skin3 = (int)data.GetInt("skin3");
                        int skin4 = (int)data.GetInt("skin4");
                        int skin5 = (int)data.GetInt("skin5");
                        int skin6 = (int)data.GetInt("skin6");

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

                    // E não pode comprar mais ela
                    comprarSkin6.interactable = false;
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

                    // E não pode comprar mais ele
                    comprarMinimapa.interactable = false;
                }
            }
        }
    }

}
