using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class ButtonManager : MonoBehaviour
{
    private Text hiScore;
    private Text score;
    void Start()
    {
        hiScore = GameObject.Find("ValueHiScore").GetComponent<Text>();
        score = GameObject.Find("ValueScore").GetComponent<Text>();
        Debug.Log("Score" + PlayerPrefs.GetInt("score"));
        Debug.Log("Hi" + PlayerPrefs.GetInt("hiScore"));
        if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("hiScore"))
        {

            hiScore.text = PlayerPrefs.GetInt("score").ToString();
            PlayerPrefs.SetInt("hiScore", PlayerPrefs.GetInt("score"));
        }
        else
        {
            hiScore.text = PlayerPrefs.GetInt("hiScore").ToString();

        }
        score.text = PlayerPrefs.GetInt("score").ToString();

    }
    /*void start(){
        Debug.Log("GameStart");
        AnalyticsResult r = Analytics.CustomEvent("GameStart");
        if (r == AnalyticsResult.Ok)
            Debug.Log("GameStart OK");
    }*/
    public void Play(){
        PlayerPrefs.SetInt("score",0);
        
        PlayerPrefs.SetInt("hiScore",PlayerPrefs.GetInt("hiScore"));
        SceneManager.LoadScene("Game");
    }
    public void Exit(){
        Application.Quit();
    }
}
