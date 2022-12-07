using UnityEngine;

[CreateAssetMenu(fileName = "New Regen", menuName = "Effects/Regen")]
public class RegenEffect : Effect_SO
{
    public GameObject fx = null;
    public int regenPower;

    public override void Tick(Entity owner, int nb)
    {
        owner.Heal(regenPower);

        if (!owner.IsDead)
        {
            owner.RemoveStackFromEffect(this, 1);
            Instantiate(fx, owner.transform.position, Quaternion.identity);
        }
    }
}