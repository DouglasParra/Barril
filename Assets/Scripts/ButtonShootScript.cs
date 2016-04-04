using UnityEngine;
using System.Collections;

public class ButtonShootScript : MonoBehaviour {
    public void Atirar() {
        BarrilScript.atirar = true;
    }

	public void launchRobot () {
		GameObject.Find ("Robot").SendMessage ("launch");
	}


}
