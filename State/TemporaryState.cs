using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TemporaryState : StateMachineBehaviour {

    public string exitParam = "EndRotation";
    public float time = 3;
    public UnityEvent onEnter;
    public UnityEvent onExit;

    private bool exit;
    private float delay;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        delay = Time.time;
        exit = false;
        onEnter.Invoke();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (exit) return;
        if (Time.time - delay > time) {
            exit = true;
            animator.SetTrigger(exitParam);
            onExit.Invoke();
        }
    }
}
