using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour {
    public EnemyType[] enemyTypes;
    public float seconds = 1;
    public float randomWait = 1;
    public int maxEnemyCount = 4;
    private static int enemyCount => FindObjectsOfType<Enemy>().Length;

    private void Start() {
        StartCoroutine(spawnRoutine());
    }

    private IEnumerator spawnRoutine() {
        while (true) {
            if (Random.Range(0, 100) == 0) {
                // spawn big wave
                yield return new WaitForSeconds(seconds * 4 + Random.Range(0, randomWait));

                for (var i = 0; i < maxEnemyCount * 2; i++) {
                    yield return new WaitForSeconds(seconds * .2f + Random.Range(0, randomWait * .1f));
                    spawnEnemy();
                }
            }

            yield return new WaitUntil(() => enemyCount < maxEnemyCount);
            yield return new WaitForSeconds(seconds + Random.Range(0, randomWait));
            spawnEnemy();
        }
    }

    private void spawnEnemy() {
        var rangeMax = enemyTypes.Sum(enemyType => enemyType.probability);
        var diceRoll = Random.Range(0, rangeMax);

        var partialSum = 0f;
        foreach (var type in enemyTypes) {
            if (partialSum <= diceRoll && diceRoll < partialSum + type.probability) spawnType(type);

            partialSum += type.probability;
        }
    }

    private static void spawnType(EnemyType enemyType) {
        Instantiate(enemyType.enemy);
    }

    [Serializable]
    public struct EnemyType {
        public GameObject enemy;
        public float probability;
    }
}
