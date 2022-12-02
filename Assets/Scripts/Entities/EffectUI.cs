using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EffectUI : MonoBehaviour
{
    [SerializeField]
    private Image _icon = null;

    [SerializeField]
    private TextMeshProUGUI _stacks = null;

    public void Init(Effect_SO effect, int nb)
    {
        _icon.sprite = effect.icon;
        UpdateStacks(nb);
    }

    public void UpdateStacks(int nb)
    {
        _stacks.text = nb.ToString();
    }
}