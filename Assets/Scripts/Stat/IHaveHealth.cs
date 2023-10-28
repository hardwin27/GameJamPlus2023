using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHaveHealth
{
    public int CurrentHealth { get; }
    public int MaxHealth { get; }

    public void AddHealth(int addedHealth);
}
