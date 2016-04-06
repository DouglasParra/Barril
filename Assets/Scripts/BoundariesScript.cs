using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoundariesScript : MonoBehaviour {

//    public Button retry;
//    public Button stageSelect;

    void OnTriggerEnter2D(Collider2D obj) {
        // Se a bola sair do limite do tabuleiro
        if (obj.tag == "Robot") {
            // Destroi a bola e aciona o botão retry
//            Destroy(obj.gameObject);
			if (GameObject.Find ("GameManager")) {
				GameObject.Find ("GameManager").SendMessage ("endGame");
			}
//            BarrilScript.atirar = false;
        }
    }
}
