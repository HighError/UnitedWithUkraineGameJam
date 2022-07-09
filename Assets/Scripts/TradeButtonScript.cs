using UnityEngine;
using UnityEngine.UI;

public class TradeButtonScript : MonoBehaviour
{
    public Button tradeButton;

    private void Awake()
    {
        tradeButton.onClick.AddListener(NextMoveButtonOnClick);
    }

    private void OnDestroy()
    {
        tradeButton.onClick.RemoveAllListeners();
    }

    private void NextMoveButtonOnClick()
    {
        GameManager.Instance.InstantiateWindow("TradeWindow");
        tradeButton.enabled = false;
        LeanTween.value(0.0f, 1.0f, 1.0f).setOnComplete(() => tradeButton.enabled = true);
    }
}
