using UnityEngine;
using System.Collections;

public class FieldFalse : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Robot") {
			GameObject.Find ("GameManager").SendMessage ("loseGame");
            GetComponent<Animator>().SetBool("Destruindo", true);
		}
	}
}
