using UnityEngine;
using System.Collections;

public class CameraValuesScript : MonoBehaviour {

    public float xMin, xMax, yMin, yMax;
    private GameObject robot;
    public bool podeMover;

    void Start() {
        podeMover = true;
        robot = GameObject.Find("Robot");
    }

	void FixedUpdate() {
		if (podeMover) {
			transform.rotation = Quaternion.identity;
            //transform.position = new Vector3(robot.transform.position.x, robot.transform.position.y, -10);

            transform.position = new Vector3(Mathf.Lerp(transform.position.x, Mathf.Clamp(robot.transform.position.x, getXMin(), getXMax()), .25f),
                                             Mathf.Lerp(transform.position.y, Mathf.Clamp(robot.transform.position.y, getYMin(), getYMax()), .25f),
                                                        -10);
		}
	}

    public float getXMin() 
    {
        return xMin;
    }

    public float getXMax()
    {
        return xMax;
    }

    public float getYMin()
    {
        return yMin;
    }

    public float getYMax()
    {
        return yMax;
    }
}
