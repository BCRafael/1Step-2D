using UnityEngine;

public class Virar : Acao
{
    private float rotacaoY;

    public Virar(Player player) : base(player)
    {
        player.transform.Rotate(0, 180, 0);
        player.facingRight = !player.facingRight;
    }
}