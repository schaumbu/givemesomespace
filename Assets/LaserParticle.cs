using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserParticle : MonoBehaviour {
    public float after = .1f;

    void Start() {
        Destroy(gameObject, after);
    }
}
