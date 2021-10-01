using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GunAnimation : Singleton<GunAnimation>
{
    [SerializeField] private Transform gunTransform;

    private Vector3 defaultTransform;
    
    private void Awake()
    {
        defaultTransform = gunTransform.localPosition;
    }

    public void DoAnimation()
    {
        gunTransform.DOPunchScale(Vector3.one * 0.2f, .3f, 2, 0.5f).SetEase(Ease.InOutSine);
        gunTransform.DOLocalMove(new Vector3(0.53f,-0.42f,1.15f), .15f).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            gunTransform.DOLocalMove(defaultTransform, .15f).SetEase(Ease.InOutSine);
        });
    }
}
