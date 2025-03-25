using UnityEngine;
using UnityEngine.InputSystem;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    // not used start cause we ensure that the reference is in place (start is called after the reference is set)
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (
            player != null
            && Vector2.Distance(transform.position, player.transform.position) > 50.0f
        )
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyController enemy = other.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.Fix();
        }
        Destroy(gameObject);
    }
}
