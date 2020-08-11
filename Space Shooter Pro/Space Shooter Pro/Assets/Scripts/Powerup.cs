using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Powerup : MonoBehaviour
{   
    [SerializeField]
    private float _speed = 3f;
    // Start is called before the first frame update
    //ID for powerups
    //0 = triple shot
    //1 = speed
    //2 = shield
    [SerializeField]
    private int powerupID;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        //Move down at a speed of 3
        //When we leave the screen, destroy this object
        if (transform.position.y < -4.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //Handle to component I want, then assign the handle to the component
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                switch (powerupID)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        player.ShieldActive();
                        break;
                    default:
                        Debug.Log("Default Value");
                        break;
                }

            }
            Destroy(this.gameObject);
        }
    }
    //OntriggerCollision
    //Only collectable by player
}
