using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int damageAmount;
    void OnTriggerStay2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            controller.ChangeHealth(-damageAmount);
        }
    }

    
}
