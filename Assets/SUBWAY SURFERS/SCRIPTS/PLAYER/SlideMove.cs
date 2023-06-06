using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMove : MonoBehaviour
{

    [SerializeField] public float slideDuration = 1f;
    [SerializeField] public float slideSpeed = 3f;
    [SerializeField] public bool isSliding = false;

    private void Update()
    {

        Sliding();

    }

    private void Sliding()
    {
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && !isSliding)
        {
            isSliding = true;
            StartCoroutine(SlideCoroutine());
        }
    }

    private IEnumerator SlideCoroutine()
    {

        float slideTimer = 0f;
        Vector3 originalScale = transform.localScale;
        transform.localScale = new Vector3(originalScale.x, originalScale.y * 0.5f, originalScale.z);

        while (slideTimer < slideDuration)
        {
            slideTimer += Time.deltaTime;

            yield return null;
        }

        transform.localScale = originalScale;

        isSliding = false;

    }

}
