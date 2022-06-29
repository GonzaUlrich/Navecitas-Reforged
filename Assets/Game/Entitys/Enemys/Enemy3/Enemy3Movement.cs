using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Movement : MonoBehaviour
{
    [Range(0.0f,10f)]
    [SerializeField]
    private float movementForward =1.5f;

    [Range(0.0f,10f)]
    [SerializeField]
    private float movementSides =2;

    [Range(0.0f,10f)]
    [SerializeField]
    private float distance =1.5f;

    private Vector2 actualPos;
    private int lateralMovement;

    private void Start() {
        actualPos =new Vector2(transform.position.x,transform.position.y);
        lateralMovement = Random.Range(0,2);
    }

    void Update()
    {
        //movimiento vertical
        transform.position -= transform.up * Time.deltaTime * movementForward;
        //movimiento horizontal
        switch(lateralMovement){
            case 0:
            transform.position -= transform.right * Time.deltaTime * movementSides;
            if(transform.position.x<actualPos.x-distance){
                lateralMovement=1;
            }
            
            break;
             case 1:
             transform.position += transform.right * Time.deltaTime * movementSides;
            if(transform.position.x>actualPos.x+distance){
                lateralMovement=0;
            }
            break;
        } 

        
        
    }
}
