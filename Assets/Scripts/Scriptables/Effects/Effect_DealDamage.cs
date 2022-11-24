using UnityEngine;

[CreateAssetMenu(fileName = "New deal damage", menuName = "Effects/Deal damage")]
public class Effect_DealDamage : CardEffect_SO
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