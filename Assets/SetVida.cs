using UnityEngine;
using System;
using UnityEngine.UI;
public class SetVida : MonoBehaviour
{
    private Text vidaGO;
    private int vida;
    
    // Start is called before the first frame update
    void Start()
    {
        vidaGO = GameObject.Find("Vidas").GetComponent<Text>();
    }

    public void setVida(int num)
    {
        vida = num;

    }
    public void restaVida(int num)
    {
        vidaGO.text = (vida - num).ToString();
       
    }
}
