using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetHiScore : MonoBehaviour
{
    private Text scoreGO;

    
    void Start()
    {
        scoreGO = GameObject.Find("Score").GetComponent<Text>();
        scoreGO.text = PlayerPrefs.GetInt("score").ToString();
    }
    public void AddScore(int puntos){
        int num = PlayerPrefs.GetInt("score");
        num+=puntos;
        PlayerPrefs.SetInt("score",num);
        scoreGO.text = PlayerPrefs.GetInt("score").ToString();
    }
    public void ResetScore(){
        PlayerPrefs.SetInt("score",0);
    }
}
