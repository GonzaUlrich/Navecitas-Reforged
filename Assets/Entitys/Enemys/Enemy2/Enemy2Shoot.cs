using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Shoot : MonoBehaviour
{
   public GameObject myPrefab;
    [Range (0.0f,10.0f)]
    [SerializeField]
    private float shootMaxTimer=1.5f;

    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer+= Time.deltaTime;

        if(timer>shootMaxTimer){
            timer=timer-shootMaxTimer;
            Instantiate(myPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
        
    }
}
