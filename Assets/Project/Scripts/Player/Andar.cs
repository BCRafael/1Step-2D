using UnityEngine;

public class Andar : Acao
{
    public Vector2 Direcao { get; private set; }

    public Andar(Player player, Vector2 direcao) : base(player)
    {
        Direcao = direcao;
    }
}