using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteoroChicoVida : MonoBehaviour
{
    [Range(1.0f, 10.0f)]
    [SerializeField]
    private int meteoroChicoLives = 1;
    
    [Range(0.0f, 100.0f)]
    [SerializeField]
    private int points = 1;    
    
    private Text score;

    private void Start() {
        score = GameObject.Find("Score").GetComponent<Text>();
    }


    private void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Bullet")
        {
            meteoroChicoLives--;
            if (meteoroChicoLives <= 0)
            {
                int num = int.Parse(score.text);
                num += points;
                score.text = num.ToString();
                
                Destroy(gameObject);
            }
        }
        else if(other.tag == "Player"){
            Destroy(gameObject);
        }
    }
}
