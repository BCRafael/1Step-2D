public abstract class Estado
{
    protected Player player;

    protected Estado(Player player)
    {
        this.player = player;
    }

    public virtual void Enter()
    {
    }

    public virtual void Update()
    {
    }

    public virtual void Exit()
    {
    }
}