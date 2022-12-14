using UnityEngine;

[CreateAssetMenu(fileName = "New Invincible", menuName = "Effects/Invincible")]
public class Invincible : Effect_SO
{
    public GameObject fx = null;

    public override void Tick(Entity owner, int nb)
    {
        owner.SetInvincible(nb > 1);

        if (!owner.IsDead)
        {
            owner.RemoveStackFromEffect(this, 1);
            Instantiate(fx, owner.transform.position, Quaternion.identity);
        }
    }
}