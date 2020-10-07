using UnityEngine;

interface IMovable
{
    void Move(Vector2 displacement);
    void MoveTo(Vector2 position);
}