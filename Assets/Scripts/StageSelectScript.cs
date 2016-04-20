﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Facebook.Unity;

public class StageSelectScript : MonoBehaviour {

    public Text playerName;

	// Use this for initialization
	void Start () {
        playerName.text = PlayerPrefs.GetString("DisplayName");
	}

    // Update is called once per frame
	void Update () {
	
	}

    public void StageSelect() {
        SceneManager.LoadScene(0);
    }

    public void StageSelect_Fases()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void RankScene()
    {
        SceneManager.LoadScene("RankScene");
    }

    public void scene1_1()
    {
        SceneManager.LoadScene("1-1");
    }

	public void scene1_2()
	{
		SceneManager.LoadScene("1-2");
	}

	public void scene1_3()
	{
		SceneManager.LoadScene("1-3");
	}

	public void scene1_4()
	{
		SceneManager.LoadScene("1-4");
	}

	public void scene1_5()
	{
		SceneManager.LoadScene("1-5");
	}

	public void scene1_6()
	{
		SceneManager.LoadScene("1-6");
	}

	public void scene1_7()
	{
		SceneManager.LoadScene("1-7");
	}

	public void scene1_8()
	{
		SceneManager.LoadScene("1-8");
	}

	public void scene1_9()
	{
		SceneManager.LoadScene("1-9");
	}

	public void scene1_10()
	{
		SceneManager.LoadScene("1-10");
	}

	public void tutorial()
	{
		SceneManager.LoadScene("TutorialScene");
	}


}
