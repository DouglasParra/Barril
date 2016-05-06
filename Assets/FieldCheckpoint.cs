using UnityEngine;
using System.Collections;

public class FieldCheckpoint : MonoBehaviour {

	[Tooltip("Ordem do checkpoint, se esse for o primeiro, sete como 0")]
	public int order;

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Robot") {
			GameObject.Find ("GameManager").SendMessage ("checkpoint", order);
            Instantiate(Resources.Load("LetrasCheckpoint"), transform.position, Quaternion.identity);
        }
	}
}
