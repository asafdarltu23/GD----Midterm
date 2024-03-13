using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeInText : MonoBehaviour
{
    public TextMeshProUGUI title;
    public GameObject retryBut;
    public GameObject returnBut;

    private bool Unfade = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayedEffects());
    }

    // Update is called once per frame
    void Update()
    {
        if (Unfade == true)
        {
            title.alpha = title.alpha + 0.005f;
        }
    }

    IEnumerator DelayedEffects()
    {
        yield return new WaitForSeconds(0.5f);
        retryBut.SetActive(true);
        returnBut.SetActive(true);
        //audioPlayer.Play();
        yield return new WaitForSeconds(0.5f);
        Unfade = true;
    }
}
