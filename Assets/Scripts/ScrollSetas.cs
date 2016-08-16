using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollSetas : MonoBehaviour {

    public GameObject setaInicial;
    public GameObject setaFinal;

    public int valorInicial;
    public int valorFinal;

    void Update(){
        if (GetComponent<RectTransform>().offsetMax.x >= valorInicial)
        {
            setaInicial.SetActive(false);
        }
        else if (GetComponent<RectTransform>().offsetMax.x <= valorFinal)
        {
            setaFinal.SetActive(false);
        }
        else
        {
            setaInicial.SetActive(true);
            setaFinal.SetActive(true);
        }
    }

}
