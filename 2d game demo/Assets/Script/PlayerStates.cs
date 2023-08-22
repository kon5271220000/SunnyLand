using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerStates 
{
    protected Player player;
    protected PlayerStateMachine stateMachine;

    private string animName;
    

    public PlayerStates(Player player, PlayerStateMachine stateMachine, string animName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animName = animName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animName, true);
    }

    public virtual void Update()
    {
       
        
    }
    
    public virtual void Exit()
    {
        player.anim.SetBool(animName, false);
    }


}
