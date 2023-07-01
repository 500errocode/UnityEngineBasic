using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StateStandUp : State
{
    public override bool canExecute => true;
    private GroundDetector _groundDetector;
    public StateStandUp(StateMachine machine) : base(machine) 
    {
        _groundDetector = machine.GetComponent<GroundDetector>();
    }

    public override StateType MoveNext()
    {
        StateType destination = StateType.StandUp;

        switch (currentStep)
        {
            case IState<StateType>.Step.None:
                {
                    currentStep++;
                }
                break;
            case IState<StateType>.Step.Start:
                {
                    animator.Play("StandUp");
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
                    if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                    {
                        destination = movement.horizontal == 0.0f ? StateType.Idle : StateType.Move;
                    }
                    else if (_groundDetector.isDetected == false)
                    {
                        destination = StateType.Fall;
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
