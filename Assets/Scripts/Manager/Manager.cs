using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance = null;

    #region Contents
    private SpawnManager _spawnerMgr = new SpawnManager();
    #endregion

    // 싱글턴화
    public static Manager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        _spawnerMgr.Init();


        StartCoroutine(_spawnerMgr.Spawn());
    }

    private void Update()
    {

    }
}
