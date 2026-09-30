using UnityEngine;

public class EstadoPulando : Estado
{
    public EstadoPulando(Player player) : base(player)
    {

    }

    public override void Enter()
    {
        Debug.Log("Entrou no Jump");

        player.rb.linearVelocity = new Vector2(
            player.rb.linearVelocity.x,
            player.jumpForce
        );
    }

    public override void Update()
    {
        // Movimento horizontal
        Acao acao = player.ControleAcao.PegarAcao();

        if (acao is Andar andar)
        {
            player.rb.linearVelocity = new Vector2(
                andar.Direcao.x * player.moveSpeed,
                player.rb.linearVelocity.y
            );
        }

        // Verifica se começou a cair
        if (player.rb.linearVelocity.y <= 0)
        {
            player.ControleEstado.ChangeState(
                new EstadoFall(player)
            );

            return;
        }
        player.anim.SetFloat("yVelocity", 1);
        player.anim.SetBool("isGrounded", player.isGrounded);
    }

    public override void Exit()
    {
        Debug.Log("Saiu do Jump");
    }
}