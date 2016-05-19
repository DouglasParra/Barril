using UnityEngine;
using System.Collections;

public class FieldFalse : MonoBehaviour {

    private GameObject gameManager;

    void Awake() {
        gameManager = GameObject.Find("GameManager");
    }

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Robot") {
			gameManager.SendMessage ("loseGame");
            coll.gameObject.GetComponent<Animator>().enabled = true;
            GetComponent<Animator>().SetBool("Destruindo", true);
		}
	}
}
