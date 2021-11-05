using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Bullet : MonoBehaviour
{
    [Range(0.0f,10f)]
    [SerializeField]
    private float movementSpeed =3;

    private float timer;
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer>5)
            Destroy(gameObject);
        transform.position -= transform.up * Time.deltaTime * movementSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Bullet")
        {
            Destroy(gameObject);
        }
        else if(other.tag == "Player"){
            Destroy(gameObject);
        }
    }
}
