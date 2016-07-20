using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialTextScript : MonoBehaviour {
    
    public Text textBox;
    private string[] texto = new string[]{"Orb-e:\nOlá capitão. Sou a sonda de exploracão espacial Orb-e designada\ncom a missão de explorar o nosso vasto universo.;",
                                          "Orb-e:\nAs descobertas recentes da ciência tornaram possível explorar\ngaláxias próximas por meio de campos de energia.",
                                          "Orb-e:\nTais campos podem lancar sondas como esta a anos-luz de distância em poucos segundos. Para isso, preciso de sua ajuda para me lancar de um campo a outro.",
                                          "Orb-e:\nToque na tela para, a partir do campo inicial lancar o Orb-e e comecar\na aventura.",
                                          "Orb-e:\nEste campo amarelo é o que chamamos de automático. Ao entrar em um, ele logo em seguida dispara o Orb-e em uma direcão pré-determinada.",
                                          "Orb-e:\nAntes de entrar em um campo automático, não há como prever para onde irei ser lancado, então cuidado.",
                                          "Orb-e:\nEste é um campo de energia que pode apontar para 2 ou mais\ndirecões. Espere apontar para a direcão que deseja e toque na tela para me lancar.",
                                          "Orb-e:\nDiversos outros tipos de campos de energia irão aparecer ao longo\ndos mundos para auxiliar em minha exploracão pelo nosso universo.\nPreste atencão e tire o máximo proveito de cada um deles.",
                                          "Orb-e:\nEste é o campo que encerra a fase e me leva a outro ponto de\nnosso vasto universo. No topo da tela há o tempo gasto para terminar\na fase. ",
                                          "Orb-e:\nA partir do menu principal você pode acessar a tela de ranking e\ncomparar seu tempo com outras pessoas do mundo inteiro, inclusive\ncom seus amigos.",
                                          "Orb-e:\nBoa sorte e que a exploracão espacial comece!"};

    public GameObject tutorialCanvas;
    public GameObject[] focusImage;

    private int index;

	// Use this for initialization
	void Start () {
        index = 0;
        textBox.text = texto[index];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NextText()
    {
        if (index < 10)
        {
            textBox.text = texto[++index];
            GetComponent<AudioSource>().Play();
            //Debug.Log(index);
        }
        else
        {
            Time.timeScale = 1;
            tutorialCanvas.gameObject.SetActive(false);
            GetComponent<AudioSource>().Stop();
            turnOffFocusImg();
        }

        if (index == 4)
        {
            Time.timeScale = 1;
            tutorialCanvas.gameObject.SetActive(false);
            GetComponent<AudioSource>().Stop();
            turnOffFocusImg();
        }
        else if (index == 6)
        {
            Time.timeScale = 1;
            tutorialCanvas.gameObject.SetActive(false);
            GetComponent<AudioSource>().Stop();
            turnOffFocusImg();
        }
        else if (index == 7)
        {
            Time.timeScale = 1;
            tutorialCanvas.gameObject.SetActive(false);
            GetComponent<AudioSource>().Stop();
            turnOffFocusImg();
        }
        else if (index == 8)
        {
            Time.timeScale = 1;
            tutorialCanvas.gameObject.SetActive(false);
            GetComponent<AudioSource>().Stop();
            turnOffFocusImg();
        }
        else if (index == 9)
        {
            turnOffFocusImg();
            focusImage[4].SetActive(true);
        }
        else if (index == 11)
        {
            Time.timeScale = 1;
            tutorialCanvas.gameObject.SetActive(false);
            GetComponent<AudioSource>().Stop();
            turnOffFocusImg();
        }

    }

    private void turnOffFocusImg()
    {
        for (int i = 0; i < focusImage.Length; i++)
        {
            focusImage[i].SetActive(false);
        }
    }
}
