using UnityEngine;
using UnityEngine.Tilemaps;

public class Ken_GCamSystem : MonoBehaviour
{
    [Header("Nyanスクリプトへようこそ")]
    [SerializeField] private GameObject _Camera;
    [SerializeField] private Tilemap _Tilemap;

    [SerializeField] float _minX, _maxX, _minY, _maxY;
    [SerializeField] float _CamHeight, _CamWidth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _CamHeight = _Camera.GetComponent<Camera>().orthographicSize;
        _CamWidth = _CamHeight * _Camera.GetComponent<Camera>().aspect;

        BoundsInt boundsInt = _Tilemap.cellBounds;
        _minX = boundsInt.xMin;
        _maxX = boundsInt.xMax;
        _minY = boundsInt.yMin;
        _maxY = boundsInt.yMax;


    }

    // Update is called once per frame
    void Update()
    {

    }
    private void LateUpdate()
    {
        float targetX = Mathf.Clamp(_Camera.transform.position.x, _minX + _CamWidth, _maxX - _CamWidth);
        float targetY = Mathf.Clamp(_Camera.transform.position.y, _minY + _CamHeight, _maxY - _CamHeight);

        Vector3 pos = new Vector3(targetX, targetY, _Camera.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 5f);
    }
}
