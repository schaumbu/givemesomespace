using System;
using System.Linq;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour {
    [SerializeField] public Color color = Color.white;
    [SerializeField] private TextMeshPro textMesh;
    [SerializeField] public Transform origin;
    [SerializeField] public Transform soulTarget;
    [SerializeField] private int order;
    [SerializeField] private GameObject weaponSound;
    public bool used => player != null;

    private PlayerCrosshair player;


    private void Start() {
        Instantiate(weaponSound);
    }

    private void Update() {
        textMesh.text = player ? player.score.ToString() : "??????";
    }

    public void useBy(PlayerCrosshair player) {
        this.player = player;
    }

    public static Weapon grabFree() {
        return FindObjectsOfType<Weapon>().OrderBy(x => x.order).First(x => !x.used);
    }
}
