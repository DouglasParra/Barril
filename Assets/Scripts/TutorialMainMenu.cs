using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialMainMenu : MonoBehaviour {

    public GameObject tutorialCanvas;
    public Text textBox;
    private string[] texto = new string[]{"Orb-e:\nNo canto superior esquerdo temos a quantidade de vidas, um cronômetro e um botão que leva para a loja de vidas.",
                                          "Orb-e:\nOrb-e pode manter uma carga máxima de 5 vidas por vez, a cada 10 minutos recupera-se um. Para passar de 5 vidas, por favor, compre pacotes de vida na loja, ou assista propagandas.",
                                          "Orb-e:\nNo canto superior direito temos a quantidade de powercells, a moeda \ndo jogo. Com ela você pode comprar vidas, skins para o Orb-e ou até mesmo boosts como um laser ou um radar para te auxiliar nas fases.",
                                          "Orb-e:\nVocê pode comprar pacotes de powercells na loja apertando o botão\nde + ao lado.",
                                          "Orb-e:\nO botão vermelho no canto inferior esquerdo exibe uma propaganda que, caso vista por completo, dá uma vida. Contudo, essa opcão está disponível apenas 5 vezes ao dia.",
                                          "Orb-e:\nCaso queira rever o tutorial, o botão está sempre disponível para explicar o funcionamento básico do jogo.",
                                          "Orb-e:\nPor fim o botão verde no canto inferior direito leva de volta ao menu principal, onde poderá acessar a loja, ver seus records, ranking\nmundial e de amigos, além das configuracões de som do jogo.",
                                          "Orb-e:\nCada mundo é dividido em 10 fases, acessadas nessa tela. Orb-e\nconta com sua ajuda para explorar o que pode desse vasto universo!"};

    public GameObject[] focusImage;
    private int index;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("stageSelectTutorialDone") == 0)
        {
            tutorialCanvas.SetActive(true);
            index = 0;
            textBox.text = texto[index];
            PlayerPrefs.SetInt("stageSelectTutorialDone", 1);
        }
	}
	
	public void NextText(){
        index++;
        if (index <= 7)
        {
            textBox.text = texto[index];
        }

        Debug.Log(index);

        if (index == 2)
        {
            focusImage[0].SetActive(false);
            focusImage[1].SetActive(true);
        }else if (index == 4)
        {
            focusImage[1].SetActive(false);
            focusImage[2].SetActive(true);
        }
        else if (index == 6)
        {
            focusImage[2].SetActive(false);
            focusImage[3].SetActive(true);
        }
        else if (index == 8)
        {
            tutorialCanvas.SetActive(false);
        }
    }
}
