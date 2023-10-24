using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputReader)) ]
public class Player: MonoBehaviour
{
    private Camera _camera;
    private List<GameObject> _mouseOverGameObjectList;
    [SerializeField] private int _rayDistance = 20;
    [SerializeField] private LayerMask _layermask;
    [SerializeField] private PlayerInputReader _playerInputReader;

    private void Awake()
    {
        _mouseOverGameObjectList = new();
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        _playerInputReader.MouseButtonPressed += FireRaycast;
        _playerInputReader.MouseButtonUp += DisableCircle;
    }

    private void Start()
    {
        _playerInputReader = GetComponent<PlayerInputReader>();
    }

    private void FireRaycast(Vector3 mouseposition)
    {
        Ray ray = _camera.ScreenPointToRay(mouseposition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction,_rayDistance,_layermask);
        if(hit.collider!= null)
        {
            GameObject circle = hit.collider.gameObject;
            if (circle != null && circle.activeInHierarchy && !_mouseOverGameObjectList.Contains(circle))
            {
                _mouseOverGameObjectList.Add(circle);
            }
        }
        
    }

    private void DisableCircle()
    {
        if(_mouseOverGameObjectList !=null)
        {
            foreach (GameObject circle in _mouseOverGameObjectList)
            {
                circle.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        _playerInputReader.MouseButtonPressed -= FireRaycast;
        _playerInputReader.MouseButtonUp -= DisableCircle;
    }
}
