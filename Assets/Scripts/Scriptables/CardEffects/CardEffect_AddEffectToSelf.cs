using UnityEngine;

[CreateAssetMenu(fileName = "New add effect to self", menuName = "Card effects/Add effect to Self")]
public class CardEffect_AddEffectToSelf : CardEffect_SO
{
    public Effect_SO effect = null;

    public override bool DoEffect(Entity sender, Entity target, int[] values, GameObject fx)
    {
        if (values.Length != 1 || sender == null || fx == null)
            return false;

        sender.AddEffect(effect, values[0]); 
        Instantiate(fx, sender.transform.position, Quaternion.identity);
        
        return true;
    }
}