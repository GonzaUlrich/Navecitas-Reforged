using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Range (0.0f,10.0f)]
    [SerializeField]
    private float spawnTimer;
    [SerializeField]
    private GameObject startSapwner;
    [SerializeField]
    private GameObject endSpawner;
    [SerializeField]
    private GameObject spawnerInstanciate;
    private float timer;
    Vector2 actualPos;

    public GameObject[] enemys;


    void Update()
    {
        timer+= Time.deltaTime;

        if(timer>spawnTimer){
            timer=timer-spawnTimer;
            float randomRange= Random.Range(startSapwner.transform.position.x,endSpawner.transform.position.y);
            actualPos  = new Vector2(randomRange,startSapwner.transform.position.y);
            int randomEnemy=Random.Range(0,(enemys.Length));
            Instantiate(enemys[randomEnemy],actualPos,Quaternion.identity);
        }
        

    }
}
