using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintManager : MonoBehaviour
{


    [SerializeField] GameObject _brush,_rankPanel;
    [SerializeField] float _brushSize;
    public float _currentTime;
    bool _ended,_paint;
    [SerializeField] Text _rankText,_rankScreen;

    private void FixedUpdate()
    {
        
    }

    void Update()
    {

        if (Input.GetMouseButton(0) )
        {

            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(Ray, out hit) && hit.collider.tag == "PaintWall"&&!_ended)
            {
                _paint = true;

                var go = Instantiate(_brush, hit.point - Vector3.forward * 0.005f, hit.collider.transform.rotation);
                go.transform.localScale = Vector3.one * _brushSize;
            }
           

        }
        if (_paint)
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= 4f)
            {
                Time.timeScale = 0;
                _rankPanel.SetActive(true);
                _rankText.text = $"Rank: {_rankScreen.text }";
                _ended = true;
                _paint = false;
            }
        }
        
    }



}
