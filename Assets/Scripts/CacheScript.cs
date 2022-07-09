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
    private Dictionary<Consts.CellType, CellData> cellDataList;

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
        cellDataList = new Dictionary<Consts.CellType, CellData>();
        foreach (var cellData in cacheSO.cellDataList)
        {
            cellDataList.Add(cellData.CellType, cellData);
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
        return new Resource { Type = Consts.ResourceType.None, BaseResource = Consts.ResourceType.None };
    }

    public CellData GetCellData(Consts.CellType cellType)
    {
        if (cellDataList.ContainsKey(cellType))
            return cellDataList[cellType];
        return new CellData { CellType = Consts.CellType.None };
    }
}