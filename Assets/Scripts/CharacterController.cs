using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private float _rotationX;
    private float _rotationY;

    [SerializeField] private Transform _character;
    [SerializeField] private int _rotateSpeed = 150;
    [SerializeField] private int _moveSpeed = 100;
    [SerializeField] private float lowRotateBorder = -45;
    [SerializeField] private float highRotateBorder = 45;

    void Start()
    {
        
    }

    private void Update()
    {
        var newPosition = _character.position;

        if (Input.GetKey(KeyCode.A))
        {
            newPosition += _character.TransformDirection(Vector3.left) * _moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            newPosition += _character.TransformDirection(Vector3.right) * _moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            newPosition += _character.TransformDirection(Vector3.forward) * _moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            newPosition += _character.TransformDirection(Vector3.back) * _moveSpeed * Time.deltaTime;
        }

        _character.position = newPosition;


        _rotationX += Input.GetAxis("Mouse X") * _rotateSpeed * 5 * Time.deltaTime;


        var nextYAngleShift = Input.GetAxis("Mouse Y");
        if ((_rotationY > lowRotateBorder || Input.GetAxis("Mouse Y") > 0) &&
                (_rotationY < highRotateBorder || Input.GetAxis("Mouse Y") < 0))
        {
            _rotationY += nextYAngleShift * _rotateSpeed * 5 * Time.deltaTime;
        }        

        _character.localEulerAngles = new Vector3(-_rotationY, _rotationX, 0);
    }
}
