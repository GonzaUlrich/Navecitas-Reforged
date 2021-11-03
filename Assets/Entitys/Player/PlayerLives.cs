using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    private int lives = 3;

    int getLives(){
        return lives;
    }
    void setDamage(int damage){
        lives-=damage;
        if(lives<=0){
            Debug.Log("Game Over");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Bullet"){

        }else{
            setDamage(1);
            Debug.Log(lives);
        }
    }

}
