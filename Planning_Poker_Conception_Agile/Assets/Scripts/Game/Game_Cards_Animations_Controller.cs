using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Game_Cards_Animations_Controller : MonoBehaviour
{
    //Curve for type of mouvement
    [SerializeField] private AnimationCurve curve;

    public Vector2 endPos;
    public float rotationEnd;
    private float startAnimationElapsed = 0;
    private float startAnimationD = 0.3f;

    public  Go_button_controller go;

    // Start is called before the first frame update

    private void OnEnable()
    {
        StartCoroutine(startAnimation());
    }

    public void callEnd(int i)
    {
        StartCoroutine(endAnimation(i));
    }
    private IEnumerator startAnimation()
    {

        float percentageDur = 0;

        Vector2 start = transform.localPosition;

        Quaternion startRotation = Quaternion.Euler(0, 0, 0);
        Quaternion endRotation = Quaternion.Euler(0, 0, rotationEnd);



        while (startAnimationElapsed < startAnimationD)
        {

            percentageDur = startAnimationElapsed / startAnimationD;

            transform.localPosition = Vector2.Lerp(start, endPos, curve.Evaluate(percentageDur));
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, curve.Evaluate(percentageDur));

            startAnimationElapsed += Time.deltaTime;
            yield return null;

        }

        startAnimationElapsed = 0;

    }

    private IEnumerator endAnimation(int i )
    {
        float percentageDur = 0;

        Vector2 start = new Vector2(0.37f, -0.79f);

        Quaternion startRotation = Quaternion.Euler(0, 0, 0);
        Quaternion endRotation = Quaternion.Euler(0, 0, rotationEnd);



        while (startAnimationElapsed < startAnimationD)
        {

            percentageDur = startAnimationElapsed / startAnimationD;

            transform.localPosition = Vector2.Lerp(endPos, start, curve.Evaluate(percentageDur));
            transform.rotation = Quaternion.Lerp(endRotation,  startRotation, curve.Evaluate(percentageDur));

            startAnimationElapsed += Time.deltaTime;
            yield return null;

        }

        startAnimationElapsed = 0;

        if (i == 4)
        {
            go.nextStage();
        }

    }


}
