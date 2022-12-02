using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EntityUI : MonoBehaviour
{
    [SerializeField]
    private EffectUI _effectUIPrefab = null;

    [SerializeField]
    private Transform _effectsParent = null;

    [SerializeField]
    private TextMeshProUGUI _health = null;    
    
    [SerializeField]
    private TextMeshProUGUI _shield = null;    
    
    [SerializeField]
    private TextMeshProUGUI _energy = null;

    private Dictionary<Effect_SO, EffectUI> _effects = null;

    private int _currentHealth = 0;
    private int _currentShield = 0;
    private int _currentEnergy = 0;

    private void Start()
    {
        _effects = new Dictionary<Effect_SO, EffectUI>();
    }

    public void ChangeHealth(int newHealth, int maxHealth)
    {
        _currentHealth = newHealth;
        _health.text = string.Format("{0} / {1}", _currentHealth, maxHealth);
    }

    public void ChangeShield(int newShield)
    {
        _currentShield = newShield;
        _shield.text = _currentShield.ToString();
    }

    public void ChangeEnergy(int newEnergy)
    {
        _currentEnergy = newEnergy;
        _energy.text = _currentEnergy.ToString();
    }

    /// <summary>
    /// Adds an effect to the UI
    /// </summary>
    public void AddEffect(Effect_SO effect, int nb)
    {
        if(!_effects.ContainsKey(effect))
        {
            EffectUI ui = Instantiate(_effectUIPrefab, _effectsParent);
            _effects.Add(effect, ui);
            ui.Init(effect, nb);
        }
    }

    /// <summary>
    /// Removes the effect from the UI
    /// </summary>
    public void RemoveEffect(Effect_SO effect)
    {
        if (_effects.ContainsKey(effect))
        {
            Destroy(_effects[effect].gameObject);
            _effects.Remove(effect);
        }
    }

    /// <summary>
    /// Updates the stack value
    /// </summary>
    public void UpdateEffect(Effect_SO effect, int nb)
    {
        if (_effects.ContainsKey(effect))
        {
            _effects[effect].UpdateStacks(nb);
        }
    }

    //Removes all of the effects
    public void ClearEffects()
    {
        foreach (Effect_SO effect in _effects.Keys)
        {
            Destroy(_effects[effect].gameObject);
        }

        _effects.Clear();
    }
}