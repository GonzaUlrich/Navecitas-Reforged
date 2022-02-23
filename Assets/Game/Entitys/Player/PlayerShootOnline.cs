using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootOnline : Mirror.NetworkBehaviour
{
    public GameObject bullet;
    public GameObject serverBullet;

    // Update is called once per frame
    void Update()
    {
        if(!isLocalPlayer)
        return;


        if (Input.GetKeyDown("space"))
        {
            //LocalFire();
            CmdFire();
        }
        
    }

    [Mirror.Command]
    void CmdFire()
    {
        GameObject _bullet = Instantiate(serverBullet, new Vector3(transform.position.x, transform.position.y,transform.position.z), transform.rotation);
        _bullet.GetComponent<BulletMovement>().SetParentPlayer(this.gameObject);

        Mirror.NetworkServer.Spawn(bullet);
        RpcLocalFire();
    }

    [Mirror.ClientRpc]
    void RpcLocalFire()
    {
        GameObject _bullet = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y,transform.position.z), transform.rotation);
        _bullet.GetComponent<BulletMovement>().SetParentPlayer(this.gameObject);
    }
}