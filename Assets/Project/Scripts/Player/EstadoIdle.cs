using UnityEditor.Callbacks;

public class EstadoIdle : Estado
{
    public EstadoIdle(Player player) : base(player)
    {
        
    }

    public override void Enter()
    {
        UnityEngine.Debug.Log("Entrou no Idle");
    }

    public override void Update()
    {
        Acao acao = player.ControleAcao.PegarAcao();

        if (acao is Pular)
        {
            player.ControleAcao.LimparAcao();

            player.ControleEstado.ChangeState(
                new EstadoPulando(player)
            );

            return;
        }

        if (acao is Andar andar)
        {
            if (andar.Direcao.x != 0)
            {
                player.ControleAcao.LimparAcao();

                player.ControleEstado.ChangeState(
                    new EstadoRun(player, andar.Direcao)
                );

                return;
            }
        }

        // Mantem o personagem parado
        player.rb.linearVelocity = new UnityEngine.Vector2(
            0,
            player.rb.linearVelocity.y
        );
        player.anim.SetFloat("xVelocity", player.rb.linearVelocityX);
        player.anim.SetBool("isGrounded", player.isGrounded);
    }

    public override void Exit()
    {
        UnityEngine.Debug.Log("Saiu do Idle");
    }
}