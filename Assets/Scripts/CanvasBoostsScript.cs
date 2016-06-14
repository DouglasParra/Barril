using UnityEngine;
using System.Collections;

public class CanvasBoostsScript : MonoBehaviour {

    public GameObject minimapa;
    
    private GameObject robot;

	// Use this for initialization
	void Start () {

        robot = GameObject.Find("Robot");

        if (PlayerPrefs.GetInt("Laser") == 0)
        {
            robot.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            robot.transform.GetChild(0).gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("MiniMapa") == 0)
        {
            minimapa.SetActive(false);
        }
        else
        {
            minimapa.SetActive(true);
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
