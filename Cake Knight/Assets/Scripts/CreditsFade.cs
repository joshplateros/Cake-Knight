using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsFade: MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Credits;

    void Start()
    {
        StartCoroutine(FadeTextToFullAlpha(1f, GetComponent<RawImage>()));
        StartCoroutine(FadeTextToZeroAlpha(1f, GetComponent<RawImage>()));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FadeTextToFullAlpha(float t, RawImage i) {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 0.4f) {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, RawImage i) {

        // ADJUST TIME HERE BASED ON LEGNTH OF CREDITS
        yield return new WaitForSeconds(40f);

        i.color = new Color(i.color.r, i.color.g, i.color.b, 0.4f);
        while (i.color.a > 0.0f) {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }

        Credits.SetActive(false);
    }


}

