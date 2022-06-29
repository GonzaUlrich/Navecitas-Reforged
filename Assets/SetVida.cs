using UnityEngine;
using System;
using UnityEngine.UI;
public class SetVida : MonoBehaviour
{
    private Text vidaGO;
    private GameObject player;


    private void Start() {
        player = GameObject.Find("Player");
        vidaGO = GameObject.Find("Vidas").GetComponent<Text>();
        vidaGO.text = player.GetComponent<PlayerLives>().getLives().ToString();
    }


    public void restaVida(int lives,int num)
    {
        vidaGO.text = (lives - num).ToString();
       
    }
}
