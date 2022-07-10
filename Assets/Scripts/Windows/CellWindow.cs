using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CellWindow : BaseWindow
{
    public TextMeshProUGUI TitleText;
    public TextMeshProUGUI ResourceStorageText;
    public TextMeshProUGUI LevelText;
    public Button UpgradeButton;
    public Button MoveToCityButton;
    public Image TitleImage;

    private Cell cell;

    protected override void Awake()
    {
        base.Awake();
        rectTransform.anchoredPosition3D = new Vector3(1920, 0, 0);
        UpgradeButton.onClick.AddListener(Upgrade);
        MoveToCityButton.onClick.AddListener(MoveToCity);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        UpgradeButton.onClick.RemoveAllListeners();
        MoveToCityButton.onClick.RemoveAllListeners();
    }

    public void SetCell(Cell cell)
    {
        this.cell = cell;
        ResetData();
    }

    private void ResetData()
    {
        TitleText.text = cell.CellData.Resource.ToString();
        LevelText.text = "Current Level: " + cell.Level.ToString();
        ResourceStorageText.text = cell.CellData.Resource.ToString() + ": " 
            + cell.CurrentResourceCount.ToString() + "/" + cell.GetStoreLimit().ToString();
        TitleImage.sprite = cell.CellData.Image;
        int cost = (cell.Level + 1) * cell.CellData.GoldPrice;
        if (cell.Level == 0)
        {
            UpgradeButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = $"Buy: {cost}$";
            UpgradeButton.interactable = GameManager.Instance.PlayerData.money >= cost;
        }
        else if (cell.Level == 5)
        {
            UpgradeButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Max Level";
            UpgradeButton.interactable = false;
        }
        else {
            UpgradeButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = $"Upgrade: {cost}$";
            UpgradeButton.interactable = GameManager.Instance.PlayerData.money >= cost;
        }

        LevelText.gameObject.SetActive(cell.Level != 0);
        ResourceStorageText.gameObject.SetActive(cell.Level != 0);
        MoveToCityButton.gameObject.SetActive(cell.Level != 0);
        MoveToCityButton.interactable = cell.CurrentResourceCount > 0;
    }

    private void Upgrade() {
        if (!Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.PlaySound("ButtonClick");
            cell.Upgrade();
            ResetData();
        }
    }

    private void MoveToCity()
    {
        if (!Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.PlaySound("ButtonClick");
            cell.MoveToCity();
            ResetData();
        }
    }

    public override void ShowWindow()
    {
        GameManager.Instance.PlaySound("ButtonClick");
        isWindowActive = true;
        hidingPos = new Vector3(GameManager.Instance.UICanvas.GetComponent<RectTransform>().sizeDelta.x / 2 + rectTransform.sizeDelta.x, 0);
        rectTransform.anchoredPosition3D = hidingPos;

        if (clicksCatcher)
        {
            clicksCatcher.sizeDelta = GameManager.Instance.UICanvas.GetComponent<RectTransform>().sizeDelta * 5;
        }
        LeanTween.moveLocal(gameObject, new Vector3(GameManager.Instance.UICanvas.GetComponent<RectTransform>().sizeDelta.x / 2, 0), Consts.WINDOW_SHOWING_ANIM_TIME);
    }

    public override void HideWindow()
    {
        isWindowActive = false;
        LeanTween.cancel(gameObject);
        LeanTween.moveLocal(gameObject, hidingPos, Consts.WINDOW_SHOWING_ANIM_TIME)
            .setOnComplete(() => Destroy(gameObject));
    }
}
