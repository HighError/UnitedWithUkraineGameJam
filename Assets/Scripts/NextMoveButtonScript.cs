using UnityEngine;
using UnityEngine.UI;

public class NextMoveButtonScript : MonoBehaviour
{
    public Button nextMoveButton;

    private void Awake()
    {
        nextMoveButton.onClick.AddListener(NextMoveButtonOnClick);
    }

    private void OnDestroy()
    {
        nextMoveButton.onClick.RemoveAllListeners();
    }

    private void NextMoveButtonOnClick()
    {
        GameManager.Instance.MovesManager.NextMove();
        nextMoveButton.enabled = false;
        LeanTween.value(0.0f, 1.0f, 1.0f).setOnComplete(() => nextMoveButton.enabled = true);
    }
}
