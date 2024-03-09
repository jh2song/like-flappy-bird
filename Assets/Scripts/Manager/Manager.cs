using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager instance = null;

    #region 게임 UI
    private Canvas _canvas;

    private Transform _scoreTfm;
    private Transform _gameOverTfm;

    private TextMeshProUGUI _scoreTxt;
    #endregion

    #region Contents
    private SpawnManager _spawnerMgr = new SpawnManager();
    #endregion

    #region 클래스 게임로직 멤버변수
    private int _score;
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

            // DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
        _score = 0;

        #region 모듈화 필요 TODO

        _canvas = GameObject.FindObjectOfType<Canvas>();

        _scoreTfm = _canvas.transform.Find("ScoreTxt");
        _gameOverTfm = _canvas.transform.Find("GameOverPnl");

        if (_scoreTfm == null || _gameOverTfm == null)
        {
            Debug.Log("UI 할당 실패");
        }

        _scoreTxt = _scoreTfm.GetComponent<TextMeshProUGUI>();

        if (_scoreTxt == null)
        {
            Debug.Log("스코어 Tfm에서 TMP로 변환 실패");
        }

        _scoreTxt.text = _score.ToString();

        _scoreTfm.gameObject.SetActive(true);
        _gameOverTfm.gameObject.SetActive(false);
        
        #endregion

        _spawnerMgr.Init();

        StartCoroutine(_spawnerMgr.Spawn());
    }

    #region UI 처리
    public void ScoreUp()
    {
        _score++;
        _scoreTxt.text = _score.ToString();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        _gameOverTfm.gameObject.SetActive(true);
    }

    public void Retry()
    {
        _gameOverTfm.gameObject.SetActive(false);
        SceneManager.LoadScene("MainScene");
    }
    #endregion
}
