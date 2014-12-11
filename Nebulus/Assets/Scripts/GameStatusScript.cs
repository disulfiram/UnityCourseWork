﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameStatusScript : MonoBehaviour {

    public Text Scores;
    public Text timer;
    public Button TryAgain;
    public Button Back;
    public RectTransform[] Lives = new RectTransform[3];
    float time = 0;
	void Start () {
        
	}
	

	void Update () {
        //Display Scores        
        Scores.text = PlayerPrefs.GetInt("Score").ToString();
        
        //Display Lives of Pogo
        if (PlayerPrefs.GetInt("Lives") == 3)
        {
            Lives[0].gameObject.SetActive(true);
            Lives[1].gameObject.SetActive(true);
            Lives[2].gameObject.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("Lives") == 2) 
        {
            Lives[0].gameObject.SetActive(true);
            Lives[1].gameObject.SetActive(true);
            Lives[2].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Lives") == 1)
        {
            Lives[0].gameObject.SetActive(true);
            Lives[1].gameObject.SetActive(false);
            Lives[2].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Lives") == 0)
        {
            Lives[0].gameObject.SetActive(false);
            Lives[1].gameObject.SetActive(false);
            Lives[2].gameObject.SetActive(false);
        }

        //Set timer 
        if (PlayerPrefs.GetInt("Lives") > 0) { 
            time += Time.deltaTime;
            timer.text = Mathf.Floor(time / 60).ToString("00")+":"+(time % 60).ToString("00");
            TryAgain.gameObject.SetActive(true);
            Back.gameObject.SetActive(true);
        }
        
        


	}
    public void playAgain()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void backToMenu()
    {
        Application.LoadLevel("menu");
    }
    public void ResetPoints()
    {
        PlayerPrefs.DeleteKey("Scores");
    }
}
