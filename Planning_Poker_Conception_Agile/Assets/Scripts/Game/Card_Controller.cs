using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Card_Controller : MonoBehaviour
{
    public string value;

    private bool onObject = false;
    static bool bugPrevention = false;

    public Vote_Controller vote_scrpt;

    //Curve for type of mouvement
    [SerializeField] private AnimationCurve curve;

    //handle sprites by searching them
    private float onHoverElapsedT = 0;
    public float onHoverDuration = 0;

    private bool onHover = false;
    private Coroutine currentAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && onObject && !bugPrevention) {

            vote_scrpt.choiceMade(value);

        }
        
    }

    void OnMouseOver()
    {
        onObject = true;

        if (!onHover && currentAnim == null) {
            currentAnim = StartCoroutine(onHoverAnimation());
            onHover = true;
        }
    }

    void OnMouseExit()
    {
        onObject = false;

        if (onHover) {
            if (currentAnim != null)
            {
                StopCoroutine(currentAnim);
                currentAnim = null;
            }
            currentAnim = StartCoroutine(offHoverAnimation());
            onHover = false;
        }
    }

    private void OnDisable()
    {
        onObject = false;
    }


    private IEnumerator onHoverAnimation()
    {
        Debug.Log("Coroutine started");

        float percentageDur = 0;

        Vector2 start = new Vector2(0.95f, 0.95f);
        Vector2 end = new Vector2(1.2f, 1.2f);


        while (onHoverElapsedT < onHoverDuration)
        {

            percentageDur = onHoverElapsedT / onHoverDuration; 

            transform.localScale = Vector2.Lerp(start, end, curve.Evaluate(percentageDur));

            onHoverElapsedT += Time.deltaTime;
            yield return null;

        }
        onHoverElapsedT = 0;

        currentAnim = null;


    }

    private IEnumerator offHoverAnimation()
    {
        Debug.Log("Coroutine started");

        float percentageDur = 0;

        Vector2 start = new Vector2(1.2f, 1.2f);
        Vector2 end = new Vector2(0.95f, 0.95f); 


        while (onHoverElapsedT < onHoverDuration)
        {

            percentageDur = onHoverElapsedT / onHoverDuration;

            transform.localScale = Vector2.Lerp(start, end, curve.Evaluate(percentageDur));

            onHoverElapsedT += Time.deltaTime;
            yield return null;

        }

        onHoverElapsedT = 0;

        currentAnim = null;


    }


}
