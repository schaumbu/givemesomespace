using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeManager : MonoBehaviour {
    public GameMode mode;
    private PlayerCrosshair[] players => FindObjectsOfType<PlayerCrosshair>();
    private int maxScore => players.Select(x => x.score).Append(int.MinValue).Max();
    private PlayerCrosshair leading => players.OrderByDescending(x => x.score).First();

    public enum GameMode {
        first1000,
        first5000,
        first10000
    }

    void Start() {
        mode = ChooseGameMode.crossSceneInformation;
        StartCoroutine(modeScoreRoutine());
    }

    IEnumerator modeCountdownRoutine() {
        yield return new WaitForSeconds(60);
    }

    IEnumerator modeScoreRoutine() {
        switch (mode) {
            case GameMode.first1000:
                yield return new WaitUntil(() => maxScore >= 1000);
                ChooseVictor.crossSceneInformation = leading.side;
                SceneManager.LoadScene("GameOver");
                break;

            case GameMode.first5000:
                yield return new WaitUntil(() => maxScore >= 5000);
                ChooseVictor.crossSceneInformation = leading.side;
                SceneManager.LoadScene("GameOver");
                break;

            case GameMode.first10000:
                yield return new WaitUntil(() => maxScore >= 10000);
                ChooseVictor.crossSceneInformation = leading.side;
                SceneManager.LoadScene("GameOver");
                break;
        }
    }
}
