using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private StateMachine stateMachine;

    private void Start()
    {
        stateMachine = new StateMachine();
        //start with begining
        stateMachine.SetState(new MainCellState());
    }

    private void Update()
    {
        stateMachine.Update();
    }
}