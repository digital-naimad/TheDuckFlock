using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Recorder.OutputPath;

public class PopupBase : MonoBehaviour
{
    [SerializeField] protected GameObject panel;

    [SerializeField] protected Button buttonPlay;

    [SerializeField] private float hideAnimationDuration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowPopup(bool withAnimation = false)
    {
        if (withAnimation)
        {
            gameObject.SetActive(true);
            transform.parent.DOScale(1f, 1f).From(0, true).SetEase(Ease.OutBack);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    public void HidePopup(bool withAnimation = false)
    {
        // TODO: hide with animation
        if (withAnimation)
        {
            transform.parent.DOScale(0, 1f).SetEase(Ease.InBack).OnComplete(() =>
            {
                //resultsPopup.HidePopup();
                gameObject.SetActive(false);
            });
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    

}
