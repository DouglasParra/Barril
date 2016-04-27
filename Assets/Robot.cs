using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {

	public float SPEED_LAUNCH = 5.0f;

	public float GRAVITY_SCALE = 1.0f;

//	public Camera camera;

//	void Awake()
//	{
//		// Muda velocidade das animações
//		camera = GameObject.FindGameObjectWithTag("MainCam;era").GetComponent<Camera>();
//	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	void FixedUpdate()
//	{
////		if (transform.parent == null)
////		{
//			camera.transform.position = new Vector3(Mathf.Lerp(camera.transform.position.x, Mathf.Clamp(transform.position.x, camera.GetComponent<CameraValuesScript>().getXMin(), camera.GetComponent<CameraValuesScript>().getXMax()), .25f),
//				Mathf.Lerp(camera.transform.position.y, Mathf.Clamp(transform.position.y, camera.GetComponent<CameraValuesScript>().getYMin(), camera.GetComponent<CameraValuesScript>().getYMax()), .25f),
//				-10);
////		}
//	}


	public void launch () {

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
