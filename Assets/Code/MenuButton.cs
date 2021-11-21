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
                ChooseGameMode.crossSceneInformation = GameModeManager.GameMode.first5000;
                SceneManager.LoadScene("InGame");
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
