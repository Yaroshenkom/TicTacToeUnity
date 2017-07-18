using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TurnAndWinController {

    private static int[,] _currentFieldState = new int[3, 3];
    private static Player _currentPlayer = Player.First;
    private static FieldCell _currentCell;
    private static int _turnCount = 0;
    private enum Player {   
        First = 1,
        Second
    }

    public static void InitiateArray() {

        for (int i = 0; i < 3; i++) {

            for (int j = 0; j < 3; j++) {

                _currentFieldState[i, j] = 0;

            }
        }

    }
    /// <summary>
    /// 1.Fill array with indexes recieved field cell
    /// 2.Draw symbol depends on current player
    /// 3.Check victory conditions
    /// </summary>
    /// <param name="cell"></param>
    public static void SetFieldAndDraw(FieldCell cell) {
        _currentCell = cell;
        FillIndexArray();
        DrawSymbolOnCell();

        _turnCount++;

        CheckVictoryConditions();
        SwitchPlayer();

    }

    

    private static void FillIndexArray() {

        if (_currentPlayer == Player.First) {
            _currentFieldState[_currentCell.PlaceX, _currentCell.PlaceY] = 1;
        }
        else {
            _currentFieldState[_currentCell.PlaceX, _currentCell.PlaceY] = 2;
        }
    }

    private static void DrawSymbolOnCell() {
        if (_currentPlayer == Player.First) {
            _currentCell.SetCross();
        }
        else {
            _currentCell.SetCircle();
        }
    }

    private static void CheckVictoryConditions() {

        int checkValue;

        if (_currentPlayer == Player.First)
            checkValue = 1;
        else
            checkValue = 2;
        //horizontal
        for (int i = 0, j=0 ; i < 3; i++) {
            if (_currentFieldState[i, j] == checkValue &&
                _currentFieldState[i, j + 1] == checkValue &&
                _currentFieldState[i, j + 2] == checkValue) {
                    PlayerWonAnnouncement();
            }

            if(_currentFieldState[j,j] == checkValue                        ///   * 0 0
                && _currentFieldState[j+1, j+1] == checkValue               ///   0 * 0
                && _currentFieldState[j+2,j+2] == checkValue){              ///   0 0 *
                    PlayerWonAnnouncement();
                }

            if (_currentFieldState[j, 2-j] == checkValue                ///    0 0 *
                && _currentFieldState[j,j] == checkValue                ///    0 * 0
                && _currentFieldState[2-j, j] == checkValue){           ///    * 0 0
                    PlayerWonAnnouncement();
                }

            if (_currentFieldState[j, i] == checkValue &&
                _currentFieldState[j + 1, i] == checkValue &&
                _currentFieldState[j + 2, i] == checkValue) {
                     PlayerWonAnnouncement();
            }
        }

        if (_turnCount == 9) {
            Debug.Log("Draw");
        }


    }

    private  static void PlayerWonAnnouncement() {
        if (_currentPlayer == Player.First)
            Debug.Log("Player 1 win!!!");
        else Debug.Log("Player 2 win !!!");
    }

    private static void SwitchPlayer() {
        if (_currentPlayer == Player.First)
            _currentPlayer = Player.Second;
        else
            _currentPlayer = Player.First;
    }
}
