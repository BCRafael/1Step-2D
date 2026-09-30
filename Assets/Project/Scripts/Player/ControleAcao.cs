public class ControleAcao
{
    private Player player;

    private Acao acaoAtual;

    public ControleAcao(Player player)
    {
        this.player = player;
    }

    public void ReceberAcao(Acao acao)
    {
        acaoAtual = acao;
    }

    public Acao PegarAcao()
    {
        return acaoAtual;
    }

    public void LimparAcao()
    {
        acaoAtual = null;
    }
}