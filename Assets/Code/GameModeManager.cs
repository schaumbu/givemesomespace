using System.Collections;
using UnityEngine;

public class GameModeManager : MonoBehaviour {
    
    public GameMode mode;
    
    public enum GameMode {
        countdown,
        first1000,
        first5000,
        first10000
    }

    public PlayerCrosshair[] players;

    void Start() {
        mode = ChooseGameMode.crossSceneInformation;
        StartCoroutine(mode == GameMode.countdown ? modeCountdownRoutine() : modeScoreRoutine());
    }

    IEnumerator modeCountdownRoutine() {
        yield return new WaitForSeconds(60);
    }

    IEnumerator modeScoreRoutine() {
        players = FindObjectsOfType<PlayerCrosshair>();
        while (players.Length < 2) {
            players = FindObjectsOfType<PlayerCrosshair>();
        }

        switch (mode) {
            case GameMode.first1000:
                yield return new WaitUntil(() => players[0].score >= 1000 || players[1].score >= 1000);
                Debug.Log("WINNER!");
                break;
            case GameMode.first5000:
                yield return new WaitUntil(() => players[0].score >= 5000 || players[1].score >= 5000);
                if(players[0].score > players[1].score)
                    Debug.Log("Spieler 1 gewinnt!");
                else 
                    Debug.Log("Spieler 2 gewinnt!");
                break;
            case GameMode.first10000:
                yield return new WaitUntil(() => players[0].score >= 10000 || players[1].score >= 10000);
                break;
        }
    }


}
