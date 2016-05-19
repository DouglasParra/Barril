﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClockTime : MonoBehaviour {

	public float timer;

	public string timestring;

	private bool canRunTime = false;

    void Awake()
    {
        timestring = "00:00:000";
    }

	// Update is called once per frame
	void Update () {
		if (canRunTime) {
			updateTimes ();
			updateTextComponent ();
		}
	}

	void updateTimes () {
		timer += Time.deltaTime;
	}

    public string RetornaTempoString(int t) {
        string minutes = Mathf.Floor(t / 100000).ToString("00");
        string seconds = Mathf.Floor((t % 100000) / 1000).ToString("00");
        string fraction = Mathf.Floor(t % 1000).ToString("000");

        return minutes + ":" + seconds + ":" + fraction;
    }

	void updateTextComponent () {
		string minutes = Mathf.Floor(timer / 60).ToString("00");
		string seconds = Mathf.Floor(timer % 60).ToString("00");
		string fraction = Mathf.Floor((timer * 1000) % 1000).ToString("000");
		timestring = minutes + ":" + seconds + ":" + fraction;
		GetComponent<Text> ().text = timestring;
	}

	public void startTime () {
		canRunTime = true;
	}

	public void stopTime () {
		canRunTime = false;
	}

	public void statTimeCheckpoint (float timer) {
		this.timer = timer;
		updateTextComponent ();
	}
}
