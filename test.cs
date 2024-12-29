using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float Speed ;
    public float JumpForce;

    private Rigidbody2D rig;
    private bool IsJumping;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimentação horizontal
        rig.velocity = new Vector2(Speed, rig.velocity.y);

        // Verifica se pode pular
        if (Input.GetMouseButtonDown(0) && !IsJumping)
        {
            rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            IsJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colidiu com: " + collision.gameObject.name + ", camada: " + collision.gameObject.layer);
        if (collision.gameObject.layer == 8)
        {
            IsJumping = false;
        }
    }
}
