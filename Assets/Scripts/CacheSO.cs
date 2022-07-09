using UnityEngine;

[CreateAssetMenu(fileName = "GameCache", menuName = "ScriptableObjects/CacheSO")]
public class CacheSO : ScriptableObject
{
    public GameObject[] prefabs;
    public BaseWindow[] windows;
    public AudioClip[] sounds;
    public Sprite[] sprites;
    public Resource[] resources;
    public CellData[] cellDataList;
    public Nation[] nations;
}