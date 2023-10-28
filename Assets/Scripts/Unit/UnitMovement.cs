using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    public void MoveToPos(Vector3 pos)
    {
        transform.position = pos;
    }
}
