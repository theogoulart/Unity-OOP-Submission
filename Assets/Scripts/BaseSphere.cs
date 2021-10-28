using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSphere : MonoBehaviour
{
    protected Vector3 _mOffset;
    protected Vector3 _mLastPosition;
    protected Vector3 _mMovementDirection;
    protected float _mZCoord;
    protected PlayerController _playerController;
    protected Rigidbody _playerRb;

    public float forceModifier = 30;

    protected virtual void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _playerRb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        if (_playerController.hasSphereBeenLaunched) return;

        _mZCoord = Camera.main.WorldToScreenPoint(
            gameObject.transform.position).z;
        // Store offset = gameobject world pos - mouse world pos
        _mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = _mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        if (_playerController.hasSphereBeenLaunched) return;
        transform.position = GetMouseAsWorldPoint() + _mOffset;
    }

    void OnMouseUp()
    {
        if (_playerController.hasSphereBeenLaunched) return;
        Launch();
    }

    protected void FixedUpdate()
    {
        _mMovementDirection = Input.mousePosition - _mLastPosition;
        _mLastPosition = Input.mousePosition;
    }

    protected virtual Vector3 GetLaunchForce()
    {
        Debug.Log(_mMovementDirection);
        Vector3 forceX = Vector3.left * _mMovementDirection.y * forceModifier;
        Vector3 forceY = Vector3.up * _mMovementDirection.y;
        Vector3 forceZ = Vector3.forward * _mMovementDirection.x * forceModifier;

        return forceX + forceZ + forceY;
    }

    protected virtual void Launch()
    {
        Debug.Log(_mMovementDirection);
        _playerRb.AddForce(GetLaunchForce(), ForceMode.Impulse);
        StartCoroutine(OnLaunched());
    }

    protected virtual IEnumerator OnLaunched()
    {
        _playerController.hasSphereBeenLaunched = true;
        yield return new WaitForSeconds(3);
        GameManager.instance.SpawnSphere();
    }
}