using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGameController : MonoBehaviour {
    private static bool _isGameActive;
    private static bool _isSomeoneWonOrDraw;

    public static bool IsSomeoneWonOrDraw {
        get { return _isSomeoneWonOrDraw; }
    }

    public static bool IsGameActive {
        get { return _isGameActive; }
    }


    public static void SomeoneWonOrDraw() {
        _isSomeoneWonOrDraw = true;
    }

    public static void TurnOnGame() {
        if (!_isSomeoneWonOrDraw) {
            _isGameActive = true;
        }
    }

    public static void TurnOffGame() {
        _isGameActive = false;
    }


    // Use this for initialization
    void Start () {
        _isSomeoneWonOrDraw = false;
        _isGameActive = true;
    }
}
