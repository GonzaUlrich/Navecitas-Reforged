using UnityEngine;
using UnityEngine.UI;

public class EnemyLife : MonoBehaviour
{
    [Range(1.0f, 10.0f)]
    [SerializeField]
    private int lives = 10;
    
    [Range(0.0f, 100.0f)]
    [SerializeField]
    private int points = 1;    
    

    private Text score;
    private bool isABoss=false;
    private bool isAMeteoro=false;

    private void Start() {
        score = GameObject.Find("Score").GetComponent<Text>();
        if(string.Compare(gameObject.name,0,"Boss",0,4) == 0){
            isABoss=true;
        }else if(string.Compare(gameObject.name,0,"MeteoroGrande",0,13) == 0){
            isAMeteoro=true;
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Bullet"){
            lives--;
            if (lives <= 0){
                int num = int.Parse(score.text);
                num += points;
                score.text = num.ToString();
                if(isAMeteoro){
                    gameObject.GetComponent<MeteoroGrandeDestroy>().Boom();
                }
                Destroy(gameObject);
            }
        }
        if(!isABoss){
            if(other.tag == "Player"){
                Destroy(gameObject);
            }
        }
        if(other.tag == "DeathBox"){
            Destroy(gameObject);
        }

    }
}
