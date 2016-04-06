using UnityEngine;
using System.Collections;

public class FieldMove : MonoBehaviour {

	public Transform goPlaceRef;
	public Transform backPlaceRef;

	private Vector3 goPlace;
	private Vector3 backPlace;

	private bool going = true;

	public float VELOCITY = 10.0f;

	// Use this for initialization
	void Start () {
		goPlace = new Vector3(goPlaceRef.position.x, goPlaceRef.position.y, 0);
		backPlace = new Vector3(backPlaceRef.position.x, backPlaceRef.position.y, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (going) {
			transform.position = Vector3.MoveTowards (transform.position, goPlace, VELOCITY * Time.deltaTime);
			if(transform.position.Equals(goPlace)){
				going = false;
			}
		} else {
			transform.position = Vector3.MoveTowards (transform.position, backPlace, VELOCITY * Time.deltaTime);
			if(transform.position.Equals(backPlace)){
				going = true;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "MovePlace") {
			going = false;
		}
	}
}
