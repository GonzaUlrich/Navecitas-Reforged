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
    private float spawnBoss1;

    private GameObject prefab;

    public List<GameObject> enemys;
    public GameObject[] bosses;
    public Sprite[] sprites;
    public float proximoJefe;

    private Text score;
    private int scoreNum;
    private int state = 0;
    private bool boss1appear = true;
    GameObject clone;
    private int checkSpawnBoss;

    private List<int> listObjts = new List<int>();
    private List<Vector2> listPos = new List<Vector2>();

    public GameObject testeEnemy;
    private bool enemyAdd = false;


    private void Start() {
        score = GameObject.Find("Score").GetComponent<Text>();
        checkSpawnBoss = PlayerPrefs.GetInt("score");

        prefab = GameObject.Find("Prefab");
        
    }
    void Update()
    {
        timer += Time.deltaTime;
        scoreNum = int.Parse(score.text);
        if (scoreNum >= 600 && enemyAdd == false)
        {
            addEnemy(testeEnemy);
            enemyAdd = true;
        }
        while (listObjts.Count < 10) {
            float randomRange = Random.Range(startSapwner.transform.position.x, endSpawner.transform.position.x);
            actualPos = new Vector2(randomRange, startSapwner.transform.position.y);
            int randomEnemy = Random.Range(0, (enemys.Count));
            if (randomEnemy == 0) {
                for (int i = 0; i < 3; i++) {
                    listObjts.Add(randomEnemy);
                    listPos.Add(actualPos);
                    randomRange = Random.Range(startSapwner.transform.position.x, endSpawner.transform.position.x);
                    actualPos = new Vector2(randomRange, startSapwner.transform.position.y);
                }
            } else {
                listObjts.Add(randomEnemy);
                listPos.Add(actualPos);
            }
        }
        if (timer > spawnTimer)
        {
            if (scoreNum >= spawnBoss1 + checkSpawnBoss && boss1appear) {
                state = 1;
            }
            switch (state) {
                case 0:
                    //float randomRange = Random.Range(startSapwner.transform.position.x, endSpawner.transform.position.x);
                    //actualPos = new Vector2(randomRange, startSapwner.transform.position.y);
                    //int randomEnemy = Random.Range(0, (enemys.Length));
                    if (listObjts[0] == 0) {
                        for (int i = 0; i < 3; i++) {
                            Instantiate(enemys[listObjts[0]], listPos[0], Quaternion.identity);
                            listObjts.RemoveAt(0);
                            listPos.RemoveAt(0);
                        }
                        listObjts.RemoveAt(0);
                        listPos.RemoveAt(0);
                    } else {
                        Instantiate(enemys[listObjts[0]], listPos[0], Quaternion.identity);
                        listObjts.RemoveAt(0);
                        listPos.RemoveAt(0);
                    }
                    checkTimer();
                    break;
                //--------
                case 1:
                    if (timer > spawnTimer + 5) {

                        clone = Instantiate(bosses[0], transform.position, Quaternion.identity);
                        clone.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.1f,1.0f), Random.Range(0.1f, 1.0f), Random.Range(0.1f, 1.0f));
                        state = 90;
                        timer = timer - spawnTimer + 5;
                        boss1appear = false;
                    }
                    break;
                case 90:
                    if (clone == null) {
                        state = 0;
                        timer = 0;
                        boss1appear = true;
                        spawnBoss1 += proximoJefe*=1.2f;
                    }
                    break;
                default:
                    break;
            }
            //  ShowNextEnemy();                            
        }
    }
    private void checkTimer() {
        while (timer > spawnTimer) {
            timer = timer - spawnTimer;
        }
    }
    public void addEnemy(GameObject _enemy)
    {
        enemys.Add(_enemy);
    }

   /* private void ShowNextEnemy(){
        
        Debug.Log(prefab);
        switch(listObjts[0]){
            case 0:
                prefab.GetComponent<SpriteRenderer>().sprite = sprites[0]; 
                prefab.transform.position = new Vector2 (listPos[0].x , prefab.transform.position.y);
            break;
            case 1:
                prefab.GetComponent<SpriteRenderer>().sprite = sprites[1]; 
                prefab.transform.position = new Vector2 (listPos[1].x , prefab.transform.position.y);
            break;
            case 2:
                prefab.GetComponent<SpriteRenderer>().sprite = sprites[2];
                prefab.transform.position = new Vector2 (listPos[2].x , prefab.transform.position.y); 
            break;
            case 3:
                prefab.GetComponent<SpriteRenderer>().sprite = sprites[3];
                prefab.transform.position = new Vector2 (listPos[3].x , prefab.transform.position.y); 
            break;
            case 4:
                prefab.GetComponent<SpriteRenderer>().sprite = sprites[4]; 
                prefab.transform.position = new Vector2 (listPos[4].x , prefab.transform.position.y);
            break;
            case 5:
                prefab.GetComponent<SpriteRenderer>().sprite = sprites[5]; 
                prefab.transform.position = new Vector2 (listPos[5].x , prefab.transform.position.y);
            break;
            case 6:
                prefab.GetComponent<SpriteRenderer>().sprite = sprites[6]; 
                prefab.transform.position = new Vector2 (listPos[6].x , prefab.transform.position.y);
            break;

        }
    }*/
}
