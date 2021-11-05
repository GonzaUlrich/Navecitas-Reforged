using UnityEngine;
using UnityEngine.UI;

public class Boss1Live : MonoBehaviour
{
    [Range(1.0f, 10.0f)]
    [SerializeField]
    private int Boss1Lives = 10;
    
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
            Boss1Lives--;
            if (Boss1Lives <= 0)
            {
                int num = int.Parse(score.text);
                num += points;
                score.text = num.ToString();
                Destroy(gameObject);
            }
        }
    }
}
