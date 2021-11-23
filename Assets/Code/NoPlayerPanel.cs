using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NoPlayerPanel : MonoBehaviour {
    private static IEnumerable<PlayerCrosshair> players => FindObjectsOfType<PlayerCrosshair>();

    private void Update() {
        if (players.Any()) Destroy(gameObject);
    }
}
