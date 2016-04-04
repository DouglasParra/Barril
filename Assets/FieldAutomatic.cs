using UnityEngine;
using System.Collections;

public class FieldAutomatic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator AutomaticShot()
	{
		yield return new WaitForSeconds(.1f);
		GameObject.Find ("Robot").SendMessage ("launch");
//		yield return new WaitForSeconds(.1f);
	}


	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Robot") {
			StartCoroutine(AutomaticShot());
		}
	}
}
