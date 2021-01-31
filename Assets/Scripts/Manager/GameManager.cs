using UnityEngine;

public static class GameManager
{
    [Header("Level")] 
    [SerializeField] private static int _level;

    private static bool _isPaused = false;

    [Header("Player")] private static bool _isPlayerFrozen = false;
    
    [Header("Senses")]
    [SerializeField] private static bool _hasSight = false;
    [SerializeField] private static bool _hasHearing = false;
    [SerializeField] private static bool _hasSmell = false;

    [Header("Dialogues")] 
    [SerializeField] private static bool _eventDialogue = true;

    public static int Level
    {
        get => _level;
        set => _level = value;
    }

    public static Vector3 PlayerPosition { get; private set; }

    public static bool IsPaused
    {
        get => _isPaused;
        set
        {
            _isPaused = value;

            Time.timeScale = _isPaused ? 0f : 1f;
        }
    }

    public static bool IsPlayerFrozen
    {
        get => _isPlayerFrozen;
        set => _isPlayerFrozen = value;
    }

    public static bool HasSight
    {
        get => _hasSight;
        set => _hasSight = value;
    }

    public static bool HasHearing
    {
        get => _hasHearing;
        set => _hasHearing = value;
    }

    public static bool HasSmell
    {
        get => _hasSmell;
        set => _hasSmell = value;
    }

    public static bool EventDialogue
    {
        get => _eventDialogue;
        set => _eventDialogue = value;
    }

    public static float Distance { get; set; }

    public static void SaveGame()
    {
        System.Game.SaveGame(GameObject.FindWithTag("Player"));
    }

    public static void LoadGame()
    {
        PlayerData data = System.Game.LoadGame();
        
        _level = data.Level;
        _hasSight = data.HasSight;
        _hasSmell = data.HasSmell;
        _hasHearing = data.HasHearing;
        
        PlayerPosition = new Vector3(
                data.PlayerPos[0],
                data.PlayerPos[1],
                data.PlayerPos[2]
            );
        
        
        Debug.Log("Game loaded!");
    }

    public static void Reset()
    {
        IsPaused = false;
        _hasHearing = false;
        _hasSight = false;
        _hasSmell = false;
        _eventDialogue = true;
        _level = 0;
        PlayerPosition = new Vector3(0, 0, 0);
    }
}
