using UnityEngine;

[CreateAssetMenu(fileName = "New Meditation", menuName = "Effects/Meditation")]
public class MeditationEffect : Effect_SO
{
    public GameObject fx = null;

    public override void Tick(Entity owner, int nb)
    {
        owner.StackDMG(nb);

        if (!owner.IsDead)
        {
            owner.AddStackFromEffect(this, nb);
            Instantiate(fx, owner.transform.position, Quaternion.identity);
        }
    }
}