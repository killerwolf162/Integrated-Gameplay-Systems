using UnityEngine;

public abstract class AbilityBase
{
    //make this a reference to a singleton audioplayer class
    protected abstract void PlaySound();
}


public class DashAbility : AbilityBase, ICommand
{
    public void Execute()
    {
        Debug.Log($"Player is dashing");
        PlaySound();
    }

    protected override void PlaySound()
    {
        Debug.Log("Played dashing sound");
    }
}

public class FireballAbility : AbilityBase, ICommand
{
    public void Execute()
    {
        Debug.Log($"Player casted a fireball");
        PlaySound();
    }

    protected override void PlaySound()
    {
        Debug.Log("Played fireball sound");
    }
}
