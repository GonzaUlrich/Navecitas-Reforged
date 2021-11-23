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
        Debug.Log(GameOver.hiScore);
        if(GameOver.gameScore > GameOver.hiScore){
            hiScore.text = GameOver.gameScore.ToString();
            GameOver.hiScore =GameOver.gameScore;
        }else{
            hiScore.text = GameOver.hiScore.ToString();
            
        }
        score.text = GameOver.gameScore.ToString();

    }
    public void goToMennu(){
        SceneManager.LoadScene("Menu");
    }
}
