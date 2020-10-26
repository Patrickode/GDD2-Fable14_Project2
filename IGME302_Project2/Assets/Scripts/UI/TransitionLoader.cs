using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionLoader : MonoBehaviour
{
    [SerializeField] private Animator transitionAnimator = null;
    [SerializeField] private AnimationClip outClip = null;
    [SerializeField] private float clipDurationOffset = -0.01f;

    public static float OutLength { get; private set; } = 0;

    public static Action<int> TransitionLoad;
    public static Action TransitionInOut;

    private void Awake()
    {
        OutLength = outClip.length;

        TransitionLoad += OnTransitionLoad;
        TransitionInOut += OnTransitionInOut;
    }
    private void OnDestroy()
    {
        TransitionLoad -= OnTransitionLoad;
        TransitionInOut -= OnTransitionInOut;
    }

    private void OnTransitionLoad(int index)
    {
        if (index < 0) { index = -index + SceneManager.GetActiveScene().buildIndex; }
        StartCoroutine(PerformTransitionLoad(index));
    }
    private void OnTransitionInOut() { StartCoroutine(PerformTransitionInOut()); }

    private IEnumerator PerformTransitionLoad(int index)
    {
        transitionAnimator.SetTrigger("Out");
        yield return new WaitForSecondsRealtime(outClip.length + clipDurationOffset);
        SceneManager.LoadScene(index);
    }
    private IEnumerator PerformTransitionInOut()
    {
        transitionAnimator.SetTrigger("Out");
        yield return new WaitForSecondsRealtime(outClip.length);
        transitionAnimator.SetTrigger("In");
    }
}
