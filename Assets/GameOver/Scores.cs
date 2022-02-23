using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scores : MonoBehaviour
{
    private Text hiScore;
    private Text score;
    void Start()
    {
        hiScore = GameObject.Find("ValueHiScore").GetComponent<Text>();
        score = GameObject.Find("ValueScore").GetComponent<Text>();
        
        if(PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("hiScore")){
            hiScore.text = PlayerPrefs.GetInt("score").ToString();
            PlayerPrefs.SetInt("hiScore",PlayerPrefs.GetInt("score"));
        }else{
            hiScore.text = PlayerPrefs.GetInt("hiScore").ToString();
            
        }
        score.text = PlayerPrefs.GetInt("score").ToString();

    }
    public void goToMennu(){
        SceneManager.LoadScene("Menu");
    }
}
