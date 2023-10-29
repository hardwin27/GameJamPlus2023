using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitVisual : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _unitSpriteRenderer;

    public Sprite UnitSprite 
    { get
        {
            if (_unitSpriteRenderer == null)
            {
                return null;
            }
            else
            {
                return _unitSpriteRenderer.sprite;
            }
        }
    }
}
