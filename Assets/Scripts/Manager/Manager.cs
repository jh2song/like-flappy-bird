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
        
    }

    private void Update()
    {
        // 2초 마다 _spawnerMgr의 Spawn()을 호출
        // InvokeRepeating 사용
        
        // Invoke 방식은 여기에 적용할 수 없음
        // 코루틴 사용
    }
}
