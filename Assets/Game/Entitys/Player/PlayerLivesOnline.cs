using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
            Mirror.NetworkConnection _other = GetOtherPlayer();
            if(_other != null)
                RpcWin(_other);
                else
                Debug.LogError("Estoy diciendole que gano a un player que no esta? Algo esta mal.");
            RpcDie(this.GetComponent<Mirror.NetworkIdentity>().connectionToClient);
            //gameOver.GetComponent<GameOver>().EndGame();
        }
    }

    [Mirror.TargetRpc]
    void RpcDie(Mirror.NetworkConnection target)
    {
        Debug.Log("IM DEAD  " +  this.gameObject.name);
        Mirror.NetworkManager.singleton.StopClient();
        SceneManager.LoadScene("GameOver");//:C
        //ACA PONE LO QUE LE PASA AL PETE QUE SE MUERE.
    }

    [Mirror.TargetRpc]
    void RpcWin(Mirror.NetworkConnection target)
    {
        Debug.Log("I WONNED  " +  this.gameObject.name);
        Mirror.NetworkManager.singleton.StopClient();
        SceneManager.LoadScene("Game");
        
    }

    Mirror.NetworkConnection GetOtherPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            if(players[i] != this.gameObject)
                return players[i].GetComponent<Mirror.NetworkIdentity>().connectionToClient;
        }
        return null;
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