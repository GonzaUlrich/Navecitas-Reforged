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
            Debug.Log("PEW PEW");
            GameObject bullet = Instantiate(myPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            bullet.GetComponent<BulletMovement>().SetParentPlayer(this.gameObject);
        }
        
    }
}
