using UnityEngine;
using System.Collections;

public class ButtonShootScript : MonoBehaviour {

	private bool firstLaunch = true;

    [SerializeField]
    private GameObject robot;
    private GameObject clockTime;

    void Awake() {
        robot = GameObject.Find("Robot");
        clockTime = GameObject.Find("ClockTime");
    }

	public void launchRobot () {
		if (firstLaunch) {
			startClockTime ();
		}

        if (robot.transform.parent.name.StartsWith("AIM")) {
            robot.GetComponentInParent<FieldAim>().launchAim();
        }

		robot.SendMessage ("launch");
	}

	void startClockTime () {
        if (clockTime)
        {
            clockTime.SendMessage("startTime");
			firstLaunch = false;
		}
	}


}
