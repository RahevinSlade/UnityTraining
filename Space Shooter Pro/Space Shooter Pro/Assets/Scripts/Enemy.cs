using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move down at 4 meters per second
        transform.Translate(Vector3.down * _speed*  Time.deltaTime);
        //if bottom of screen, respawn at top with a new random x position
        if(transform.position.y < -5f)
        {
            float randomX = Random.Range(-8f, 8f);
            transform.position = new Vector3(randomX, 7 , 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Hit: " + other.transform.name);
        //If other is player -> Destroy us, damage the player
        if(other.tag == "Player")
        {
            //damage player
            Player player = other.transform.GetComponent<Player>();//Calls method from Player script
            if (player != null)
            {
                player.Damge();
            }
            Destroy(this.gameObject);
        }

        //if other is laser -> Destroy laser, then destory us
        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
