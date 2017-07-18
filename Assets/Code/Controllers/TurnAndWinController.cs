using System.Collections;
using System.Collections.Generic;


public class TurnAndWinController {

    private static int[,] currentFieldState = new int[3, 3];
    private static Player _currentPlayer = Player.First;
    private static FieldCell _currentCell;
    private enum Player {   
        First = 1,
        Second
    }

    public static void InitiateArray() {

        for (int i = 0; i < 3; i++) {

            for (int j = 0; j < 3; j++) {

                currentFieldState[i, j] = 0;

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

    }

    

    private static void FillIndexArray() {

        if (_currentPlayer == Player.First) {
            currentFieldState[_currentCell.PlaceX, _currentCell.PlaceY] = 1;
        }
        else {
            currentFieldState[_currentCell.PlaceX, _currentCell.PlaceY] = 2;
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


}
