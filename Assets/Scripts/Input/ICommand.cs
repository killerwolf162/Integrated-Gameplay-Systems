using UnityEngine;

public interface ICommand
{
    public AbilityActor actor { get; }
    public void Execute();
}
