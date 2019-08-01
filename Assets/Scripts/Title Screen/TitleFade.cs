using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleFade : MonoBehaviour
{
    Image imageToFade;
    const float TIME_TO_COMPLETION = 3.0f;
    float time;

    Color startColor;
    Color endColor;

    // Start is called before the first frame update
    void Start()
    {
        imageToFade = GetComponent<Image>();
        time = 0.0f;

        startColor = Color.black;
        endColor = startColor;
        endColor.a = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        imageToFade.color = Color.Lerp(startColor, endColor, time / TIME_TO_COMPLETION);

        if (time / TIME_TO_COMPLETION >= 1.0f)
        {
            Destroy(gameObject);
        }
    }
}
