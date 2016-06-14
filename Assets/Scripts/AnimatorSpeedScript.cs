using UnityEngine;
using System.Collections;

public class AnimatorSpeedScript : MonoBehaviour {

    public float speed = 1.0f;
    public bool reverse = false;

	// Use this for initialization
	void Start () {
        GetComponent<Animator>().speed = speed;
        GetComponent<Animator>().SetBool("reverse", reverse);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
