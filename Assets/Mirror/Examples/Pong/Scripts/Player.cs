using UnityEngine;

namespace Mirror.Examples.Pong
{
    public class Player : NetworkBehaviour
    {
        public float speed = 30;
        public Rigidbody2D rigidbody2d;

        [SyncVar]
        int health = 100;

        // need to use FixedUpdate for rigidbody
        void FixedUpdate()
        {
            // only let the local player control the racket.
            // don't control other player's rackets
            if (isLocalPlayer)
                rigidbody2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0) * speed * Time.fixedDeltaTime;
            
            if(Input.GetKeyDown(KeyCode.K))
            {
                LoseHealth(100);
            }
        }

        void LoseHealth(int ammount)
        {
            health = health - ammount;
            if(health <= 0)
            {
                Die(this.gameObject);
            }

        }

        [TargetRpc]
        void OnDeath(NetworkConnection target)
        {
            Application.Quit();
        }

        [Command]
        void Die(GameObject target)
        {
            NetworkIdentity identity = target.GetComponent<NetworkIdentity>();
            OnDeath(identity.connectionToClient);
        }
    }
}
