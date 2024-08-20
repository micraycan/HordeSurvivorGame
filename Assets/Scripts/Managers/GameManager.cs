using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("References")]
    [SerializeField] private Transform _player;

    [Header("Settings")]
    [SerializeField] private int _frameRate;

    public Transform Player => _player;

    protected override void Awake()
    {
        base.Awake();
        Application.targetFrameRate = _frameRate;
    }
}
