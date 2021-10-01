using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VP.Nest;

public class SplashLoadingScreen : MonoBehaviour
{
    [SerializeField] private RawImage gameIconAnimation;
    [SerializeField] private TextMeshProUGUI productNameText;
    [SerializeField] private TextMeshProUGUI loadingText;

    private string[] loadingTextArray = new string[] { "Loading.", "Loading..", "Loading...", "Loading" };

    private int currentIndex;

    [SerializeField] private float duration;
    [SerializeField] private AnimationCurve animationCurve;

    private void Awake()
    {
        currentIndex = 0;
        loadingText.SetText(loadingTextArray[currentIndex]);
        StartCoroutine(LoadingAnimation());

        float a = -1;
        gameIconAnimation.material.SetFloat("_Progression", a);
        DOTween.To(() => a, x =>
        {
            a = x;
            gameIconAnimation.material.SetFloat("_Progression", a);
            Debug.Log(a);
        }, 1, duration).SetDelay(0.5f).SetEase(animationCurve);
    }

    public void Setup()
    {
        var gameConfig = GameConfigsSO.GetGameConfigsSO();
        gameIconAnimation.texture = gameConfig.icon;
        productNameText.SetText(gameConfig.productName);
    }

    IEnumerator LoadingAnimation()
    {
        while (true)
        {
            yield return UsefulFunctions.BetterWaitForSeconds.Wait(0.5f);
            currentIndex++;

            if (currentIndex >= loadingTextArray.Length)
                currentIndex = 0;

            loadingText.SetText(loadingTextArray[currentIndex]);
        }
    }
}