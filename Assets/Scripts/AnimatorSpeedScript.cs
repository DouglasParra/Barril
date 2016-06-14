using UnityEngine;
using System.Collections;

public class AnimatorSpeedScript : MonoBehaviour {

    public float speed = 1.0f;

	// Use this for initialization
	void Start () {
        GetComponent<Animator>().speed = speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
