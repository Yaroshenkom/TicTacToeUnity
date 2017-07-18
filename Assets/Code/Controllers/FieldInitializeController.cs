using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldInitializeController : MonoBehaviour {
    [SerializeField] private FieldCell _fieldCells;
    [SerializeField] private GameObject field;

    public float startX = -2.575f;
    public float startY = 2.575f;

    private void Start() {

        for (int i = 0; i < 3; i++) {

            for (int j = 0; j < 3; j++) {

                FieldCell fieldCell = Instantiate(_fieldCells, this.field.transform);
                var curPos = fieldCell.transform.position;
                curPos.x = startX + j * 2.575f;
                curPos.y = startY - i * 2.575f;
                curPos.z = 9; //Field has z = 10

                fieldCell.transform.position = curPos;
                fieldCell.PlaceX = i;
                fieldCell.PlaceY = j;
                
    
            }
        }

        TurnAndWinController.InitiateArray();
    }
}
