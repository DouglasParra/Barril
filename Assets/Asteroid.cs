using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

    private GameObject gameManager;

    void Awake() {
        gameManager = GameObject.Find("GameManager");
    }

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Robot") {
			gameManager.SendMessage ("loseGame");
		}
	}
}
