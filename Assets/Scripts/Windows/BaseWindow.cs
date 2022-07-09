using UnityEngine;
using UnityEngine.UI;

public class BaseWindow : MonoBehaviour
{
    [SerializeField] private Button buttonClose;
    [SerializeField] private RectTransform clicksCatcher;

    private RectTransform rectTransform;
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
        hidingPos = new Vector3(GameManager.Instance.UICanvas.pixelRect.size.x / 2 + rectTransform.sizeDelta.x, 0);
        rectTransform.anchoredPosition3D = hidingPos;

        if (clicksCatcher)
        {
            clicksCatcher.sizeDelta = GameManager.Instance.UICanvas.GetComponent<RectTransform>().sizeDelta;
        }
        LeanTween.moveLocal(gameObject, new Vector3(GameManager.Instance.UICanvas.pixelRect.size.x / 2, 0), Consts.WINDOW_SHOWING_ANIM_TIME);
    }

    public virtual void HideWindow()
    {
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