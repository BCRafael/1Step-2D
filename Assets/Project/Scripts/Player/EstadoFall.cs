using UnityEngine;

public class EstadoFall : Estado
{
    public EstadoFall(Player player) : base(player)
    {

    }

    public override void Enter()
    {
        Debug.Log("Entrou no Fall");
    }

    public override void Update()
    {
        Acao acao = player.ControleAcao.PegarAcao();

        if (acao is Andar andar)
        {
            player.rb.linearVelocity = new Vector2(
                andar.Direcao.x * player.moveSpeed,
                player.rb.linearVelocity.y
            );
        }

        if (player.isGrounded)
        {
            player.ControleEstado.ChangeState(
                new EstadoIdle(player)
            );
        }
        player.anim.SetFloat("yVelocity", -1);
        player.anim.SetBool("isGrounded", player.isGrounded);
    }

    public override void Exit()
    {
        Debug.Log("Saiu do Fall");
    }
}