using UnityEngine;

public abstract class CardEffect_SO : ScriptableObject
{
    public abstract bool DoEffect(Entity sender, Entity target, int[] values, GameObject fx);
}