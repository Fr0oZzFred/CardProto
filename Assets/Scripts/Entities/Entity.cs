using System;
using System.Collections;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]
    protected SpriteRenderer _shipSprite = null;

    [SerializeField]
    private GameObject _shieldSprite = null;

    [SerializeField]
    private Transform _projectileSpawnPoint = null;

    [SerializeField]
    private GameObject _explosionFx = null;

    public Action onDeath = null;

    protected EntityUI _ui = null;

    protected int _health = 0;
    protected int _maxHealth = 0;
    protected int _shield = 0;
    protected int _energy = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    /// <summary>
    /// Initialize the entity and it's UI
    /// </summary>
    public virtual void InitEntity(int maxHealth, EntityUI ui)
    {
        _ui = ui;
        _maxHealth = maxHealth;
        _health = maxHealth;
        _shield = 0;
        _energy = 0;

        _ui.ChangeHealth(_health, maxHealth);
        _ui.ChangeShield(_shield);
        _ui.ChangeEnergy(_energy);

        _shieldSprite.SetActive(false);
    }

    #region Health/Shield/Energy
    /// <summary>
    /// Deals damages to the entity
    /// </summary>
    public void DealDamage(int amount)
    {
        if (amount <= 0)
            return;

        _health -= RemoveShield(amount);

        if(_health <= 0)
        {
            _health = 0;
            Die();
        }

        _ui.ChangeHealth(_health, _maxHealth);
    }

    /// <summary>
    /// Heals by the amount, can't go over the max health value
    /// </summary>
    public void Heal(int amount)
    {
        if (amount <= 0)
            return;

        _health += amount;
        _health = Mathf.Min(_health, _maxHealth);
        _ui.ChangeHealth(_health, _maxHealth);
    }

    /// <summary>
    /// Adds shield, no limit
    /// </summary>
    public void AddShield(int amount)
    {
        if (amount <= 0)
            return;

        if (_shield == 0)
            SpawnShield();

        _shield += amount;
        _ui.ChangeShield(_shield);
    }

    /// <summary>
    /// Removes shield, breaks the shield if it goes under 0
    /// Returns the damage amount left if the shield is destroyed
    /// </summary>
    public int RemoveShield(int amount)
    {
        if (amount <= 0 || _shield <= 0)
            return amount;

        int diff = _shield - amount;

        if(diff <= 0)
        {
            _shield = 0;
            BreakShield();
            _ui.ChangeShield(_shield);
            return Mathf.Abs(diff);
        }
        else
        {
            _shield -= amount;
            _ui.ChangeShield(_shield);
            return 0;
        }
    }

    /// <summary>
    /// Adds some energy
    /// </summary>
    public void GiveEnergy(int amount)
    {
        _energy += amount;
    }

    /// <summary>
    /// Try use some energy, returns true if it can be used
    /// </summary>
    public bool UseEnergy(int amount)
    {
        if (_energy < amount)
            return false;

        _energy -= amount;
        _ui.ChangeEnergy(_energy);
        return true;
    }

    /// <summary>
    /// Kills the entity
    /// </summary>
    protected virtual void Die()
    {
        Instantiate(_explosionFx, transform.position, Quaternion.identity);
        _shipSprite.gameObject.SetActive(false);
        _shipSprite.gameObject.SetActive(false);
        onDeath?.Invoke();
        StartCoroutine(DieCorout());
    }

    private IEnumerator DieCorout()
    {
        yield return new WaitForSeconds(2);

        Destroy(gameObject);
    }

    /// <summary>
    /// Set the shield to be visible
    /// </summary>
    private void SpawnShield()
    {
        _shieldSprite.SetActive(true);
    }

    /// <summary>
    /// Animate the breaking of the shield
    /// </summary>
    private void BreakShield()
    {
        _shieldSprite.SetActive(false);
    }
    #endregion

    #region Turn
    /// <summary>
    /// Called before the actual start of the turn
    /// </summary>
    public virtual void BeginTurn()
    {

    }

    /// <summary>
    /// Starts the turn
    /// </summary>
    public virtual void StartTurn()
    {
        _energy += 7;
        _ui.ChangeEnergy(_energy);
    }

    /// <summary>
    /// Ends the turn
    /// </summary>
    public virtual void EndTurn()
    {
        _energy = 0;
        _ui.ChangeEnergy(_energy);
    }
    #endregion

    #region Getters & Setters
    public Transform ProjectileSpawnPoint => _projectileSpawnPoint;
    public Transform ShieldSpriteTransform => _shieldSprite.transform;

    public int Health => _health;
    public int MaxHealth => _maxHealth;
    public int Shield => _shield;
    public int Energy => _energy;
    #endregion
}