using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{

    public float standSpeed = 5f;
    public float crouchSpeed = 2.5f;
    public float proneSpeed = 1.5f;
    private float _speed = 20f;
    private int stance;

    public float standTurnSpeed = 5f;
    public float crouchTurnSpeed = 2.5f;
    public float proneTurnSpeed = 1.5f;
    private float _turnSpeed = 5f;

    private StanceControler pStance;

    // Start is called before the first frame update
    void Start()
    {
        pStance = GameObject.FindGameObjectWithTag("Player").GetComponent<StanceControler>();
        _speed = standSpeed;
        _turnSpeed = standTurnSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //This reads input and controls character
        Movement();

        //This Controls stance speed
        StanceSpeed();


    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * (_speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * (_speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0,-_turnSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0,_turnSpeed * Time.deltaTime, 0);
        }
    }
    
    private void StanceSpeed()
    {
        if (pStance.stance == 1)
        {
            _speed = standSpeed;
            _turnSpeed = standTurnSpeed;
        }

        if (pStance.stance == 2)
        {
            _speed = crouchSpeed;
            _turnSpeed = crouchTurnSpeed;
        }

        if (pStance.stance == 3)
        {
            _speed = proneSpeed;
            _turnSpeed = proneTurnSpeed;
        }
    }
}
