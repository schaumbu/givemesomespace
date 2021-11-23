using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Code;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeManager : MonoBehaviour {
    public enum GameMode {
        first1000,
        first5000,
        first10000
    }

    [SerializeField] private GameMode mode;
    private static IEnumerable<PlayerCrosshair> players => FindObjectsOfType<PlayerCrosshair>();
    private static int maxScore => players.Select(x => x.weapon.score).Append(int.MinValue).Max();
    private static PlayerCrosshair leading => players.OrderByDescending(x => x.weapon.score).First();

    private void Start() {
        mode = Persistent.gameMode;
        StartCoroutine(modeScoreRoutine());
    }

    private IEnumerator modeScoreRoutine() {
        yield return new WaitUntil(() => maxScore >= gameModePoints(mode));
        Persistent.winner = leading.side;
        SceneManager.LoadScene("GameOver");
    }

    private static int gameModePoints(GameMode mode) {
        return mode switch {
            GameMode.first1000 => 1000,
            GameMode.first5000 => 5000,
            GameMode.first10000 => 10000,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
