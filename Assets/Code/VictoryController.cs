using System.Collections;
using System.Collections.Generic;
using Code;
using UnityEngine;

public class VictoryController : MonoBehaviour {
    [SerializeField] private GameObject winnerLeft;
    [SerializeField] private GameObject winnerRight;

    private void Start() {
        Instantiate(Persistent.winner == PlayerCrosshair.LeftRight.left ? winnerLeft : winnerRight);
    }
}
