using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour
{
    public GameObject target;
    [Range(0.0f,10f)]
    [SerializeField]
    private float movementSpeed =3;

    private void Start() {
        target= GameObject.Find("Player");
    }
    void Update()
    {
        Vector3 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.position += transform.up * Time.deltaTime * movementSpeed;
    }
}
