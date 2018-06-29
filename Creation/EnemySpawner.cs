using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public int numberOfEnemies;

    public void OnStartSpawn(){
        for (int i=0; i < numberOfEnemies; i++){
            var spawnPosition = new Vector3(
                Random.Range(-1.0f, 1.0f),
                Random.Range(-1.0f, 1.0f),
                0.0f);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}