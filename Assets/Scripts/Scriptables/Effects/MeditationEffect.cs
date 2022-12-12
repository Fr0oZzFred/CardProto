using UnityEngine;

[CreateAssetMenu(fileName = "New Meditation", menuName = "Effects/Meditation")]
public class MeditationEffect : Effect_SO
{
    public GameObject fx = null;
    public int maxStack;

    public override void Tick(Entity owner, int nb)
    {
        owner.StackDMG(nb);
        if(owner.DMGStack > maxStack && !(owner is Enemy)) {
            owner.DealDamage(owner.DMGStack);
        }

        if (!owner.IsDead)
        {
            owner.AddStackFromEffect(this, nb);
            Instantiate(fx, owner.transform.position, Quaternion.identity);
        }
    }
}