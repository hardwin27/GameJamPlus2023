using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityEntity : MonoBehaviour, IHaveHealth
{
    [SerializeField] private string _unitName;

    [SerializeField] [ReadOnly] private FactionSide _factionSide;

    [SerializeField] [ReadOnly] private int _currentHealth;
    [SerializeField] private int _maxHealth;

    public string UnitName { get => _unitName; }

    public delegate void UnitEntityEvent(GameObject gameObject);
    public event UnitEntityEvent Died;

    public FactionSide Side { get => _factionSide; }
    
    public int CurrentHealth => _currentHealth;

    public int MaxHealth => _maxHealth;

    public bool IsAlive => CurrentHealth > 0;

    public GameObject Owner => gameObject;

    public void Start()
    {
        InitializeHealth();
    }

    public void SetFaction(FactionSide factionSide)
    {
        _factionSide = factionSide;
    }

    private void InitializeHealth()
    {
        _currentHealth = _maxHealth;
    }

    public void AddHealth(int addedHealth)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + addedHealth, 0, MaxHealth);
        
        if (!IsAlive )
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
        Died?.Invoke(gameObject);
    }
}
