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
    [SerializeField] private LeftRight side;

    public int score { get; private set; }
    private PlayerCrosshair player;
    private bool used => player != null;
    public LeftRight originSide => side;


    private void Start() {
        Instantiate(weaponSound);
    }

    private void Update() {
        textMesh.text = player ? score.ToString() : "??????";
    }

    public Weapon useBy(PlayerCrosshair player) {
        if (player == null) return null;
        this.player = player;
        return this;
    }

    public static Weapon grabFree() {
        return FindObjectsOfType<Weapon>().OrderBy(x => x.order).First(x => !x.used);
    }

    public void addScore(int addition) {
        score += addition;
    }
}
