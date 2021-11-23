using Code;
using UnityEngine;

public class VictoryController : MonoBehaviour {
    [SerializeField] private GameObject winnerLeft;
    [SerializeField] private GameObject winnerRight;

    private void Start() {
        Instantiate(Persistent.winner == LeftRight.left ? winnerLeft : winnerRight);
    }
}
