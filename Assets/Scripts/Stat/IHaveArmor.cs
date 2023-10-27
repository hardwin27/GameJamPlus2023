using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHaveArmor
{
    public int Armor { set; get; }

    public void AddArmor(int addedArmor);
}
