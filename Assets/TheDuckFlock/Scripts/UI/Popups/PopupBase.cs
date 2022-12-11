using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupBase : MonoBehaviour
{
    [SerializeField] protected GameObject panel;

    [SerializeField] protected Button buttonPlay;

    [SerializeField] protected float showAnimationDuration = 1f;
    [SerializeField] protected float hideAnimationDuration = 1f;

    
    public void ShowPopup(bool withAnimation = false)
    {
        if (withAnimation)
        {
            gameObject.SetActive(true);
            transform.DOScale(1f, showAnimationDuration).From(.5f, true).SetEase(Ease.OutBack);
            //transform.DOMoveY(0, showAnimationDuration).From(2000f, true).SetEase(Ease.InCubic);
            panel.GetComponent<Image>().DOFade(1f, showAnimationDuration).From(0f,true).SetEase(Ease.OutCubic);
            
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    public void HidePopup(bool withAnimation = false)
    {
        
        if (withAnimation)
        {
            transform.DOScale(0.5f, hideAnimationDuration).SetEase(Ease.InBack).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
            //transform.parent.DOMoveY(-2000f, showAnimationDuration).SetEase(Ease.InCubic);
            panel.GetComponent<Image>().DOFade(0f, showAnimationDuration).From(1f, true).SetEase(Ease.InCubic);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    

}
