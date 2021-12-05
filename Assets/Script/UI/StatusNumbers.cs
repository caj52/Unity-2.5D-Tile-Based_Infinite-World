using System;
using System.Collections;
using UnityEngine;

public class StatusNumbers : MonoBehaviour
{
    public GameObject numberObject;
    public Sprite[] sprites = new Sprite[10];
    private Creature creature;

    public void Start()
    {
        creature = transform.parent.GetComponent<Creature>();
    }

    public void DisplayDamage(int amountOfDamage)
    {
        var numbersToMake = amountOfDamage.ToString().Length;
        Vector2Int minMaxVector = GetMinMaxChildIndexVector(numbersToMake);
        
        CreateAndSetNumberObjects(numbersToMake,amountOfDamage);
        SetNumbersColor(Color.red);
        
        StartCoroutine(ShowNumbersForAmountOfSeconds(1.4f,minMaxVector));
        StartCoroutine(NumbersFloatAwayInRandomDirection(.2f,minMaxVector));
        StartCoroutine(NumbersFade(5f,minMaxVector));
    }

    public void CreateAndSetNumberObjects(int amountToCreate, int numberToShow)
    {
        var numberString = numberToShow.ToString();
        for (int x = 0; x < amountToCreate; x++)
        {
            var number = (int)Char.GetNumericValue(numberString[x]);
            var thisNum = Instantiate(numberObject);
            var numberPosition = ((x*.025f));
            var renderer = thisNum.GetComponent<SpriteRenderer>();
            thisNum.transform.parent = transform;
            thisNum.transform.localPosition = creature.transform.right * numberPosition;
            thisNum.transform.LookAt(Camera.main.transform);
            renderer.sprite = sprites[number];
            
            thisNum.SetActive(false);
        }
    }

    private IEnumerator NumbersFloatAwayInRandomDirection(float floatDuration,Vector2Int minMaxVector)
    {
        var random = UnityEngine.Random.Range(-100f, 100f);
        random /= 1000;
        var random2 = UnityEngine.Random.Range(-100f, 100f);
        random2 /= 1000;
        
        var randomVector = new Vector3(random, .1f, random2);
        for (int i = 0; i < (floatDuration * 100);i++) 
        {
            for (int x = minMaxVector.x; x < minMaxVector.y; x++)
            {
                try
                {
                    var number = transform.GetChild(x);
                    number.transform.localPosition += (randomVector / 20);
                }
                catch
                {
                }
            }
            yield return new WaitForSeconds(.01f);
        }
    }
    private IEnumerator NumbersFade(float fadeDuration,Vector2Int minMaxVector)
    {
        for (int i = 0; i < fadeDuration * 10;i++) 
        {
            for (int x = minMaxVector.x; x < minMaxVector.y; x++)
            {
                try
                {
                    var number = transform.GetChild(x);
                    var oldColor = number.GetComponent<SpriteRenderer>().color;
                    var newColor = new Color(oldColor.r, oldColor.g, oldColor.b,
                        oldColor.a - (1 / (fadeDuration * 10)));
                    number.GetComponent<SpriteRenderer>().color = newColor;
                }
                catch
                {
                }
            }
            yield return new WaitForSeconds(.01f);
        }
    }
    public IEnumerator ShowNumbersForAmountOfSeconds(float secondsDuration,Vector2Int minMaxVector)
    {
        for (int x = minMaxVector.x; x < minMaxVector.y; x++)
        {
            var number = transform.GetChild(x);
            number.gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(secondsDuration);
        DestroyCurrentNumbers();
    }

    public void DestroyCurrentNumbers()
    {
        for (int x = 0; x < transform.childCount; x++)
        {
            var number = transform.GetChild(x);
            Destroy(number.gameObject);
        }
    }

    public void SetNumbersColor(Color color)
    {
        for (int x = 0; x < transform.childCount; x++)
        {
            var thisNum = transform.GetChild(x);
            var renderer = thisNum.GetComponent<SpriteRenderer>();
            renderer.color = color;
        }
    }

    private Vector2Int GetMinMaxChildIndexVector(int numbersToMake)
    {
        var minRange = transform.childCount;
        var maxRange = minRange + numbersToMake;
        return new Vector2Int(minRange, maxRange);
    }
}
