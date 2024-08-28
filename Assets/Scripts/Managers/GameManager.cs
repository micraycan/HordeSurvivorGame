using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("References")]
    [SerializeField] private Transform _player;

    [Header("Settings")]
    [SerializeField] private int _frameRate;

    [Header("Upgrade Options")]
    [SerializeField] private ItemSO[] _upgrades;

    public Transform Player => _player;
    public ItemSO[] Upgrades => _upgrades;

    protected override void Awake()
    {
        base.Awake();
        Application.targetFrameRate = _frameRate;
    }
}
