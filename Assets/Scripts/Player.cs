using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private InputHandler inputHandler = new InputHandler();

    private void Start()
    {
        inputHandler.BindKeyToCommand(KeyCode.Space, new DashAbility(), KeypressType.Down);
    }

    public void Update()
    {
        inputHandler.HandleInput();
    }
}
