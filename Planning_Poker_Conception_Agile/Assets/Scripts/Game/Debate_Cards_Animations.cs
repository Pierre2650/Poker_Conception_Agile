using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debate_Cards_Animations : MonoBehaviour
{
   
    [SerializeField] private AnimationCurve curveForStart;

    [Header("Animations")]
    public float delay = 0;
    private float startAnimationElapsed = 0;
    private float startAnimationD = 0.2f;

    public Vector2 endPos;

    private void OnEnable()
    {
        
        StartCoroutine(startAnimation());
    }
    private IEnumerator startAnimation()
    {
        yield return new WaitForSeconds(delay);

        float percentageDur = 0;

        Vector2 start = transform.localPosition;



        while (startAnimationElapsed < startAnimationD)
        {

            percentageDur = startAnimationElapsed / startAnimationD;

            transform.localPosition = Vector2.Lerp(start, endPos, curveForStart.Evaluate(percentageDur));

            startAnimationElapsed += Time.deltaTime;
            yield return null;

        }

        startAnimationElapsed = 0;


    }

    
}
