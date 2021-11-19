using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    private int enemyCount => FindObjectsOfType<Enemy>().Length;
    public EnemyType[] enemyTypes;
    public struct EnemyType {
        public GameObject enemy;
        public float probability;
    }

    void Start() {
        StartCoroutine(spawnRoutine());
    }

    IEnumerator spawnRoutine() {
        while (true) {
            yield return new WaitUntil(() => enemyCount <= 4);
            yield return new WaitForSeconds(2);
            spawnEnemy();
        }
    }

    void spawnEnemy() {
        var rangeMax = enemyTypes.Sum(enemyType => enemyType.probability);
        var diceRoll = Random.Range(0, rangeMax);

        var partialSum = 0f;
        foreach (var type in enemyTypes) {
            if (partialSum <= diceRoll && diceRoll < partialSum + type.probability) {
                spawnType(type);
            }

            partialSum += type.probability;
        }
    }

    void spawnType(EnemyType enemyType) {
        Instantiate(enemyType.enemy);
    }
}
