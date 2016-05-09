using UnityEngine;
using System.Collections;

public class FieldAutomatic : MonoBehaviour {

    private GameObject robot;

	// Use this for initialization
	void Start () {
        robot = GameObject.Find("Robot");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator AutomaticShot()
	{
		yield return new WaitForSeconds(.1f);
        robot.SendMessage("launch");
//		yield return new WaitForSeconds(.1f);
	}


	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Robot") {
			StartCoroutine(AutomaticShot());
		}
	}
}
