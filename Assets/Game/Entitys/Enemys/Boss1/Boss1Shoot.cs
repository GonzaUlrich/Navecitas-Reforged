using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Shoot : MonoBehaviour
{
    public GameObject myPrefab;
    private GameObject player;
    [Range (0.0f,10.0f)]
    [SerializeField]
    private float shootMaxTimer=1.5f;

    private float timer;
    private Quaternion rotation;


    private void Start() {
        player=GameObject.Find("Player");
    }

    void Update()
    {
        timer += Time.deltaTime;
        Vector3 dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if(timer > shootMaxTimer){
            timer=timer-shootMaxTimer;
            rotation = Quaternion.Euler(0,0,transform.localEulerAngles.z+90);
            Instantiate(myPrefab, new Vector2(transform.position.x, transform.position.y), rotation);
        }
    }
}
