using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearBar : MonoBehaviour
{
    public RectTransform rectTransformBar;
    [Range(0,1)]
    public float percent;
    private float maxWidth;

    // Start is called before the first frame update
    void Start()
    {
        maxWidth = rectTransformBar.sizeDelta.x;
        percent = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateWidth();
    }

    public void NewPercent(float newPercent)
    {
        percent = newPercent;
        UpdateWidth();
    }

    private void UpdateWidth()
    {
        rectTransformBar.localScale = new Vector3(percent, 1, 1);
    }
}
