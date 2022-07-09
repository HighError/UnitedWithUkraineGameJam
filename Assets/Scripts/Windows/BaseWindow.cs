using UnityEngine;
using UnityEngine.UI;

public class BaseWindow : MonoBehaviour
{
    [SerializeField] protected Button buttonClose;
    [SerializeField] protected RectTransform clicksCatcher;
    public static bool isWindowActive;

    protected RectTransform rectTransform;
    protected Vector2 hidingPos;

    protected virtual void Awake()
    {
        if (!rectTransform)
            rectTransform = GetComponent<RectTransform>();

        if (!buttonClose)
            buttonClose = transform.Find("ButtonClose").GetComponent<Button>();
        buttonClose.onClick.AddListener(ButtonCloseOnClick);

        EventSystem.OnWindowsCloseNeeded += HideWindow;

        ShowWindow();
    }

    public virtual void ShowWindow()
    {
        isWindowActive = true;
        hidingPos = new Vector3(0, GameManager.Instance.UICanvas.pixelRect.size.y / 2 + rectTransform.sizeDelta.y);
        rectTransform.anchoredPosition3D = hidingPos;

        if (clicksCatcher)
        {
            clicksCatcher.sizeDelta = GameManager.Instance.UICanvas.GetComponent<RectTransform>().sizeDelta;
        }
        LeanTween.moveLocal(gameObject, Vector3.zero, Consts.WINDOW_SHOWING_ANIM_TIME);
    }

    public virtual void HideWindow()
    {
        isWindowActive = false;
        LeanTween.cancel(gameObject);
        LeanTween.moveLocal(gameObject, hidingPos, Consts.WINDOW_SHOWING_ANIM_TIME)
            .setOnComplete(() => Destroy(gameObject));
    }

    public virtual void ButtonCloseOnClick()
    {
        GameManager.Instance.PlaySound("ButtonClick");
        HideWindow();
    }

    protected virtual void OnDestroy()
    {
        EventSystem.OnWindowsCloseNeeded -= HideWindow;
    }
}