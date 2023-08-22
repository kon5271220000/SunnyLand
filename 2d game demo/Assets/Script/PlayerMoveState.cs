using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerStates
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, string animName) : base(player, stateMachine, animName)
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

        if(player.rb.velocity.x == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
