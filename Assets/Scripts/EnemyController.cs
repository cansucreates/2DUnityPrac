using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator animator;
    public float speed = 1.0f;
    Rigidbody2D rb;
    public bool vertical;

    // time to change direction
    public float changeTime = 3.0f;
    float timer;
    int direction = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rb.position;

        if (vertical)
        {
            // animator parameters
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
            // change position
            position.y = position.y + speed * Time.deltaTime * direction;
        }
        else
        {
            // animator parameters
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
            // change position
            position.x = position.x + speed * Time.deltaTime * direction;
        }

        rb.MovePosition(position);
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null) {
            player.ChangeHealth(-1);
        }
    }
}
