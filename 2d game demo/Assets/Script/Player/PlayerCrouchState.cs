using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchState : PlayerGroundState
{
    public PlayerCrouchState(Player player, PlayerStateMachine stateMachine, string animName) : base(player, stateMachine, animName)
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

        player.MoveWhileCrouch(xInput);
        player.Flip(xInput);

        if(yInput >= 0) 
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
