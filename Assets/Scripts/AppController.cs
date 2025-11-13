using UnityEngine;
using TMPro;
using System.Collections;

public class AppController : MonoBehaviour
{
    public TextMeshProUGUI instructionText;
    public float showTime = 4f;

    void Start() { if (instructionText) StartCoroutine(HideSoon()); }

    IEnumerator HideSoon()
    {
        yield return new WaitForSeconds(showTime);
        if (instructionText) instructionText.gameObject.SetActive(false);
    }
}