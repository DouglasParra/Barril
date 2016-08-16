using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingTips : MonoBehaviour {

    private string[] dicas = new string[] { "Dica 1: Modo Offline\n\nVocê sabia que pode jogar Orb-e offline e os records serão enviados na próxima vez que iniciar o jogo com conexão?",
                                            "Dica 2: Laser\n\nVocê sabia que o laser vendido na loja possibilita o Orb-e mirar mais fácil para o próximo campo de energia?",
                                            "Dica 3: Radar\n\nVocê sabia que, ao comprar o radar na loja, é habilitado um botão no canto inferior esquerdo da tela dentro das fases que permite o Orb-e ver toda a fase?",
                                            "Dica 4: Marca\n\nAo comprar a marca na loja, cada vez que o Orb-e passa por um novo campo, é deixada uma marca registrando que o robô já esteve ali.",                                            
                                            "Dica 5: Tempo da Fase\n\nO ícone verde mostrado ao lado do tempo quando termina uma fase indica que o tempo foi enviado com sucesso, enquanto o vermelho indica que vai ser enviado da próxima vez que iniciar o jogo.",
                                            "Dica 6: Campo Falso\n\nCuidado com os campos falsos que aparecem a partir do Mundo 4. Eles sugam o Orb-e para uma outra dimensão!",
                                            "Dica 7: Campos Contadores\n\nAo chegar em 0, os campos contadores vão destruir o Orb-e, então não demore muito!",
                                            "Dica 8: Chaves e Portas\n\nA partir do Mundo 6, às vezes se torna necessário abrir as portas laser para prosseguir nas fases. Procure pelos campos chaves!",
                                            "Dica 9: Portais\n\nO Mundo 7 apresenta campos de energia que funcionam como portais. Para onde eles vão mandar Orb-e? Apenas entrando em cada um deles pra saber!",
                                            "Dica 10: Campos Automáticos\n\nAo entrar em um campo automático, Orb-e é imediatamente enviado para o seguinte. Cuidado, alguns podem mudar para onde apontam!"
                                          };

    public Text tipsText;

	// Use this for initialization
	void Start () {
        int n = Random.Range(0, dicas.Length);
        tipsText.text = dicas[n];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
