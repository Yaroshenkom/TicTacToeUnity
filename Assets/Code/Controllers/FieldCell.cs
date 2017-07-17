using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldCell : MonoBehaviour {
    [SerializeField] private Sprite _cross;
    [SerializeField] private Sprite _circle;


    public int currentState = 0; //TODO enum 

    private void OnMouseDown() {

        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        spriteRenderer.sprite = _cross;

    }
}

