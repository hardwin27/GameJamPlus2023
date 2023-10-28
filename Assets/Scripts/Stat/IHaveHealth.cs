using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHaveHealth
{
    public GameObject Owner { get; }

    public int CurrentHealth { get; }
    public int MaxHealth { get; }

    public bool IsAlive { get; }

    public void AddHealth(int addedHealth);
}
