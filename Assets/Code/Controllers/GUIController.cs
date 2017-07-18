using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIController : MonoBehaviour {

    [SerializeField] private GameObject _panel;
    [SerializeField] private Text _textPanel;




    public void ClosePanel() {
        _panel.SetActive(false);    
        ActiveGameController.TurnOnGame();
    }

    public void OpenPanel() {
        _panel.SetActive(true);
        ActiveGameController.TurnOffGame();
    }

    public void OpenRestartTextPanel() {
        _textPanel.text = "Do you want to restart?";
        _panel.SetActive(true);
        ActiveGameController.TurnOffGame();
    }



    public void Restart() {
        
        SceneManager.LoadScene(0);
    }

    public void SetTextPanel(string input) {
        if (ActiveGameController.IsSomeoneWonOrDraw) {
            _textPanel.text = input;
            OpenPanel();
        }

    }


}
