using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NoPlayerPanel : MonoBehaviour
{
    
    private IEnumerable<PlayerCrosshair> players => FindObjectsOfType<PlayerCrosshair>();
    void Update()
    {
        if (players.Any()) {
            Destroy(gameObject);
        }
    }
}
