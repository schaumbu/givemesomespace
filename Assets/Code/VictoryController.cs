using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryController : MonoBehaviour {
    public GameObject winnerLeft;
    public GameObject winnerRight;

    void Start() {
        if (ChooseVictor.crossSceneInformation == PlayerCrosshair.LeftRight.left)
            Instantiate(winnerLeft);
        else
            Instantiate(winnerRight);
    }
}
