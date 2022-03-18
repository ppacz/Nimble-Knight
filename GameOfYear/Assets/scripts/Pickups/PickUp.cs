using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private PowerUp PowerUpEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PowerUpEffect.Apply(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
