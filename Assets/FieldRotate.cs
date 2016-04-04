using UnityEngine;
using System.Collections;

public class FieldRotate : MonoBehaviour {

	public float angleGo;

	private float angleBack;

	private bool going = true;

	// Use this for initialization
	void Start () {
//		InvokeRepeating("rotate", 1, 0.001f);
		angleBack = transform.eulerAngles.z;
	}
	
	// Update is called once per frame
	void Update () {

		if (going == true) {
			transform.Rotate(Vector3.forward, Time.deltaTime * 100, Space.Self);
			if (transform.eulerAngles.z >= angleGo) {
				going = false;
			}
		} else {
			transform.Rotate(Vector3.forward, -Time.deltaTime * 100, Space.Self);
			if ((angleBack == 0 && transform.eulerAngles.z < 4)|| transform.eulerAngles.z <= angleBack) {
				going = true;
			}
		}
//		Debug.Log (transform.eulerAngles.z);	
	}
}
