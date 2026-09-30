using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float groundCheckDistance = 0.7f;
    public bool isGrounded;
    public LayerMask WhatIsGround;
    public bool facingRight = true;

    public ControleAcao ControleAcao { get; private set; }
    public ControleEstado ControleEstado { get; private set; }

    private void Awake()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        if (anim == null)
        {   
            anim = GetComponentInChildren<Animator>();
        }

        ControleAcao = new ControleAcao(this);
        ControleEstado = new ControleEstado();
    }

    private void Start()
    {
        ControleEstado.Initialize(
            new EstadoIdle(this)
        );
    }

    private void Update()
    {
        ControleEstado.Update();
        //Modularizar para colocar ChecarChao dentro de verificadores
        ChecarChao();
    }

    // Aq to verificando o input system

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 movimento = context.ReadValue<Vector2>();

        if (movimento.x > 0 && facingRight == false)
        {
            ControleAcao.ReceberAcao(
                new Virar(this)
            );
        }
        else if (movimento.x < 0 && facingRight == true)
        {
            ControleAcao.ReceberAcao(
                new Virar(this)
            );
        }

        ControleAcao.ReceberAcao(
            new Andar(this, movimento)
        );
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            ControleAcao.ReceberAcao(
                new Pular(this)
            );
        }
    }

    // Testando linha para parar de pular se nao tiver encostando no chao ((ground) = camada 6)
    // Ja testado, retirar depois
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0, -groundCheckDistance));
    }

    // Modularizar mais essa parte aqui
    // Talvez --- Verificadores - ChecarChao / ChecarRange (posteriormente) / checar WallJump (posteriormente)
    private void ChecarChao()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, WhatIsGround);
    }
}