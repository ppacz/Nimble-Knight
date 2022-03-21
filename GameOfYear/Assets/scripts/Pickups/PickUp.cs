using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private PowerUp PowerUpEffect;

    //triggers collection on collision with player and than is used even if player didnt use full potential of the buff
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PowerUpEffect.Apply(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
