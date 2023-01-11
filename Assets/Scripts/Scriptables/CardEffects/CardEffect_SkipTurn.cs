using UnityEngine;

[CreateAssetMenu(fileName = "New Skip turn", menuName = "Card effects/Skip turn")]
public class CardEffect_SkipTurn : CardEffect_SO
{
    public override bool DoEffect(Entity sender, Entity target, int[] values, GameObject fx)
    {
        if (values.Length != 1 || target == null || fx == null) 
            return false;


        Instantiate(fx, target.transform.position, Quaternion.identity);

        target.SetSkipTurn(true);

        return true;
    }
}