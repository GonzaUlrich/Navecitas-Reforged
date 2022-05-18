using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public GameObject gameOver;

    int getLives(){
        return lives;
    }
    void setDamage(int damage){

        lives-=damage;
        if(lives<=0){
            
            gameOver.GetComponent<GameOver>().EndGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag=="Bullet"){

        }else{
            setDamage(1);
        }
    }

}
