using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    float movementSpeed = 7;
    float timer= 0;

    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * movementSpeed;
        timer += Time.deltaTime;
        if(timer>3){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy"){
            Destroy(gameObject);
        }
    }
}
