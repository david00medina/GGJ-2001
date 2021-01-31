using UnityEngine;

[System.Serializable]
public class PlayerData
{
    private int level;
    private bool hasSight;
    private bool hasSmell;
    private bool hasHearing;
    private float[] playerPos;

    public PlayerData(GameObject player)
    {
        level = GameManager.Level;
        hasSight = GameManager.HasSight;
        hasSmell = GameManager.HasSmell;
        hasHearing = GameManager.HasHearing;
        Vector3 position = player.transform.position;
        playerPos = new []
        {
            position.x,
            position.y,
            position.z
        };
    }

    public int Level
    {
        get => level;
        set => level = value;
    }

    public bool HasSight
    {
        get => hasSight;
        set => hasSight = value;
    }

    public bool HasSmell
    {
        get => hasSmell;
        set => hasSmell = value;
    }

    public bool HasHearing
    {
        get => hasHearing;
        set => hasHearing = value;
    }

    public float[] PlayerPos
    {
        get => playerPos;
        set => playerPos = value;
    }
}
