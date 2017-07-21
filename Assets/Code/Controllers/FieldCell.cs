using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldCell : MonoBehaviour {
    [SerializeField] private Sprite _cross;
    [SerializeField] private Sprite _circle;


    private SpriteRenderer _spriteRenderer;
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


    private void Start() {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnMouseEnter() {
        if (_isUsed) return;
        if (TurnAndWinController.CurrentPlayer == TurnAndWinController.Player.First) {
            SetGhostCross();
        }
        else {
            SetGhostCircle();
        }
    }

    private void OnMouseExit() {
        CleanCurrentSprite();
    }


    private void OnMouseDown() {
        if (_isUsed) return;
        TurnAndWinController.SetFieldAndDraw(this);
    }

    public void SetCircle() {
        _spriteRenderer.sprite = _circle;
        _isUsed = true;
        var curColor = _spriteRenderer.color;
        _spriteRenderer.color = new Color(curColor.r, curColor.g, curColor.b, 1f);
    }

    public void SetCross() {
        _spriteRenderer.sprite = _cross;
        _isUsed = true;
        var curColor = _spriteRenderer.color;
        _spriteRenderer.color = new Color(curColor.r, curColor.g, curColor.b, 1f);

    }


    private void SetGhostCircle() {
        _spriteRenderer.sprite = _circle;
        var curColor = _spriteRenderer.color;
        _spriteRenderer.color = new Color(curColor.r, curColor.g, curColor.b, 0.3f);
    }

    private void SetGhostCross() {
        _spriteRenderer.sprite = _cross;
        var curColor = _spriteRenderer.color;
        _spriteRenderer.color = new Color(curColor.r, curColor.g, curColor.b, 0.3f);

    }

    public void CleanCurrentSprite() {
        if (_isUsed) return;
        _spriteRenderer.sprite = null;
    }

}

