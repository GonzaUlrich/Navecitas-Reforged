using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoroGrandeDestroy : MonoBehaviour
{
    [Range(0.0f, 10.0f)]
    [SerializeField]
    private int cantMeteorosChicos = 2;   

    [Range(0.0f, 95.0f)]
    [SerializeField]
    private float maxDegrees = 45;   

    public GameObject meteoroChico;

    public void Boom(){
        for(int i=0; i<cantMeteorosChicos;i++){
            Quaternion rotation =  Quaternion.Euler(0,0,(Random.Range(-maxDegrees,maxDegrees)));
            Instantiate(meteoroChico,new Vector2(transform.position.x, transform.position.y),rotation);
        }
    }
}
