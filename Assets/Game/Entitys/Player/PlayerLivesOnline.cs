using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLivesOnline : Mirror.NetworkBehaviour
{
    [Mirror.SyncVar]
    public int lives = 3;
    public GameObject gameOver;

    int getLives(){
        return lives;
    }

    void setDamage(int damage)
    {
        if(!isServer)
        return;

        lives-=damage;
        if(lives<=0){
            RpcDie(this.GetComponent<Mirror.NetworkIdentity>().connectionToClient);
            //gameOver.GetComponent<GameOver>().EndGame();
        }
    }

    [Mirror.TargetRpc]
    void RpcDie(Mirror.NetworkConnection target)
    {
        Debug.Log("IM DEAD  " +  this.gameObject.name);
        Mirror.NetworkManager.singleton.StopClient();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        Debug.Log("HIT!");

        if(other.tag=="Bullet"){
            if(other.gameObject.GetComponent<BulletMovement>().GetParentPlayer() != this.gameObject)
            {
                Debug.Log("And it counts!");

                setDamage(1);
            }

        }else{

            setDamage(1);
        }
    }

}