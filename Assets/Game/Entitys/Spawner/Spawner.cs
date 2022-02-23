using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [Range(0.0f, 10.0f)]
    [SerializeField]
    private float spawnTimer;
    [SerializeField]
    private GameObject startSapwner;
    [SerializeField]
    private GameObject endSpawner;
    private float timer;
    Vector2 actualPos;
    [SerializeField]
    private int spawnBoss1;

    public GameObject[] enemys;
    public GameObject[] bosses;

    private Text score;
    private int scoreNum;
    private int state=0;
    private bool boss1appear = true;
    GameObject clone;
    private int checkSpawnBoss;

    private void Start() {
        score = GameObject.Find("Score").GetComponent<Text>();
        checkSpawnBoss = PlayerPrefs.GetInt("score");
    }

    void Update()
    {
        timer += Time.deltaTime;
        scoreNum = int.Parse(score.text);
        
        if (timer > spawnTimer )
        {
            if (scoreNum>=spawnBoss1+checkSpawnBoss && boss1appear){
                state=1;
            }
                
            switch(state){
                case 0:
                    float randomRange = Random.Range(startSapwner.transform.position.x, endSpawner.transform.position.x);
                    actualPos = new Vector2(randomRange, startSapwner.transform.position.y);
                    int randomEnemy = Random.Range(0, (enemys.Length));
                    if(randomEnemy==0){
                        for(int i = 0; i<3 ;i++){
                            Instantiate(enemys[randomEnemy], actualPos, Quaternion.identity);
                            randomRange = Random.Range(startSapwner.transform.position.x, endSpawner.transform.position.x);
                            actualPos = new Vector2(randomRange, startSapwner.transform.position.y);
                        }
                    }else{
                        Instantiate(enemys[randomEnemy], actualPos, Quaternion.identity);
                    }
                    checkTimer();
                break;
                //--------
                case 1:
                    if(timer > spawnTimer + 5){

                        clone = Instantiate(bosses[0], transform.position, Quaternion.identity);
                        state=90;
                        timer = timer - spawnTimer + 5;
                        boss1appear=false;
                    }
                    
                break;
                case 90:
                   if(clone==null){
                       state=0;
                       timer=0;
                   }
                break;
                default:
                break;
            }

            
                
            
        }
    }
    private void checkTimer(){
        while(timer>spawnTimer){
            timer = timer - spawnTimer;
        }
    }
}
