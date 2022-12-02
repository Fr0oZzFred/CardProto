using UnityEngine;

public abstract class Effect_SO : ScriptableObject
{
    public EEffectOrder order = EEffectOrder.BeginTurn;

    public Sprite icon = null;

    public abstract void Tick(Entity owner, int nb);
}