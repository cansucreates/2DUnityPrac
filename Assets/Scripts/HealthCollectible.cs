using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public int healthAmount;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null && controller.health < controller.maxHealth)
        {
            controller.ChangeHealth(healthAmount);
            Destroy(gameObject);
        }
    }
}
