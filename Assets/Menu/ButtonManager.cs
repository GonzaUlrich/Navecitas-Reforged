using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class ButtonManager : MonoBehaviour
{
    void start(){
        Debug.Log("GameStart");
        AnalyticsResult r = Analytics.CustomEvent("GameStart");
        if (r == AnalyticsResult.Ok)
            Debug.Log("GameStart OK");
    }
    public void Play(){
        PlayerPrefs.SetInt("score",0);
        
        PlayerPrefs.SetInt("hiScore",PlayerPrefs.GetInt("hiScore"));
        SceneManager.LoadScene("Game");
    }
    public void Exit(){
        Application.Quit();
    }
}
