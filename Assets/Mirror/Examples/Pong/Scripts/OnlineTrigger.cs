using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class OnlineTrigger : MonoBehaviour
    {

        GameObject NetworkManager;

        // Start is called before the first frame update
        void Start()
        {
            NetworkManager = GameObject.FindGameObjectWithTag("NetworkManager");
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if(col.tag == "Player")
            {
                NetworkManager.GetComponent<Mirror.NetworkManagerHUD>().ConnectClient();
                Destroy(col.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
