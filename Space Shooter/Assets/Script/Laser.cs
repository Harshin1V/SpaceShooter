using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int speed = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime *speed );

        if(transform.position.y > 5.5)
        {
            Destroy(gameObject);
            if(transform.parent != null)
            {
                Destroy( transform.parent.gameObject);
            }
           
        }

    }
}
