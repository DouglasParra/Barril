using UnityEngine;
using System.Collections;

public class FieldMove : MonoBehaviour {

	public Transform goPlaceRef;
	public Transform backPlaceRef;

	private Vector3 goPlace;
	private Vector3 backPlace;

	private bool going = true;

	public float VELOCITY = 10.0f;

    public GameObject rastro;
    public GameObject rastroB;
    private Vector3 pos;

    /////////////////////
    //public float cameraX;
    //public float cameraY;

	// Use this for initialization
	void Start () {
		goPlace = new Vector3(goPlaceRef.position.x, goPlaceRef.position.y, 0);
		backPlace = new Vector3(backPlaceRef.position.x, backPlaceRef.position.y, 0);

        pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        move();
	}

    void move() {
        if (going)
        {
            transform.position = Vector3.MoveTowards(transform.position, goPlace, VELOCITY * Time.deltaTime);
            if (transform.position.Equals(goPlace))
            {
                going = false;

                changeTrailDirection();
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, backPlace, VELOCITY * Time.deltaTime);
            if (transform.position.Equals(backPlace))
            {
                going = true;

                changeTrailDirection();
            }
        }
    }

    void changeTrailDirection() {
        if (rastro.GetComponent<SpriteRenderer>().enabled)
        {
            rastro.GetComponent<SpriteRenderer>().enabled = false;
            rastroB.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            rastro.GetComponent<SpriteRenderer>().enabled = true;
            rastroB.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "MovePlace") {
			going = false;
        }
	}
}
