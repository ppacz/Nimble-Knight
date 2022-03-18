using UnityEngine;

[CreateAssetMenu(menuName ="Pickups/Heal")]
public class Heal : PowerUp
{
    public int amount;
    public override void Apply(GameObject Target)
    {
        Target.GetComponent<PlayerHP>().Heal(amount) ;
    }
}
