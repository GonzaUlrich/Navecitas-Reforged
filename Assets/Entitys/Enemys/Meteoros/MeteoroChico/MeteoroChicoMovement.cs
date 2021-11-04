using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoroChicoMovement : MonoBehaviour
{
    [Range(0.0f,10f)]
    [SerializeField]
    private float movementSpeed =3;
    void Update()
    {
        transform.position -= transform.up * Time.deltaTime * movementSpeed;
    }
}
