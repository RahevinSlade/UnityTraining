using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;

    private Player _player;
    //Handle to animator component
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        if(_player == null)
        {
            Debug.LogError("Where the player go?");
        }
        //Asign the anim
        _anim = GetComponent<Animator>();
        if (_anim == null)
        {
            Debug.LogError("Enemy Animator is Null");
        }
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
            //Player player = other.transform.GetComponent<Player>();//Calls method from Player script
            if (_player != null)
            {
                _player.Damge();
            }
            //Trigger anim
            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;
            Destroy(this.gameObject, 2.8f);
        }

        //if other is laser -> Destroy laser, then destory us
        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            if(_player != null)
            {
                _player.AddScore(10);
            }
            //Trigger Anim
            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0;
            Destroy(this.gameObject, 2.8f);
        }
    }
}
