using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] [ReadOnly] private int _currentLevel;

    public int CurrentLevel { get => _currentLevel; }

    private void Awake()
    {
        _currentLevel = 0;
    }
}
