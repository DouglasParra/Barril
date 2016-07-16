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
            StartCoroutine("TocarAnimacaoTeleport");
            fromPortal = false;           
        }
    }

    IEnumerator TocarAnimacaoTeleport()
    {
        yield return new WaitForSeconds(0.5f);

        robot.transform.position = destino.transform.position;
        robot.transform.rotation = destino.transform.rotation;
        robot.transform.parent = destino.transform;

        GameObject g = Instantiate(Resources.Load("RobotTeleportBack"), destino.transform.position, destino.transform.rotation) as GameObject;
        g.transform.parent = destino.transform;

        fromPortal = false;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Robot")
        {
            GetComponent<AudioSource>().Play();
            GameObject g = Instantiate(Resources.Load("RobotTeleportGo"), transform.position, transform.rotation) as GameObject;
            g.transform.parent = this.transform;
            fromPortal = true;
            robot = coll.gameObject;
        }
    }
}
