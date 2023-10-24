using UnityEngine;


public class Spawner : MonoBehaviour
{

    [SerializeField] [Range(1, 5)]
    private int _minCircles;

    [SerializeField] [Range(10, 100)]
    private int _maxCircles;

    private Camera _camera;

    [SerializeField] private GameObject _circlePrefab;

    private void Awake()
    {
        _camera = Camera.main;
    }
    private void Start()
    {
        SpawnCircles(_circlePrefab);
    }
  // have to place camera at origin 
    private Vector3 GetMaxWidthHeight(float boundary)
    {
        Vector3 screenposition = new Vector3(Screen.width, Screen.height,0);
        Vector3 widthheight = _camera.ScreenToWorldPoint(screenposition);
        widthheight = new Vector3(Mathf.Abs(widthheight.x)- Mathf.Abs(boundary), Mathf.Abs(widthheight.y) - Mathf.Abs(boundary), 0);
        return widthheight;
    }

    private void SpawnCircles(GameObject objecttospawn)
    {
        int numberofcircle = Mathf.RoundToInt(Random.Range(_minCircles, _maxCircles));
        Vector3 spawnboundary = GetMaxWidthHeight(0.6f);
        for(int i=1;i <= numberofcircle; i++)
        {
            Vector3 spawnposition = new Vector3(Random.Range(-spawnboundary.x, spawnboundary.x),
                Random.Range(-spawnboundary.y, spawnboundary.y), -5);

            Instantiate(_circlePrefab, spawnposition, Quaternion.identity);
        }
    }
}

