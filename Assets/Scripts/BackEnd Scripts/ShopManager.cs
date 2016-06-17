using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GameSparks.Core;

public class ShopManager : MonoBehaviour {

    public Text energyText;
    public Text energyTextLoja;
    public GameObject powercellsManager;

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

    [Space(10)]
    [Header("Boosts")]
    public Button comprarLaser;
    public Button comprarMinimapa;
    public Toggle laserToggle;
    public Toggle minimapToggle;

    private const int MAX_VIDAS = 99;

    void Start() {
        energyTextLoja.text = energyText.text;

        VerificarVidas();
        LoadBoostsInfo();
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
        
        return false;
    }
    
	public void Comprar5Vidas () {
        // Verifica se tem powercells suficiente pra compra
        if (haveEnoughPowercells(25))
        {
            // Adicionar 5 Vidas no GS
            AdicionarVidas(5);

            // Retirar pc
            RetirarPowercells(25);
        }
	}

    public void Comprar10Vidas()
    {
        // Verifica se tem powercells suficiente pra compra
        if (haveEnoughPowercells(50))
        {
            // Adicionar 10 Vidas no GS
            AdicionarVidas(10);

            // Retirar pc
            RetirarPowercells(50);
        }
    }

    public void Comprar20Vidas()
    {
        // Verifica se tem powercells suficiente pra compra
        if (haveEnoughPowercells(100))
        {
            // Adicionar 20 Vidas no GS
            AdicionarVidas(20);

            // Retirar pc
            RetirarPowercells(100);
        }
    }

    public void Comprar50Vidas()
    {
        // Verifica se tem powercells suficiente pra compra
        if (haveEnoughPowercells(200))
        {
            // Adicionar 50 Vidas no GS
            AdicionarVidas(50);

            // Retirar pc
            RetirarPowercells(200);
        }
    }

    public void ComprarSkin1()
    {
        // Verificar se já está comprado
        // Adicionar botão de habilitar / desabilitar skin

        // Verifica se tem powercells suficiente pra compra
        if (haveEnoughPowercells(25))
        {
            // Habilitar skin 1

            // Retirar pc
            RetirarPowercells(25);
        }
    }

    public void ComprarSkin2()
    {
        // Verifica se tem powercells suficiente pra compra
        if (haveEnoughPowercells(50))
        {
            // Habilitar skin 1

            // Retirar pc
            RetirarPowercells(50);
        }
    }

    public void ComprarSkin3()
    {
        // Verifica se tem powercells suficiente pra compra
        if (haveEnoughPowercells(100))
        {
            // Habilitar skin 1

            // Retirar pc
            RetirarPowercells(100);
        }
    }

    public void ComprarSkin4()
    {
        // Verifica se tem powercells suficiente pra compra
        if (haveEnoughPowercells(200))
        {
            // Habilitar skin 1

            // Retirar pc
            RetirarPowercells(200);
        }
    }

    public void ComprarLaser()
    {
        // Se ainda não comprou o laser, não pode ligar / desligar
        if (laserToggle.interactable == false)
        {
            // Verifica se tem powercells suficiente pra compra
            if (haveEnoughPowercells(500))
            {
                // Retirar pc
                RetirarPowercells(500);

                // Indica no GS que comprou laser
                ComprarLaserGS();

                // Daqui em diante pode ligar / desligar laser
                laserToggle.interactable = true;

                // E não pode comprar mais ele
                comprarLaser.interactable = false;
            }
        }
    }

    public void ComprarMinimapa()
    {
        // Se ainda não comprou o laser, não pode ligar / desligar
        if (minimapToggle.interactable == false)
        {
            // Verifica se tem powercells suficiente pra compra
            if (haveEnoughPowercells(500))
            {
                // Retirar pc
                RetirarPowercells(1000);

                // Indica no GS que comprou minimapa
                ComprarMinimapaGS();

                // Daqui em diante pode ligar / desligar minimapa
                minimapToggle.interactable = true;

                // E não pode comprar mais ele
                comprarMinimapa.interactable = false;
            }
        }
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
                    Debug.Log("Adicionou " + value + " vidas");
                }
                else
                {
                    Debug.Log("Error Saving Player Data...");
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

                        Debug.Log("Recieved Player Laser/Minimap Data From GameSparks...");
                    }
                    else
                    {
                        Debug.Log("Error Loading Player Data...");
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
                    Debug.Log("Comprou laser...");
                }
                else
                {
                    Debug.Log("Error Saving Player Data...");
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
                    Debug.Log("Comprou minimapa...");
                }
                else
                {
                    Debug.Log("Error Saving Player Data...");
                }
            });
    }
}
