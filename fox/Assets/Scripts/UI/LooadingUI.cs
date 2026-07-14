using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LooadingUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dotText;
    private float doRate = 0.3f;
    private void Start()
    {
        StartCoroutine(DoAnimation());
    }
    IEnumerator DoAnimation()
    {
        while (true)
        {
            dotText.text = ".";
            yield return new WaitForSeconds(doRate);
            dotText.text = "..";
            yield return new WaitForSeconds(doRate);
            dotText.text = "...";
            yield return new WaitForSeconds(doRate);
            dotText.text = "....";
            yield return new WaitForSeconds(doRate);
            dotText.text = ".....";
            yield return new WaitForSeconds(doRate);
            dotText.text = "......";
            yield return new WaitForSeconds(doRate);
        }
    }
}
