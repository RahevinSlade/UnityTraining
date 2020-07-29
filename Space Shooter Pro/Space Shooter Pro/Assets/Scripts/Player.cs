using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    //Public or private reference
    //Data type: ints, floats, bool, string
    //Every variable has a name
    //optional, value assigned
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.15f;

    private float _canFire = -1f;


    // Start is called before the first frame update
    void Start()
    {
        //Take the current position and assign it a start postion (0,0,0)
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        //When I hit space key, spawn object
        if(Input.GetKeyDown(KeyCode.Space) && Time.time >= _canFire)
        {
            FireLaser();
        }
    }

    void FireLaser()
    {
            _canFire = _fireRate + Time.time;
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime); //DeltaTime is real time movement (Side to side)
        //transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime); // (Up and Down)
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);//cleaned up with local variable

        transform.Translate(direction * _speed * Time.deltaTime); // Optimized 

        //If player postion on the Y is greater than 0, then, y postion = 0
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);

        //If player on the x > 11 then x pos = -11 else if player on x is less than -11 then x pos = 11
        if(transform.position.x >= 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);

        }
    }
}
