using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{

    public float Speed;

    Rigidbody Rig;

    private void Start()
    {
      Rig = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 Position = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Rig.velocity = Position * Speed;
    }
}
