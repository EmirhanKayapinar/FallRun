using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text _geriSayimText;

    [SerializeField] GameObject _player,_cam,_vcam,_finishLine,_endPanel,_escPanel;

    [SerializeField] GameObject [] _enemy;

    

    bool _isStart = true;
    bool _isFinish;
    IEnumerator GeriSayim()
    {
        _cam.GetComponent<Animator>().Play("Camera");
        _geriSayimText.text = "3";
        yield return new WaitForSeconds(1);
        _geriSayimText.text = "2";
        yield return new WaitForSeconds(1);
        _geriSayimText.text = "1";
        yield return new WaitForSeconds(1);
        _geriSayimText.text = "Go";
        yield return new WaitForSeconds(0.5f);
        _vcam.GetComponent<CinemachineVirtualCamera>().enabled = true;
        _geriSayimText.text = "";
        _vcam.GetComponent<CinemachineVirtualCamera>().enabled = true;

        _player.GetComponent<PlayerController>().enabled = true;
        foreach (GameObject item in _enemy)
        {
            item.GetComponent<EnemyController>().enabled = true;
        }
        

    }
    
    public void OpenEndGamePanel()
    {
        _endPanel.SetActive(true);
    }

    public void CloseEscPanel()
    {
        _escPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void OpenEscPanel()
    {
        _escPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void RestartOnClick()
    {
        SceneManager.LoadScene(0);
        _escPanel.SetActive(false);
        _endPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitOnClick()
    {
        Application.Quit();
    }
   
    void Update()
    {
        if (_isStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(GeriSayim());
                _isStart = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenEscPanel();
        }
    }
}
