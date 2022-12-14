using UnityEngine;

[CreateAssetMenu(fileName = "New Regen Shield", menuName = "Effects/Regen Shield")]
public class RegenShieldEffect : Effect_SO
{
    public GameObject fx = null;
    public int shieldPower;

    public override void Tick(Entity owner, int nb)
    {
        owner.AddShield(shieldPower);

        if (!owner.IsDead)
        {
            owner.RemoveStackFromEffect(this, 1);
            Instantiate(fx, owner.transform.position, Quaternion.identity);
        }
    }
}