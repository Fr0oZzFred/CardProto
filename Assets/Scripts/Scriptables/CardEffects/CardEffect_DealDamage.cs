using UnityEngine;

[CreateAssetMenu(fileName = "New deal damage with Stack", menuName = "Card effects/Deal damage with Stack")]
public class CardEffect_DealDamage : CardEffect_SO
{
    public override bool DoEffect(Entity sender, Entity target, int[] values, GameObject fx)
    {
        if (values.Length != 1 || target == null || fx == null) 
            return false;

        Projectile p = Instantiate(fx).GetComponent<Projectile>();
        p.transform.position = sender.ProjectileSpawnPoint.position;
        p.Init(target.transform);

        target.DealDamage(values[0]);

        return true;
    }
}