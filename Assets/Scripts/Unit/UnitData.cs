using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Data")]
public class UnitData : ScriptableObject
{
    [SerializeField] private string _unitName;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private Sprite _unitSprite;
    [SerializeField] private float _appearanceChance;
    [SerializeField] private float _appearanceChanceIncrease;

    public string UnitName { get => _unitName; }
    public int Health { get => _health; }
    public int Damage { get => _damage; }
    public Sprite UnitSprite { get => _unitSprite; }
    public float AppearanceChance { get => _appearanceChance; }
    public float AppearanceChanceIncrease { get => _appearanceChanceIncrease; }
}
