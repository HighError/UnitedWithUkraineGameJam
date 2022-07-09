using UnityEngine;

public class Consts
{
    public static Vector3 DEFAULT_WINDOW_SPAWN_POSITION = new Vector3(0, 1080, 0);
    public static float WINDOW_SHOWING_ANIM_TIME = 0.4f;

    public enum CellType
    {
        None = -1,
        Aqua = 0,
        Gore = 1,
        Grass = 2,
        Sand = 3
    }

    public enum ResourceType
    {
        None = -1,
        Wood = 0,
        Stone = 1,
        Fish = 2
    }

    public static int STORE_COUNT_FOR_LEVEL = 5;
    public const string INVALID_NATION_NAME = "UndefinedNation";
}
