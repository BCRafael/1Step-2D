public class ControleEstado
{
    private Estado estadoAtual;

    public void Initialize(Estado estadoInicial)
    {
        estadoAtual = estadoInicial;
        estadoAtual.Enter();
    }

    public void ChangeState(Estado novoEstado)
    {
        estadoAtual?.Exit();

        estadoAtual = novoEstado;

        estadoAtual.Enter();
    }

    public void Update()
    {
        estadoAtual?.Update();
    }
}