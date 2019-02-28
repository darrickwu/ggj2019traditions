using UnityEngine;

public static class VectorMath
{
  public static Vector2 Flatten(Vector3 input)
  {
    return new Vector2(input.x, input.y);
  }
}