using UnityEngine;

[CreateAssetMenu(fileName = "New deal damage", menuName = "Card effects/Deal damage")]
public class CardEffect_DealDamageWithStack : CardEffect_SO
{
    public override bool DoEffect(Entity sender, Entity target, int[] values, GameObject fx)
    {
        if (values.Length != 1 || target == null || fx == null) 
            return false;

        Projectile p = Instantiate(fx).GetComponent<Projectile>();
        p.transform.position = sender.ProjectileSpawnPoint.position;
        p.Init(target.transform);

        target.DealDamage(values[0] * (sender.DMGStack + 1));
        sender.ResetDMGStack();
        sender.CheckForDMGStackEffect();

        return true;
    }
}