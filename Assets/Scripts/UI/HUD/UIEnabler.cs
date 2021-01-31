using UnityEngine;

public class UIEnabler : MonoBehaviour
{
    [SerializeField] private GameObject hud;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject sightPad;
    [SerializeField] private GameObject soundPad;
    [SerializeField] private GameObject scentPad;
    [SerializeField] private GameObject distanceMeter;

    public static UIEnabler instance;


    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(instance);
    }

    private void Update()
    {
        ActivateElement(hud, GameManager.HasHearing || GameManager.HasSmell || GameManager.HasSight);
        ActivateElement(pauseMenu, GameManager.IsPaused);
        ActivateElement(sightPad, GameManager.HasSight);
        ActivateElement(soundPad, GameManager.HasHearing);
        ActivateElement(scentPad, GameManager.HasSmell);
        ActivateElement(distanceMeter, GameManager.HasSmell);
    }

    private void ActivateElement(GameObject element, bool isActive)
    {
        element.SetActive(isActive);
    }
}
