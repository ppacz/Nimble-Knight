using UnityEngine;

[CreateAssetMenu(menuName = "Pickups/StaminaGain")]
public class StaminaGain : PowerUp
{
    public float amount;
    public override void Apply(GameObject Target)
    {
        Target.GetComponent<PlayerStamina>().AddStamina(amount);
    }
}
