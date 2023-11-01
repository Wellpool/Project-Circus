using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float jumpForce = 5f;
    public bool _grounded;

    private Rigidbody _rb;

    private StanceControler _pStance;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _pStance = GetComponent<StanceControler>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && _grounded && _pStance.stance == 1)
        {
            Vector3 jump = new Vector3(0f, jumpForce, 0f);
            _rb.AddForce(jump);
            _grounded = false;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            _grounded = true;
        }
    }
}
