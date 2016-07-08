using UnityEngine;
using System.Collections;

public class FieldPortal : MonoBehaviour {

    public GameObject destino;

    private bool fromPortal;

    private GameObject robot;

	// Use this for initialization
	void Awake () {
        fromPortal = false;
	}

    void Update() {
        if (fromPortal) {
            robot.transform.position = destino.transform.position;
            robot.transform.rotation = destino.transform.rotation;
            robot.transform.parent = destino.transform;
            fromPortal = false;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Robot")
        {
            fromPortal = true;
            robot = coll.gameObject;
        }
    }
}
