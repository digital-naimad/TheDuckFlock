using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupBase : MonoBehaviour
{
    [SerializeField] protected GameObject panel;

    [SerializeField] protected Button buttonPlay;

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

        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    

}
