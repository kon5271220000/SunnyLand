using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerStates
{
    public PlayerAirState(Player player, PlayerStateMachine stateMachine, string animName) : base(player, stateMachine, animName)
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

        player.Move(xInput);
        player.Flip(xInput);
        player.Flip(xInput);
        player.anim.SetFloat("yVelocity", player.rb.velocity.y);

        if (player.IsGround())
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
