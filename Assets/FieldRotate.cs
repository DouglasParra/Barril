using UnityEngine;
using System.Collections;

public class FieldRotate : MonoBehaviour {

	public bool clockwise = false;

	public bool rotateFull360 = false;

	public float angleToGo;

	private float angleToBack;

	public float VELOCITY = 1.5f;

	private bool going = true;

	private float clockwiseConstant;

    private GameObject mainCamera;

	// Use this for initialization
	void Start () {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

		angleToBack = Mathf.Floor(transform.eulerAngles.z);

		if (clockwise) {
			clockwiseConstant = -VELOCITY;
		} else {
			clockwiseConstant = VELOCITY;
		}
	}
	
	// Update is called once per frame
	void Update () {
		rotate ();
	}

	void rotate () {
        if (mainCamera.activeInHierarchy)
        {
            if (rotateFull360)
            {
                transform.Rotate(Vector3.forward, clockwiseConstant, Space.Self);
            }
            else
            {
                if (going == true)
                {
                    transform.Rotate(Vector3.forward, clockwiseConstant, Space.Self);

                    // Range do angleToGo ate angleToGo + 2
                    if (Mathf.Floor(transform.eulerAngles.z) >= angleToGo && Mathf.Floor(transform.eulerAngles.z) <= angleToGo + 2)
                    {
                        going = false;
                    }
                }
                else
                {
                    transform.Rotate(Vector3.forward, clockwiseConstant * -1, Space.Self);

                    // Range do angleToBack ate angleToBack + 2
                    if (Mathf.Floor(transform.eulerAngles.z) >= angleToBack && Mathf.Floor(transform.eulerAngles.z) <= angleToBack + 2)
                    {
                        going = true;
                    }
                }
            }
        }
	}
			
}



