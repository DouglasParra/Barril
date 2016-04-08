using UnityEngine;
using System.Collections;

public class ButtonShootScript : MonoBehaviour {

	private bool firstLaunch = true;

	public void launchRobot () {
		if (firstLaunch) {
			startClockTime ();
		}
		GameObject.Find ("Robot").SendMessage ("launch");
	}

	void startClockTime () {
		if (GameObject.Find ("ClockTime")) {
			GameObject.Find ("ClockTime").SendMessage ("startTime");
			firstLaunch = false;
		}
	}


}
