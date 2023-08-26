using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    protected Enemy enemy;
    protected EnemyStateMachine EnemyStateMachine;

    private string animName;

    public EnemyState(Enemy enemy, EnemyStateMachine enemyStateMachine, string animName)
    {
        this.enemy = enemy;
        this.EnemyStateMachine = enemyStateMachine;
        this.animName = animName;
    }

    public virtual void Enter()
    {
        enemy.anim.SetBool(animName, true);
    }

    public virtual void Exit() 
    {
        enemy.anim.SetBool(animName, false);
    }

    public virtual void Update()
    {

    }
}
