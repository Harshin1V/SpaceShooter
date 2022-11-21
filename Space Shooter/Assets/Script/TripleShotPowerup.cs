using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShotPowerup : MonoBehaviour
{
    [SerializeField] private int powerupID;

    [SerializeField] private AudioClip _clip;

    //0 TripleShot
    //1 speedPowerup
    //2 sheildpowerup

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 3 );

        if(transform.position.y <-5)
        {
            Destroy(this.gameObject);
        }
        
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player" )
        {
            Player player = collision.transform.GetComponent<Player>();
            AudioSource.PlayClipAtPoint(_clip , transform.position);
            Destroy(this.gameObject);
            
            switch(powerupID)
            {
                case 0: player.TripleShotActive(); break;
                case 1: player.IncreaseSpeed(); break;
                case 2: player.ShieldActivate(); break;

            }

        }
        
    }

}