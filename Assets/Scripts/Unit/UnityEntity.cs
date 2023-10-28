using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityEntity : MonoBehaviour, IHaveHealth
{
    [SerializeField] [ReadOnly] private FactionSide _factionSide;

    [SerializeField] [ReadOnly] private int _currentHealth;
    [SerializeField] private int _maxHealth;

    public FactionSide Side { get => _factionSide; }
    
    public int CurrentHealth => _currentHealth;

    public int MaxHealth => _maxHealth;

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
        _maxHealth = _currentHealth;
    }

    public void AddHealth(int addedHealth)
    {
        _currentHealth += addedHealth;
        
        if (_currentHealth <= 0 )
        {
            gameObject.SetActive(false);
        }
    }

    public void AddHealth(float addedHealth)
    {
        throw new System.NotImplementedException();
    }
}
