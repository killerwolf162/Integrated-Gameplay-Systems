using System.Collections.Generic;
using UnityEngine;

public class InputHandler
{
    private List<KeyCommand> commands = new List<KeyCommand>();

    public void HandleInput()
    {
        foreach (var binding in commands)
        {
            if (Input.GetKey(binding.key))
            {
                binding.command.Execute();
            }
        }
    }
    public void BindKeyToCommand(KeyCode key, ICommand command)
    {
        commands.Add(new KeyCommand
        {
            key = key,
            command = command
        });
    }

    public void UnbindKey(KeyCode key)
    {
        var items = commands.FindAll(x => x.key == key);
        items.ForEach(x => commands.Remove(x));
    }
}

public class KeyCommand
{
    public KeyCode key;
    public ICommand command;
}
