using System;
using Code;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour {
    [SerializeField] private ButtonType buttonType;

    private enum ButtonType {
        startGame,
        quitGame,
        openMain,
        first1000,
        first5000,
        first10000
    }

    public void onClick() {
        switch (buttonType) {
            case ButtonType.startGame:
                SceneManager.LoadScene("ModeMenu");
                break;
            case ButtonType.openMain:
                SceneManager.LoadScene("Menu");
                break;
            case ButtonType.quitGame:
                Application.Quit();
                break;
            case ButtonType.first1000:
                loadInGame(GameModeManager.GameMode.first1000);
                break;
            case ButtonType.first5000:
                loadInGame(GameModeManager.GameMode.first5000);
                break;
            case ButtonType.first10000:
                loadInGame(GameModeManager.GameMode.first10000);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private static void loadInGame(GameModeManager.GameMode mode) {
        Persistent.gameMode = mode;
        SceneManager.LoadScene("InGame");
    }
}
