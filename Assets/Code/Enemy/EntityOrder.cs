using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Enemy {
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class EntityOrder : MonoBehaviour {
        [SerializeField] public int order;
        private SpriteRenderer spriteRenderer;

        private void Awake() {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Update() {
            spriteRenderer.sortingOrder = (int) (transform.position.y * 100 + order * 10000);
        }
    }
}
