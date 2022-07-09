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

    private float updateLockTimer;
    private void Awake()
    {
        Instance = this;
        UICanvas = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<Canvas>();
        MapManager = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();
        Cache = GetComponent<CacheScript>();
        PlayerData = GetComponent<PlayerData>();
        AudioManager = GetComponent<AudioManager>();
        MovesManager = GetComponent<MovesManager>();

        updateLockTimer = 0.0f;
    }

    private void Start()
    {
        // Instantiate(Cache.GetWindowByName("Tutor"), Vector3.zero, Quaternion.identity, UICanvas.transform);
    }

    private void Update()
    {
        updateLockTimer -= Time.deltaTime;
        if (updateLockTimer > 0)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && !BaseWindow.isWindowActive) 
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int clickCellPosition = MapManager.map.WorldToCell(clickPosition);
            clickCellPosition.z = 0;
            Cell cell = MapManager.GetCell(clickCellPosition);
            if (cell != null && cell.CellData.CellType != Consts.CellType.None)
            {
                updateLockTimer = Consts.WINDOW_INSTANTIATE_BLOCK_TIME;
                EventSystem.CallOnWindowsCloseNeeded();
                CellWindow window = InstantiateWindow("CellWindow").GetComponent<CellWindow>();
                window.SetCell(cell);
            }
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