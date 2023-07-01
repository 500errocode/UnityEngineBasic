using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StateIdle : State
{
    public override bool canExecute => true;
    private GroundDetector _groundDetector;
    public StateIdle(StateMachine machine) : base(machine) 
    {
        _groundDetector = machine.GetComponent<GroundDetector>();
    }

    public override StateType MoveNext()
    {
        StateType destination = StateType.Idle;

        switch (currentStep)
        {
            case IState<StateType>.Step.None:
                {
                    currentStep++;
                }
                break;
            case IState<StateType>.Step.Start:
                {
                    animator.Play("Idle");
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
                    if (_groundDetector.isDetected == false)
                        destination = StateType.Fall;
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