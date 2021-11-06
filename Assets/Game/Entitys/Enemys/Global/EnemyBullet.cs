using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [Range(0.0f,10f)]
    [SerializeField]
    private float movementSpeed =3;
    void Update()
    {
        transform.position -= transform.up * Time.deltaTime * movementSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Bullet")
        {
            Destroy(gameObject);
        }
        else if(other.tag == "Player"){
            Destroy(gameObject);
        }
        else if(other.tag == "DeathBox"){
            Destroy(gameObject);
        }
    }
}
