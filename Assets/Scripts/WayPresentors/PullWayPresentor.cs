using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PullWayPresentor : MonoBehaviour, IDirected
{
    [SerializeField] private LineRenderer _lineRender;
    [SerializeField] private LayerMask _mask;
    [SerializeField] private float _radius = 0.5f;
    [SerializeField] private float _maxDistance = 10f;

    public void Direct(Vector3 direction, float lenth)
        => DisplayWay(direction, lenth);

    public void Clear() => _lineRender.positionCount = 0;

    private void DisplayWay(Vector3 direction, float lenth)
    {
        var points = WayPoints(transform.position, direction, Mathf.Min(lenth, _maxDistance));

        _lineRender.positionCount = points.Count;
        _lineRender.SetPositions(points.ToArray());
    }

    private List<Vector3> WayPoints(Vector3 origin, Vector3 direction, float distance)
    {
        List<Vector3> result = new() { origin };

        float totalDistance = 0;
        Vector3 currentDirection = direction.normalized;
        Vector3 currentOrigin = origin;

        int i = 0;
        while (true)
        {
            float restDistance = distance - totalDistance;

            RaycastHit2D hit = Physics2D.CircleCast(currentOrigin, _radius, currentDirection, restDistance, _mask);
            if (hit.collider != null)
            {
                currentDirection = Vector3.Reflect(currentDirection, hit.normal);
                currentOrigin = hit.point + _radius * hit.normal;

                totalDistance += Vector3.Distance(result.Last(), currentOrigin);

                result.Add(currentOrigin);
            }
            else
            {
                currentOrigin += currentDirection * restDistance;
                result.Add(currentOrigin);
                break;
            }
            
            i++;
        }
        return result;
    }
}
