using UnityEngine;
public interface IAutomaticSingleton { }

public static class Singleton
{
  public static T GetInstance<T>() where T : MonoBehaviour, IAutomaticSingleton
  {
    var found = Object.FindObjectOfType<T>();
    if (found) return found;

    var type = typeof(T);
    var obj = new GameObject("_" + type.Name, type);
    return obj.GetComponent<T>();
  }

  public static T GetExistingInstance<T>() where T : MonoBehaviour
  {
    var found = Object.FindObjectOfType<T>();
    if (found) return found;
    throw new System.Exception(string.Format("There is no {0} object in the scene", typeof(T).Name));
  }
}