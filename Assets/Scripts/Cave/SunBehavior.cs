using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBehavior : MonoBehaviour
{
    GameObject sun;
    Light sunlight;
    Vector3 rotation;
    const float SPEED_REDUCTION = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        sun = gameObject;
        sunlight = GetComponent<Light>();

        rotation = sun.transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        rotation.x += Time.deltaTime / SPEED_REDUCTION;
        sun.transform.rotation = Quaternion.Euler(rotation);
    }
}
