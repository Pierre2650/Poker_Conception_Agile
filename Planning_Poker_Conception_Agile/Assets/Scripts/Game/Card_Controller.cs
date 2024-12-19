using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Card_Controller : MonoBehaviour
{
    public string value;

    private bool onObject = false;

    public Vote_Controller vote_scrpt;

    //Curve for type of mouvement
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private AnimationCurve curveForStart;



    public Sprite[] valueCard;
    private SpriteRenderer spriteComponent;




    //handle sprites by searching them
    [Header("Animations")]
    public float delay = 0;
    private float startAnimationElapsed = 0;
    private float startAnimationD = 0.2f;

    private float onHoverElapsedT = 0;
    private float onHoverDuration = 0.16f;

    private float flipAnimationElapsed = 0;
    private float flipAnimationD = 0.3f;

    private float onClickElapsed = 0;
    private float onClickAnimationD = 0.1f;

    private bool onHover = false;
    private Coroutine currentAnim;

    public Vector2 endPos;

    private void Awake()
    {
        spriteComponent = GetComponent<SpriteRenderer>();
        spriteComponent.sprite = valueCard[0];
    }

    private void OnEnable()
    {
        StartCoroutine(startAnimation());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && onObject) {

            StartCoroutine(onClick());
            

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
        reset();
    }

    private void reset()
    {
        transform.localPosition = new Vector2(3.31f, -0.3f);
        spriteComponent.color = Color.white;
        spriteComponent.sprite = valueCard[0];
        transform.localScale = new Vector2(0.95f, 0.95f);
    }

    private IEnumerator onClick()
    {

        float percentageDur = 0;

        Color start = new Color(1f, 1f, 1f); // White
        Color end = new Color(144f / 255f, 144f / 255f, 144f / 255f); // Gray

        while (onClickElapsed < onClickAnimationD)
        {

            percentageDur = onClickElapsed / onClickAnimationD;

            spriteComponent.color = Color.Lerp(start, end, curve.Evaluate(percentageDur));

            onClickElapsed += Time.deltaTime;
            yield return null;

        }
        onClickElapsed = 0;

        while (onClickElapsed < onClickAnimationD)
        {

            percentageDur = onClickElapsed / onClickAnimationD;

            spriteComponent.color = Color.Lerp(end, start, curve.Evaluate(percentageDur));

            onClickElapsed += Time.deltaTime;
            yield return null;

        }
        onClickElapsed = 0;

        vote_scrpt.choiceMade(value);
    }


    private IEnumerator onHoverAnimation()
    {
        

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
       
        float percentageDur = 0;

        Vector2 start = transform.localScale;
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

        StartCoroutine(flipCard());



    }

    private IEnumerator flipCard() {
        float percentageDur = 0;

        Quaternion start = Quaternion.Euler(0, 0, 0);
        Quaternion end = Quaternion.Euler(0, -90, 0);


        while (flipAnimationElapsed < flipAnimationD)
        {

            percentageDur = flipAnimationElapsed / flipAnimationD;

            transform.rotation = Quaternion.Lerp(start, end, curve.Evaluate(percentageDur));

            flipAnimationElapsed += Time.deltaTime;
            yield return null;

        }

        flipAnimationElapsed = 0;

        //change image
        spriteComponent.sprite = valueCard[1];

        while (flipAnimationElapsed < flipAnimationD)
        {

            percentageDur = flipAnimationElapsed / flipAnimationD;

            transform.rotation = Quaternion.Lerp(end, start, curve.Evaluate(percentageDur));

            flipAnimationElapsed += Time.deltaTime;
            yield return null;

        }




        flipAnimationElapsed = 0;

        
    }

    //private IEnumerator endAnimation() { 
    //}


}
