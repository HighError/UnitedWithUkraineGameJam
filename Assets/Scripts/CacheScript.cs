using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CacheScript : MonoBehaviour
{
    [SerializeField] private CacheSO cacheSO;

    private Dictionary<string, GameObject> prefabs;
    private Dictionary<string, BaseWindow> windows;
    private Dictionary<string, AudioClip> sounds;
    private Dictionary<string, Sprite> sprites;
    private Dictionary<Consts.ResourceType, Resource> resources;
    private List<CellData> cellDataList;
    private Dictionary<string, Nation> nations;

    private void Awake()
    {
        prefabs = new Dictionary<string, GameObject>();
        foreach (var prefab in cacheSO.prefabs)
        {
            prefabs.Add(prefab.name, prefab);
        }
        windows = new Dictionary<string, BaseWindow>();
        foreach (var window in cacheSO.windows)
        {
            windows.Add(window.name, window);
        }
        sounds = new Dictionary<string, AudioClip>();
        foreach (var sound in cacheSO.sounds)
        {
            sounds.Add(sound.name, sound);
        }
        sprites = new Dictionary<string, Sprite>();
        foreach (var sprite in cacheSO.sprites)
        {
            sprites.Add(sprite.name, sprite);
        }
        resources = new Dictionary<Consts.ResourceType, Resource>();
        foreach (var resource in cacheSO.resources)
        {
            resources.Add(resource.Type, resource);
        }
        cellDataList = new List<CellData>();
        foreach (var cellData in cacheSO.cellDataList)
        {
            cellDataList.Add(cellData);
        }
        nations = new Dictionary<string, Nation>();
        foreach (var nation in cacheSO.nations)
        {
            nations.Add(nation.Name, nation);
        }
    }

    public GameObject GetPrefabByName(string prefabName)
    {
        if (prefabs.ContainsKey(prefabName))
            return prefabs[prefabName];
        return null;
    }

    public BaseWindow GetWindowByName(string windowName)
    {
        if (windows.ContainsKey(windowName))
            return windows[windowName];
        return null;
    }

    public AudioClip GetSound(string soundName)
    {
        if (sounds.ContainsKey(soundName))
            return sounds[soundName];
        return null;
    }

    public Sprite GetSprite(string spriteName)
    {
        if (sprites.ContainsKey(spriteName))
            return sprites[spriteName];
        return null;
    }

    public Resource GetResource(Consts.ResourceType resourceType)
    {
        if (resources.ContainsKey(resourceType))
            return resources[resourceType];
        return new Resource { Type = Consts.ResourceType.None};
    }

    public List<CellData> GetCellDataList()
    {
        return cellDataList;
    }

    public Nation GetNation(string nationName)
    {
        if (nations.ContainsKey(nationName))
            return nations[nationName];
        return new Nation { Name = Consts.INVALID_NATION_NAME};
    }

    public Dictionary<string, Nation> GetNations()
    {
        return nations;
    }
}