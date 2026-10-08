using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SlideToggle : MonoBehaviour
{
    [Header("内部引用")]
    public Toggle toggle;
    //背景板
    public RectTransform bkRt;
    //滑块
    public RectTransform sliderRt;

    [Header("动画")]
    public float animaDuration = 0.2f;
    public UnityAction<bool> OnValueChanged;

    private Tweener _tweener;
    // Start is called before the first frame update
    void Start()
    {
        toggle.onValueChanged.AddListener(OnInternelValueChanged);
        OnInternelValueChanged(toggle.isOn);
    }

    void OnInternelValueChanged(bool isOn)
    {
        if (bkRt == null || sliderRt == null) return;
        float maxOffset=(bkRt.rect.width-sliderRt.rect.width)/2-8;

        float targetX=isOn?maxOffset:-maxOffset;

        _tweener?.Kill();
        _tweener = sliderRt.DOAnchorPosX(targetX, animaDuration).SetEase(Ease.Linear);

        OnValueChanged?.Invoke(isOn);
    }
}
