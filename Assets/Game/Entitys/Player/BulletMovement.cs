using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    float movementSpeed = 7;
    float timer= 0;

    private GameObject player;

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * movementSpeed;
        timer += Time.deltaTime;
        if(timer>2){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy"){
            Destroy(gameObject);
        }
        else if (other.tag == "Player")
        {
            if(other.gameObject != player)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetParentPlayer(GameObject _player)
    {
        player = _player;
    }
    public GameObject GetParentPlayer()
    {
        return player;
    }
}
