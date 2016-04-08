using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Robot") {
			GameObject.Find ("GameManager").SendMessage ("loseGame");
		}
	}
}
