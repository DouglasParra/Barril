using UnityEngine;
using System.Collections;

public class FieldPortal : MonoBehaviour {

    public GameObject destino;

    private bool fromPortal;

    private GameObject robot;
    private GameObject shootButton;

	// Use this for initialization
	void Awake () {
        fromPortal = false;
        shootButton = GameObject.Find("ShootButton");
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

        shootButton.SetActive(true);

        robot.transform.position = destino.transform.position;
        robot.transform.rotation = destino.transform.rotation;
        robot.transform.parent = destino.transform;

        GameObject g = Instantiate(Resources.Load("RobotTeleportBack"), destino.transform.position, destino.transform.rotation) as GameObject;
        g.GetComponent<Animator>().SetInteger("Skin", robot.GetComponent<RobotSkins>().skinNo);
        g.transform.parent = destino.transform;

        CreateMark(destino.transform);

        fromPortal = false;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Robot")
        {
            robot = coll.gameObject;
            shootButton.SetActive(false);
            GetComponent<AudioSource>().Play();
            GameObject g = Instantiate(Resources.Load("RobotTeleportGo"), transform.position, transform.rotation) as GameObject;
            g.GetComponent<Animator>().SetInteger("Skin", robot.GetComponent<RobotSkins>().skinNo);
            g.transform.parent = this.transform;
            fromPortal = true;

            CreateMark(this.transform);
        }
    }

    void CreateMark(Transform t)
    {
        // Marca
        if (PlayerPrefs.GetInt("Mark") == 1)
        {
            //Debug.Log("Criando marca no portal " + t.name);
            bool passouMark = false;
            for (int i = 0; i < t.childCount; i++)
            {
                if (t.GetChild(i).name.StartsWith("Mark"))
                {
                    passouMark = true;
                    break;
                }
            }

            if (!passouMark)
            {
                GameObject g2 = Instantiate(Resources.Load("Mark"), t.transform.position, t.transform.rotation) as GameObject;
                g2.transform.SetParent(t.transform);
                g2.transform.localScale = new Vector3(3, 3, 1);
            }

        }
    }
}
