using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldCell : MonoBehaviour {
    [SerializeField] private Sprite _cross;
    [SerializeField] private Sprite _circle;



    private int _placeX, _placeY;
    private bool _isUsed;


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
        if (!_isUsed) {
            TurnAndWinController.SetFieldAndDraw(this);
        }

    }

    public void SetCircle() {
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = _circle;
        _isUsed = true;

    }

    public void SetCross() {
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = _cross;
        _isUsed = true;


    }
}

