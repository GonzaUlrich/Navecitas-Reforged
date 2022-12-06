using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementJefe3 : MonoBehaviour
{
    [Range(0.0f, 10.0f)]
    public float velocityForward = 2;
    [Range(0.0f, 10.0f)]
    public float velocityForwardRage = 8;
    [Range(0.0f, 10.0f)]
    public float velocityRight = 2;
    [Range(0.0f, 10.0f)]
    public float Rate = 1.5f;

    public float until = 0;
    private float tiempo;
    public Transform Spawn_bala;
    public GameObject Disparo_M_Prefab;
    public GameObject paredIzquierda;
    public GameObject paredDerecha;
    private GameObject player;
    private GameObject playerPos;
    private int state = 0;

    private enum states
    {
        coming = 0,
        shot,
        charge,
        backToPosition
    }
    void Start()
    {
        player = GameObject.Find("Player");
        playerPos = new GameObject();
    }

    void Update()
    {
        switch (state)
        {
            case (int)states.coming:
                if (transform.position.z > until)
                {
                    transform.position += transform.forward * -velocityForward * Time.deltaTime;
                }
                else
                {
                    state = (int)states.shot;
                }
                break;

            case (int)states.shot:
                transform.position += transform.right * -velocityRight * Time.deltaTime;
                if (transform.position.x < paredIzquierda.transform.position.x)
                    velocityRight *= -1;
                if (transform.position.x > paredDerecha.transform.position.x)
                    velocityRight *= -1;
                //----------------    
                tiempo += Time.deltaTime;
                if (tiempo > Rate)
                {
                    Instantiate(Disparo_M_Prefab, Spawn_bala.position, Disparo_M_Prefab.transform.rotation);
                    tiempo = 0;
                }
                break;

            case (int)states.charge:
                Debug.Log("desp     " + playerPos.transform.position);
                transform.position = Vector3.MoveTowards(transform.position, playerPos.transform.position, velocityForwardRage * Time.deltaTime);
                if (Vector3.Distance(transform.position, playerPos.transform.position) < 0.001f)
                {
                    state = (int)states.backToPosition;
                }
                break;

            case (int)states.backToPosition:
                if (transform.position.z < until)
                {
                    transform.position += transform.forward * velocityForward * Time.deltaTime;
                }
                else
                {
                    state = (int)states.shot;
                }
                break;

            default:
                break;
        }
    }
    public void ChangeState()
    {
        playerPos.transform.position = player.transform.position;
        Debug.Log("inicual " + playerPos.transform.position);
        state = (int)states.charge;
    }
}