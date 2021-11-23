using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.5f;

    public Camera cam;
        float height ;
        float width ;
    private void Start() {
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
    }

    void Update()
    {

        

        float verticalImput = Input.GetAxis("Vertical");
        float horizontallImput = Input.GetAxis("Horizontal");
        //horizontal block
        if(transform.position.x + (transform.position.x * 0.1f) >= (cam.transform.position.x + (width/2.0f))){
            if(horizontallImput>0){
                horizontallImput=0;
            }
        }
        if(transform.position.x + (transform.position.x * 0.1f) <= (cam.transform.position.x - (width/2.0f))){
            if(horizontallImput<0){
                horizontallImput=0;
            }
        }
        //vertical block
        if(transform.position.y + (transform.position.y * 0.1f) >= (cam.transform.position.y + (height/2.0f))){
            if(verticalImput>0){
                verticalImput=0;
            }
        }   
        if(transform.position.y + (transform.position.y * 0.1f) <= (cam.transform.position.y - (height/2.0f))){
            if(verticalImput<0){
                verticalImput=0;
            }
        }   

        Vector3 direction = new Vector3(horizontallImput, verticalImput,0f);
        transform.Translate(direction * speed *Time.deltaTime);

        
        

    }
}
