using UnityEngine;
using System.Collections.Generic;

namespace Mirror.Examples.Pong
{
    // Custom NetworkManager that simply assigns the correct racket positions when
    // spawning players. The built in RoundRobin spawn method wouldn't work after
    // someone reconnects (both players would be on the same side).
    [AddComponentMenu("")]
    public class NetworkManagerPong : NetworkManager
    {
        public Transform leftRacketSpawn;
        public Transform rightRacketSpawn;

        public GameObject screenFlipper;

        public GameObject playerCamera;

        GameObject ball;


        List<NetworkRoom> rooms;

        
        public override void OnStartServer()
        {
            rooms = new List<NetworkRoom>();

            if(IsServer)
            {
                GameObject.FindGameObjectWithTag("MainCamera").SetActive(false);
                Destroy(GameObject.FindGameObjectWithTag("Player"));
                Destroy(GameObject.FindGameObjectWithTag("MultiplayerTrigger"));
            }
        }

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            Debug.Log("Takoyaki Added Player. Playercount: " + numPlayers);

            // add player at correct spawn position
            Transform start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;

            //POR AHI PODEMOS REEMPLAZAR ESTO POR EL PREFAB QUE YA ESTE EN EL JUEGO.
            GameObject player;

            if(numPlayers > 0)
            {
                //GameObject cam = Instantiate(playerCamera, new Vector3(0,0,-10), Quaternion.Euler(0,0,0));
                player = Instantiate(playerPrefab, start.position, Quaternion.Euler(0,0,180));
                //player.GetComponent<PlayerMovementOnline>().LinkCamera(cam);
            }
            else
            {
                //GameObject cam = Instantiate(playerCamera, new Vector3(0,0,-10), Quaternion.Euler(0,0,180));
                player = Instantiate(playerPrefab, start.position, start.rotation);
                //player.GetComponent<PlayerMovementOnline>().LinkCamera(cam);
            }
            
            //player.SetActive(false);
            NetworkServer.AddPlayerForConnection(conn, player);
        }

        public override void OnServerDisconnect(NetworkConnection conn)
        {

            // call base functionality (actually destroys the player)
            base.OnServerDisconnect(conn);
        }

        public void EndGame()
        {
            if(!IsServer)
                return;
        }


    }
}
