using System;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public Color color = Color.white;
    public TextMeshPro textMesh;
    public bool used => player != null;
    public Transform origin;
    public Transform soulTarget;
    public int order;
    public GameObject weaponSound;

    public enum LeftRight {
        left,
        right
    };

    public LeftRight side;
    private PlayerCrosshair player;
    

    private void Start() {
        Instantiate(weaponSound);
    }

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
