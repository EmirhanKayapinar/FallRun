using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankManager : MonoBehaviour
{
    [SerializeField] Transform _playerTransform,_finishLine;
    [SerializeField] Transform[] _enemyTransforms;
    [SerializeField] Text _rankText;
    
    public bool _isFinish;
    public int _rank ;
    void Rank()
    {
        if (_playerTransform.position.z<_finishLine.position.z)
        {
            foreach (Transform item in _enemyTransforms)
            {
                if (item.position.z> _playerTransform.position.z)
                {
                    _rank++;
                }
                
            }
            _rankText.text = $"{_rank + 1}/11";
            _rank = 0;
            Debug.Log("a");
        }
    }

    private void FixedUpdate()
    {
        Rank();
    }
}
    

