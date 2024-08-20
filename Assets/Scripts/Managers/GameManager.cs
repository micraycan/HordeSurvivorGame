using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("References")]
    [SerializeField] private Player _player;

    [Header("Settings")]
    [SerializeField] private int _frameRate;

    public Player Player => _player;

    protected override void Awake()
    {
        base.Awake();
        Application.targetFrameRate = _frameRate;
    }
}
