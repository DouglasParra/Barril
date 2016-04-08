using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoundariesScript : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D obj) {
        if (obj.tag == "Robot") {
			if (GameObject.Find ("GameManager")) {
				GameObject.Find ("GameManager").SendMessage ("loseGame");
			}
        }
    }
}
