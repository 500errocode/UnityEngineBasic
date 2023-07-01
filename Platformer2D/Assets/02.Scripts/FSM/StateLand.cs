using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StateLand : State
{
    public override bool canExecute => true;
    public StateLand(StateMachine machine) : base(machine) 
    {
    }

    public override StateType MoveNext()
    {
        StateType destination = StateType.Land;

        switch (currentStep)
        {
            case IState<StateType>.Step.None:
                {
                    currentStep++;
                }
                break;
            case IState<StateType>.Step.Start:
                {
                    animator.Play("Land");
                    currentStep++;
                }
                break;
            case IState<StateType>.Step.Casting:
                {
                    currentStep++;
                }
                break;
            case IState<StateType>.Step.OnAction:
                {
                    // normalizedTime : 표준화 시간 ( 0.0 ~ 1.0 으로 표준화)
                    if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                    {
                        destination = movement.horizontal == 0.0f ? StateType.Idle : StateType.Move;
                    }
                }
                break;
            case IState<StateType>.Step.Finish:
                break;
            default:
                break;
        }

        return destination;
    }
}
