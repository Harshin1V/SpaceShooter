using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _EnemyPrefab;
    [SerializeField] private GameObject _enemyContainer;
    [SerializeField] private GameObject[] _Powerups;

    [SerializeField] private bool _stopspawning = false;


    public void StartSpawn()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while(_stopspawning == false)
        {
            yield return new WaitForSeconds(2.0f);
            Vector3 position = new Vector3(Random.Range(-5.0f, 5.0f), 4.2f, 0);
            GameObject newenemy = Instantiate(_EnemyPrefab,position, Quaternion.identity );
            newenemy.transform.parent = _enemyContainer.transform;

            yield return new WaitForSeconds(5.0f);
        }
       
    }

    IEnumerator SpawnPowerupRoutine()
    {
        while (_stopspawning == false)
        {
            yield return new WaitForSeconds(2.0f);
            Vector3 position = new Vector3(Random.Range(-5.0f, 5.0f), 4.2f, 0);
            int PowerupR = Random.Range(0, 3);
            Instantiate(_Powerups[PowerupR], position, Quaternion.identity);

            float t = Random.Range(2.0f, 6.0f);
            yield return new WaitForSeconds(t);
        }
            
    }

    public void onPlayerDeath()
    {
        _stopspawning = true;
    }
}


