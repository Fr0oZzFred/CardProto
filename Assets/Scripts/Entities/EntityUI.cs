using TMPro;
using UnityEngine;

public class EntityUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _health = null;    
    
    [SerializeField]
    private TextMeshProUGUI _shield = null;    
    
    [SerializeField]
    private TextMeshProUGUI _energy = null;

    private int _currentHealth = 0;
    private int _currentShield = 0;
    private int _currentEnergy = 0;

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
}