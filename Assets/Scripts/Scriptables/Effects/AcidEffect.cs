using UnityEngine;

[CreateAssetMenu(fileName = "New acid", menuName = "Effects/Acid")]
public class AcidEffect : Effect_SO
{
    public GameObject fx = null;

    public override void Tick(Entity owner, int nb)
    {
        owner.DealDamage(nb);

        if (!owner.IsDead)
        {
            owner.RemoveStackFromEffect(this, 1);
            Instantiate(fx, owner.transform.position, Quaternion.identity);
        }
    }
}