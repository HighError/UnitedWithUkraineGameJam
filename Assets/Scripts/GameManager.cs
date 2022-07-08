using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Canvas UICanvas { get; private set; }
    public CacheScript Cache { get; private set; }
    public PlayerData PlayerData { get; private set; }
    public AudioManager AudioManager { get; private set; }

    private void Awake()
    {
        Instance = this;
        UICanvas = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<Canvas>();
        Cache = GetComponent<CacheScript>();
        PlayerData = GetComponent<PlayerData>();
        AudioManager = GetComponent<AudioManager>();
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