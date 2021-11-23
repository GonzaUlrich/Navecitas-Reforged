using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private Text score;
    public static int gameScore;
    public static int hiScore;

    private void Start() {
        score = GameObject.Find("Score").GetComponent<Text>();
    }

    public void EndGame(){
         gameScore = int.Parse(score.text);
         SceneManager.LoadScene("GameOver");
    }
}
