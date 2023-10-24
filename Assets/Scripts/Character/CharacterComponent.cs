using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponent : MonoBehaviour
{
    [SerializeField] private CharacterMovement _characterMovement;

    public CharacterMovement CharacterMovement { get => _characterMovement; }
}
