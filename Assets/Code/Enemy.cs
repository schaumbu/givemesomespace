using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    
    public float scoreValue;
    public void onHit(PlayerCrosshair origin) {
        Destroy(gameObject);        
    }
}
