using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plastic : MonoBehaviour
{
    public Image plasticMeter;
    float minPlastic, currentPlastic;
    // Start is called before the first frame update
    void Start()
    {
        minPlastic = 0;
        currentPlastic = 0;
        plasticMeter.fillAmount = 0;
    }

    // Update is called once per frame
    public void UpdatePlasticMeter(float amount)
    {
        StartCoroutine(AddPlastic(amount));
    }

    IEnumerator AddPlastic(float amount)
    {
        float t = 0;
        while(t < 1)
        {
            plasticMeter.fillAmount = (Mathf.Lerp(currentPlastic, (currentPlastic + amount), t));
            t += Time.deltaTime * 0.5f;
            yield return new WaitForEndOfFrame();
        }
        currentPlastic += amount;
        if (currentPlastic == minPlastic)
        {
            plasticMeter.fillAmount = 0;
        }
    }
}
