using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void Play(){
        PlayerPrefs.SetInt("score",0);
        PlayerPrefs.SetInt("hiScore",0);
        SceneManager.LoadScene("Game");
    }

    public void Exit(){
        Application.Quit();
    }

}
