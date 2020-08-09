using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 8f;
    //Speed variable of 8

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Translate laser up
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        //Check if postion on y is greater than 8, destroy object

        if(transform.position.y >= 8f)
        {
            //Check if this object has a parent.
            //destory the parent too.
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject); //AKA Triple Shot
            }
            Destroy(this.gameObject);
        }
    }
}
