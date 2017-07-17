using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldCell : MonoBehaviour {
    [SerializeField] private Sprite _cross;
    [SerializeField] private Sprite _circle;

    private int _placeX, _placeY;
    public int PlaceX {
        get {
            return _placeX;
        }
        set {
            _placeX = value;
        }
    }
    public int PlaceY {
        get {
            return _placeY;
        }
        set {
            _placeY = value;
        }
    }

    public int currentState = 0; //TODO enum 
    public int index; //TODO private only with get
    private void OnMouseDown() {
        

    }

    public void SetCircle() {
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        spriteRenderer.sprite = _circle;

    }

    public void SetCross() {
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = _cross;

    }
}

