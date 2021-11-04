using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MeteoroGrandeVida : MonoBehaviour
{
    [Range(1.0f, 10.0f)]
    [SerializeField]
    private int meteoroGrandeLives = 1;
    
    [Range(0.0f, 100.0f)]
    [SerializeField]
    private int points = 1;    
    
    [Range(0.0f, 10.0f)]
    [SerializeField]
    private int cantMeteorosChicos = 2;   

    [Range(0.0f, 95.0f)]
    [SerializeField]
    private float maxDegrees = 45;   

    public GameObject meteoroChico;
    private Text score;

    private void Start() {
        score = GameObject.Find("Score").GetComponent<Text>();
    }


    private void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Bullet")
        {
            meteoroGrandeLives--;
            if (meteoroGrandeLives <= 0)
            {
                int num = int.Parse(score.text);
                num += points;
                score.text = num.ToString();
                for(int i=0; i<cantMeteorosChicos;i++){

                    Quaternion rotation =  Quaternion.Euler(0,0,(Random.Range(-maxDegrees,maxDegrees)));
                    Instantiate(meteoroChico,new Vector2(transform.position.x, transform.position.y),rotation);
                }
                
                Destroy(gameObject);
            }
        }
        else if(other.tag == "Player"){
            Destroy(gameObject);
        }
    }
}
