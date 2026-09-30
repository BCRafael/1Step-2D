using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class EstadoRun : Estado
{
    private Vector2 direcao;

    public EstadoRun(Player player, Vector2 direcao) : base(player)
    {
        this.direcao = direcao;
    }

    public override void Enter()
    {
        Debug.Log("Entrou no Run");
    }

    public override void Update()
    {
        Acao acao = player.ControleAcao.PegarAcao();

        // Pular
        if (acao is Pular)
        {
            player.ControleAcao.LimparAcao();

            player.ControleEstado.ChangeState(
                new EstadoPulando(player)
            );

            return;
        }

        // Andar
        if (acao is Andar andar)
        {
            direcao = andar.Direcao;

            if (direcao.x == 0)
            {
                player.ControleAcao.LimparAcao();

                player.ControleEstado.ChangeState(
                    new EstadoIdle(player)
                );

                return;
            }
        }

        player.rb.linearVelocity = new Vector2(
            direcao.x * player.moveSpeed,
            player.rb.linearVelocity.y
        );
        player.anim.SetFloat("xVelocity", player.rb.linearVelocityX);
        player.anim.SetBool("isGrounded", player.isGrounded);
    }

    public override void Exit()
    {
        Debug.Log("Saiu do Run");
    }
}