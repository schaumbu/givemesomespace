using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class GameModeManager : MonoBehaviour {
    public GameMode mode;
    private PlayerCrosshair[] players => FindObjectsOfType<PlayerCrosshair>();
    private int maxScore => players.Select(x => x.score).Append(int.MinValue).Max();
    private PlayerCrosshair leading => players.OrderByDescending(x => x.score).First();

    public enum GameMode {
        countdown,
        first1000,
        first5000,
        first10000
    }

    void Start() {
        mode = ChooseGameMode.crossSceneInformation;
        StartCoroutine(mode == GameMode.countdown ? modeCountdownRoutine() : modeScoreRoutine());
    }

    IEnumerator modeCountdownRoutine() {
        yield return new WaitForSeconds(60);
    }

    IEnumerator modeScoreRoutine() {
        switch (mode) {
            case GameMode.first1000:
                yield return new WaitUntil(() => maxScore >= 1000);
                Debug.Log($"Spieler {leading.weapon.side} hat gewonnen");
                break;

            case GameMode.first5000:
                yield return new WaitUntil(() => maxScore >= 5000);
                Debug.Log($"Spieler {leading.weapon.side} hat gewonnen");
                break;

            case GameMode.first10000:
                yield return new WaitUntil(() => maxScore >= 10000);
                Debug.Log($"Spieler {leading.weapon.side} hat gewonnen");
                break;
        }
    }
}
