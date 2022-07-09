using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Canvas UICanvas { get; private set; }
    public CacheScript Cache { get; private set; }
    public PlayerData PlayerData { get; private set; }
    public AudioManager AudioManager { get; private set; }
    public Map MapManager { get; private set; }
    public MovesManager MovesManager { get; private set; }

    private void Awake()
    {
        Instance = this;
        UICanvas = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<Canvas>();
        MapManager = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();
        Cache = GetComponent<CacheScript>();
        PlayerData = GetComponent<PlayerData>();
        AudioManager = GetComponent<AudioManager>();
        MovesManager = GetComponent<MovesManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int clickCellPosition = MapManager.map.WorldToCell(clickPosition);
            clickCellPosition.z = 0;
            Cell cell = MapManager.GetCell(clickCellPosition);
            Debug.Log(cell.CellData.Resource);
        }
    }

    public BaseWindow InstantiateWindow(string windowName)
    {
        return Instantiate(Cache.GetWindowByName(windowName), Consts.DEFAULT_WINDOW_SPAWN_POSITION, Quaternion.identity, UICanvas.transform);
    }

    public void PlaySound(string soundName)
    {
        AudioManager.PlaySound(soundName);
    }
}