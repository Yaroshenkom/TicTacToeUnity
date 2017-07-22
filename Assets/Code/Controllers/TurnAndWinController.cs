﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAndWinController : MonoBehaviour {

    private static int[,] _currentFieldState = new int[3, 3];
    private static Symbol _currentSymbol;
    private static FieldCell _currentCell;
    private static int _turnCount;
    private static GUIController _guiController;

    public static Symbol CurrentSymbol {
        get { return _currentSymbol; }
    }

    public enum Symbol {   
        Cross = 1,
        Circle
    }


    public static void Initiate() {
        _turnCount = 0;
        _currentSymbol = Symbol.Cross;
        InitiateArray();
        _guiController = GameObject.Find("GUI Controller").GetComponent<GUIController>();
        TurnController.CurrentPlayer = TurnController.Player.First;
    }


    private static void InitiateArray() {

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
    public static void SetFieldAndDraw(FieldCell cell, TurnController.Player player) {

        if (!ActiveGameController.IsGameActive) return;
        if (player == TurnController.CurrentPlayer) {
            _currentCell = cell;
            FillIndexArray();
            DrawSymbolOnCell();

            _turnCount++;

            CheckVictoryConditions();
            SwitchSymbol();
            TurnController.SwitchPlayer();
        }
    }

    

    private static void FillIndexArray() {

        if (_currentSymbol == Symbol.Cross) {
            _currentFieldState[_currentCell.PlaceX, _currentCell.PlaceY] = 1;
        }
        else {
            _currentFieldState[_currentCell.PlaceX, _currentCell.PlaceY] = 2;
        }
    }

    private static void DrawSymbolOnCell() {
        if (_currentSymbol == Symbol.Cross) {
            _currentCell.SetCross();
        }
        else {
            _currentCell.SetCircle();
        }
    }

    private static void CheckVictoryConditions() {

        int checkValue;

        if (_currentSymbol == Symbol.Cross)
            checkValue = 1;
        else
            checkValue = 2;

        #region CheckConditions

        
       
        for (int i = 0 ; i < 3; i++) {
            //horizontal
            if (_currentFieldState[i, 0] == checkValue &&
                _currentFieldState[i, 1] == checkValue &&
                _currentFieldState[i, 2] == checkValue) {
                    PlayerWonAnnouncement();
                    return;
            }
            //vertical
            if (_currentFieldState[0, i] == checkValue &&
                _currentFieldState[1, i] == checkValue &&
                _currentFieldState[2, i] == checkValue) {
                     PlayerWonAnnouncement();
                     return;
            }  
        }

            if(_currentFieldState[0,0] == checkValue                        ///   * 0 0
                && _currentFieldState[1, 1] == checkValue                   ///   0 * 0
                && _currentFieldState[2,2] == checkValue){                  ///   0 0 *
                    PlayerWonAnnouncement();
                    return;
                }

            if (_currentFieldState[0, 2] == checkValue                     ///    0 0 *
                && _currentFieldState[1,1] == checkValue                   ///    0 * 0
                && _currentFieldState[2,0] == checkValue){                ///    * 0 0
                    PlayerWonAnnouncement();
                    return;
                }

        if (_turnCount == 9) {
            ActiveGameController.SomeoneWonOrDraw();
            _guiController.SetTextPanel("Draw. Do you want to restart?");
        }
        #endregion



    }

    private  static void PlayerWonAnnouncement() {
        ActiveGameController.SomeoneWonOrDraw();

        if (_currentSymbol == Symbol.Cross) 
            _guiController.SetTextPanel("Player 1 won!!! Do you want to restart?");
        else _guiController.SetTextPanel("Player 2 won!!! Do you want to restart?");

        
    }

    private static void SwitchSymbol() {
        if (_currentSymbol == Symbol.Cross)
            _currentSymbol = Symbol.Circle;
        else
            _currentSymbol = Symbol.Cross;
    }

    


}
