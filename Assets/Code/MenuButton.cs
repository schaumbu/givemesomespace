using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public ButtonType buttonType;
    
    public enum ButtonType {
        startGame,
        quitGame,
        openOptions
    }
    
    public void onClick() {

        switch (buttonType) {
            case ButtonType.startGame:
                SceneManager.LoadScene("Janeks Scene");
                break;
            case ButtonType.openOptions:
                SceneManager.LoadScene("");
                break;
            case ButtonType.quitGame:
                Application.Quit();
                break;
        }
        
    }
}
