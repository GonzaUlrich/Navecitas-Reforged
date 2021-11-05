using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalImput = Input.GetAxis("Vertical");
        float horizontallImput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontallImput, verticalImput,0f);
        transform.Translate(direction * speed *Time.deltaTime);
    }
}
