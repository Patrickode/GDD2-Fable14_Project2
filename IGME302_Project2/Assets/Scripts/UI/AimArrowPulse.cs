using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimArrowPulse : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRend = null;

    [Tooltip("How far away from the start alpha the arrow will go when pulsing.")]
    [SerializeField] float alphaPulseRange = 0.55f;
    [Tooltip("How far away from the start position the arrow will go when oscillating.")]
    [SerializeField] float oscillateRange = 0.05f;

    [SerializeField] float pulseTime = 1;
    [SerializeField] float oscillateTime = 0.5f;

    private float originalAlpha;
    private Vector3 originalPos;

    private Coroutine pulseCoroutine;

    private void Awake()
    {
        originalAlpha = spriteRend.color.a;
        originalPos = transform.localPosition;
    }

    private void OnEnable() { pulseCoroutine = StartCoroutine(PulseAndOscillate()); }
    private void OnDisable() { StopCoroutine(pulseCoroutine); }

    private IEnumerator PulseAndOscillate()
    {
        //Set up variables to lerp with
        float pulseProgress = 0;
        float oscillateProgress = 0;

        float alphaStart = originalAlpha;
        float posStart = -oscillateRange;

        float alphaDestination = originalAlpha - alphaPulseRange;
        float posDestination = oscillateRange;

        while (true)
        {
            //Increase progresses by one increment of their durations
            pulseProgress += Time.deltaTime / pulseTime;
            oscillateProgress += Time.deltaTime / oscillateTime;

            //If either progress reaches 1, reset it
            //Snap back to start for pulse, go in reverse for oscillate
            if (pulseProgress >= 1) { pulseProgress--; }
            if (oscillateProgress >= 1)
            {
                posStart *= -1;
                posDestination *= -1;

                oscillateProgress--;
            }

            //Lerp new values for alpha and pos
            float newAlpha = Mathf.SmoothStep(alphaStart, alphaDestination, pulseProgress);
            float newPos = Mathf.SmoothStep(posStart, posDestination, oscillateProgress);

            //Set those new values
            spriteRend.color = new Color(spriteRend.color.r, spriteRend.color.g, spriteRend.color.b, newAlpha);
            transform.localPosition = originalPos + transform.right * newPos;

            yield return null;
        }
    }
}