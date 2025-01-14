using System.Collections;
using UnityEngine;

public class TutorialElement : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(HideAfterDelay(5f));
    }

    private IEnumerator HideAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
