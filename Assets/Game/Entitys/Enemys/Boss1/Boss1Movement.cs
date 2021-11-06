using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Movement : MonoBehaviour
{
    [SerializeField]
    private GameObject pos; 
    [Range(0.0f,10f)]
    [SerializeField]
    private float movementSpeed =3;

    private void Start() {
        pos = GameObject.Find("GoToBoss1");
    }

    void Update(){
        Vector3 dir = pos.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.position += transform.right * Time.deltaTime * movementSpeed;
    }
}
