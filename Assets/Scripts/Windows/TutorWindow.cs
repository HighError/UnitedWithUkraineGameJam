using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorWindow : BaseWindow
{
    private void Start()
    {
        isWindowActive = true;
    }

    protected override void Awake()
    {
        
    }

    public override void ButtonCloseOnClick()
    {
    }

    public override void HideWindow()
    {
        
    }
    public override void ShowWindow()
    {
        
    }

    public void Click()
    {
        isWindowActive = false;
        gameObject.SetActive(false);
    
    }
}
