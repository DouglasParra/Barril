using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {

	public float SPEED_LAUNCH = 5.0f;

	public float GRAVITY_SCALE = 1.0f;

	private Camera camera;

	void Awake()
	{
		camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        camera.transform.position = transform.position;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        /*if (transform.parent.name.StartsWith("MOV"))
        {
            camera.GetComponent<CameraValuesScript>().podeMover = false;

            camera.transform.position = new Vector3(transform.GetComponentInParent<FieldMove>().cameraX,
                                                    transform.GetComponentInParent<FieldMove>().cameraY,
                                                    -10);
        }
        else
        {
            camera.GetComponent<CameraValuesScript>().podeMover = true;
        }*/
	}

	public void launch () {

        camera.GetComponent<CameraValuesScript>().podeMover = true;
		GetComponentInParent<Transform>().position = transform.position + transform.up * 2;

		activeFieldLaunchAnimation ();

		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.gravityScale = GRAVITY_SCALE;
		rb.velocity = transform.up * SPEED_LAUNCH;


		transform.parent = null;
		GetComponent<BoxCollider2D> ().isTrigger = false;

	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Fields") {
			this.transform.parent = coll.gameObject.transform;
			GetComponent<BoxCollider2D> ().isTrigger = true;
			this.transform.position = coll.gameObject.transform.position;
			this.transform.rotation = coll.gameObject.transform.rotation;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.0f, 0.0f);
			GetComponent<Rigidbody2D> ().gravityScale = 0.0f;
		}
	}

	void goToField (GameObject field) {
		this.transform.position = field.transform.position;
		this.transform.rotation = field.transform.rotation;
		this.transform.parent = field.transform;
	}

	void activeFieldLaunchAnimation () {
		if (transform.parent.gameObject.GetComponent<Animator> ()) {
			transform.parent.gameObject.GetComponent<Animator> ().SetTrigger ("launch");
		}
	}


}
