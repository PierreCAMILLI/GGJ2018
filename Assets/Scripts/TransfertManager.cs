using UnityEngine;

public class TransfertManager : SingletonBehaviour<TransfertManager> {
    [Range(0f, 1f)]
    private float _counter = 0f;
    [Range(0f, 1f)]
    private float _BulletTimeSpeed = 0f;
    private bool _bulletTimeIsActive = false;
    [SerializeField]
    private float _BulletTimeFill = 1f;
    [SerializeField]
    private float _BulletTimeEmpty = 2f;
    [SerializeField]
    private float _Radius = 1f;

    public float Counter
    {
        get { return _counter; }
        set { _counter = Mathf.Clamp(value, 0f, 1f); }
    }
    public float BulletTimeSpeed
    {
        get { return _BulletTimeSpeed; }
        set { _BulletTimeSpeed = Mathf.Clamp(value, 0f, 1f); }
    }
    public bool BulletTimeIsActive
    {
        get { return _bulletTimeIsActive; }
    }
    public float BulletTimeEmpty
    {
        get { return _BulletTimeEmpty; }
        set { _BulletTimeEmpty = value; }
    }
    public float Radius
    {
        get { return _Radius; }
        set { _Radius = value; }
    }

    public void toggleBulletTime(bool state)
    {
        _bulletTimeIsActive = state && _counter == 1;
    }

    void Update()
    {
        Time.timeScale = BulletTimeIsActive ? _BulletTimeSpeed : 1f;

        if (_bulletTimeIsActive)
        {
            _counter = Mathf.Clamp(_counter - (Time.unscaledDeltaTime * _BulletTimeEmpty), 0f, 1f);
        } else {
            _counter = Mathf.Clamp(_counter + (Time.unscaledDeltaTime * _BulletTimeFill), 0f, 1f);
        }

    }
}
