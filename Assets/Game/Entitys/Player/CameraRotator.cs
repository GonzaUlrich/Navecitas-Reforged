using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : Mirror.NetworkBehaviour
{
    [Mirror.TargetRpc]
    public void RotateCamera(Mirror.NetworkConnection target)
    {
        GameObject.FindGameObjectWithTag("MainCamera").transform.Rotate(new Vector3(0,0,180));
    }
}
