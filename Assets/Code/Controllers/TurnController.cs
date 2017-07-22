using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour {
    
    public enum Player {
        First,              //Usually crosses
        Second              //Usually circles
    }
    private static Player _currentPlayer;

    public static Player CurrentPlayer {
        get {
            return _currentPlayer;
        }
        set {
            _currentPlayer = value;
        }
    }

    

    public static void SwitchPlayer() {
        Debug.Log(_currentPlayer);
        if (_currentPlayer == Player.First) {
            _currentPlayer = Player.Second;
        } else {
            _currentPlayer = Player.First;
        }
        Debug.Log("Switched to " + _currentPlayer);
    }

}
