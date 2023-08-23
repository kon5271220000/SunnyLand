using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerStates
{
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, string animName) : base(player, stateMachine, animName)
    {

    }

    public override void Enter()
    {
        base.Enter();

        player.Jump();
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
    }
}
