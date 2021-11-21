using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public ButtonType buttonType;
    
    public enum ButtonType {
        startGame,
        quitGame,
        openOptions,
        countdown,
        first1000,
        first5000,
        first10000
    }
    
    public void onClick() {

        switch (buttonType) {
            case ButtonType.startGame:
                ChooseGameMode.crossSceneInformation = GameModeManager.GameMode.first1000;
                SceneManager.LoadScene("ModeMenu");
                break;
            case ButtonType.openOptions:
                SceneManager.LoadScene("");
                break;
            case ButtonType.quitGame:
                Application.Quit();
                break;
            case ButtonType.countdown:
                ChooseGameMode.crossSceneInformation = GameModeManager.GameMode.countdown;
                SceneManager.LoadScene("InGame");
                break;
            case ButtonType.first1000:
                ChooseGameMode.crossSceneInformation = GameModeManager.GameMode.first1000;
                SceneManager.LoadScene("InGame");
                break;
            case ButtonType.first5000:
                ChooseGameMode.crossSceneInformation = GameModeManager.GameMode.first5000;
                SceneManager.LoadScene("InGame");
                break;
            case ButtonType.first10000:
                ChooseGameMode.crossSceneInformation = GameModeManager.GameMode.first10000;
                SceneManager.LoadScene("InGame");
                break;
        }
        
    }
}
