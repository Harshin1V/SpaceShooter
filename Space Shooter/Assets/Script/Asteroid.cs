using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPrefab;
    SpawnManager _spawnmanager;
    // Start is called before the first frame update
    void Start()
    {
        _spawnmanager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 1);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Laser" )
        {
            Debug.Log("collided");
            Instantiate(_explosionPrefab , transform.position , Quaternion.identity);
            //call spwan manager
            _spawnmanager.StartSpawn();
            Destroy(this.gameObject);
        }
        

    }
}
