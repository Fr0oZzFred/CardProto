using UnityEngine;

[CreateAssetMenu(fileName = "New heal", menuName = "Effects/Heal")]
public class Effect_Heal : CardEffect_SO
{
    public override bool DoEffect(Entity sender, Entity target, int[] values, GameObject fx)
    {
        if(values.Length != 1 || sender == null || fx == null) 
            return false;

        Instantiate(fx, sender.transform.position, Quaternion.identity);

        sender.Heal(values[0]);
        return true;
    }
}