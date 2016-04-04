using UnityEngine;
using System.Collections;

public class CameraValuesScript : MonoBehaviour {

    public float xMin, xMax, yMin, yMax;

	void FixedUpdate() {
		transform.rotation = Quaternion.identity;
		transform.position = new Vector3(GameObject.Find ("Robot").transform.position.x, GameObject.Find ("Robot").transform.position.y, -10);
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
