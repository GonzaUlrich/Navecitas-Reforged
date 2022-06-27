using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public GameObject gameOver;
    public GameObject vida;

    private void Start()
    {
        vida = GameObject.Find("ScoreTotalUltimate4");
        vida.GetComponent<SetVida>().setVida(lives);
    }
    int getLives(){
        return lives;
    }
    void setDamage(int damage){

        lives-=damage;
        vida.GetComponent<SetVida>().restaVida(damage);
        if (lives<=0){
            
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
