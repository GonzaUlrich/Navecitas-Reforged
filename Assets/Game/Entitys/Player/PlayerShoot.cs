using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject myPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(myPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
        
    }
}
