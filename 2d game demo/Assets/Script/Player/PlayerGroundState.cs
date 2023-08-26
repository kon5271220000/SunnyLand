using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerStates
{
    public PlayerGroundState(Player player, PlayerStateMachine stateMachine, string animName) : base(player, stateMachine, animName)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (!player.IsGround())
        {
            stateMachine.ChangeState(player.airState);
        }

        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            stateMachine.ChangeState(player.jumpState);
        }

        if (yInput < 0)
        {
            stateMachine.ChangeState(player.crouchState);
        }
    }
}
