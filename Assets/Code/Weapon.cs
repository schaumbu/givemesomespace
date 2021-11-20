using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public Color color = Color.white;
    public TMPro.TextMeshPro textMesh;
    public bool used => player != null;
    public Transform origin;
    public Transform soulTarget;
    public int order;
    private PlayerCrosshair player = null;

    private void Update() {
        if (player) {
            textMesh.text = player.score.ToString();
        }
        else {
            textMesh.text = "??????";
        }
    }

    public void useBy(PlayerCrosshair p) {
        player = p;
    }
}
