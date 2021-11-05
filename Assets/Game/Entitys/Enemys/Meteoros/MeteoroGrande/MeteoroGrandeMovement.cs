using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoroGrandeMovement : MonoBehaviour
{
    [Range(0.0f,10f)]
    [SerializeField]
    private float movementSpeed =2;
    void Update()
    {
        transform.position -= transform.up * Time.deltaTime * movementSpeed;
    }
}
