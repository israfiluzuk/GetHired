using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameUtility
{
    public static bool ApproximatelyColor(Color color1, Color color2, int threshold = 1)
    {
        int r1 = (int)(color1.r * 255f);
        int r2 = (int)(color2.r * 255f);
        int g1 = (int)(color1.g * 255f);
        int g2 = (int)(color2.g * 255f);
        int b1 = (int)(color1.b * 255f);
        int b2 = (int)(color2.b * 255f);
        int a1 = (int)(color1.a * 255f);
        int a2 = (int)(color2.a * 255f);
        if (Mathf.Abs(r1 - r2) > threshold)
        {
            return false;
        }
        if (Mathf.Abs(g1 - g2) > threshold)
        {
            return false;
        }
        if (Mathf.Abs(b1 - b2) > threshold)
        {
            return false;
        }
        if (Mathf.Abs(a1 - a2) > threshold)
        {
            return false;
        }
        return true;
    }

    public static IEnumerator AgentFollowTarget(NavMeshAgent agent, Transform target, float minDistance)
    {
        while(DistanceXZ(target.position, agent.transform.position) > minDistance)
        {
            agent.SetDestination(target.position);
            yield return new WaitForSeconds(0.2f);
        }
    }

    public static float CalculateLengthOfPath(Vector3[] corners)
    {
        float distance = 0f;
        if(corners.Length < 2)
        {
            return 0f;
        }
        for (int i = 0; i < corners.Length - 1; i++)
        {
            distance += Vector3.Distance(corners[i], corners[i + 1]);
        }
        return distance;
    }

    public static float DistanceXZ(Vector3 posA, Vector3 posB)
    {
        posA.y = 0f;
        posB.y = 0f;
        return Vector3.Distance(posA, posB);
    }

    public static float DirectionToAngle(Vector2 dir)
    {
        float result = Mathf.Atan2(dir.y, dir.x) * 180 / Mathf.PI;
        return -result + 90f;
    }

    public static float GetAngleFromTwoPoints(Vector3 p1, Vector3 p2)
    {
        float result = Mathf.Atan2(p2.z - p1.z, p2.x - p1.x) * 180 / Mathf.PI;
        return -result + 90f;
    }

    public static Vector3 RadianToVector3(float radian)
    {
        return new Vector3(Mathf.Cos(radian), 0f, Mathf.Sin(radian));
    }

    public static Vector3 DegreeToVector3(float degree)
    {
        return RadianToVector3(degree * Mathf.Deg2Rad);
    }

    public static string FormatFloatToReadableString(float value)
    {
        float number = value;
        if (number < 1000)
        {
            return ((int)number).ToString();
        }
        string result = number.ToString();

        if (result.Contains(","))
        {
            result = result.Substring(0, 4);
            result = result.Replace(",", string.Empty);
        }
        else
        {
            result = result.Substring(0, 3);
        }

        do
        {
            number /= 1000;
        }
        while (number >= 1000);
        number = Mathf.CeilToInt(number);
        if (value >= 1000000000000000)
        {
            result = result + "Q";
        }
        else if (value >= 1000000000000)
        {
            result = result + "T";
        }
        else if (value >= 1000000000)
        {
            result = result + "B";
        }
        else if (value >= 1000000)
        {
            result = result + "M";
        }
        else if (value >= 1000)
        {
            result = result + "K";
        }

        if (((int)number).ToString().Length > 0 && ((int)number).ToString().Length < 3)
        {
            result = result.Insert(((int)number).ToString().Length, ".");
        }
        return result;
    }

    public static void Shuffle<T>(ref T[] ts)
    {
        var count = ts.Length;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }

    public static void Shuffle<T>(ref List<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }

    public static void ChangeAlphaSprite(SpriteRenderer sprite, float alpha)
    {
        Color c = sprite.color;
        c.a = alpha;
        sprite.color = c;
    }

    public static void ChangeAlphaImage(Image image, float alpha)
    {
        Color c = image.color;
        c.a = alpha;
        image.color = c;
    }

    public static void ChangeAlphaText(Text text, float alpha)
    {
        Color c = text.color;
        c.a = alpha;
        text.color = c;
    }

    public static int RandomIntExcept(int n, params int[] excepts)
    {
        int result = Random.Range(0, n - excepts.Length);

        for (int i = 0; i < excepts.Length; i++)
        {
            if (result < excepts[i])
                return result;
            result++;
        }
        return result;
    }

    public static bool ArrayContains<T>(T[] array, T element)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (element.Equals(array[i]))
            {
                return true;
            }
        }
        return false;
    }

    public static int[] GetRandomOrderedIntArray(int min, int length)
    {
        int[] resultArray = new int[length];
        for (int i = 0; i < resultArray.Length; i++)
        {
            resultArray[i] = min + i;
        }
        Shuffle(ref resultArray);
        return resultArray;
    }

    public static Vector3 MouseWorldPosition(float z = 0f)
    {
        Vector3 pos = Input.mousePosition;
        pos.z = Camera.main.transform.position.z;
        pos = Camera.main.ScreenToWorldPoint(pos);
        pos.z = z;
        return pos;
    }

    public static RectTransform GetUIElementOnMouse(GraphicRaycaster gr, string tag)
    {
        //Code to be place in a MonoBehaviour with a GraphicRaycaster component
        //Create the PointerEventData with null for the EventSystem
        PointerEventData ped = new PointerEventData(null);
        //Set required parameters, in this case, mouse position
        ped.position = Input.mousePosition;
        //Create list to receive all results
        List<RaycastResult> results = new List<RaycastResult>();
        //Raycast it
        gr.Raycast(ped, results);
        for (int i = 0; i < results.Count; i++)
        {
            if(results[i].gameObject.tag.Equals(tag))
            {
                return results[i].gameObject.transform as RectTransform;
            }
        }
        return null;
    }

    public static RectTransform GetUIElementOnMouseByName(GraphicRaycaster gr, string objectName)
    {
        //Code to be place in a MonoBehaviour with a GraphicRaycaster component
        //Create the PointerEventData with null for the EventSystem
        PointerEventData ped = new PointerEventData(null);
        //Set required parameters, in this case, mouse position
        ped.position = Input.mousePosition;
        //Create list to receive all results
        List<RaycastResult> results = new List<RaycastResult>();
        //Raycast it
        gr.Raycast(ped, results);
        for (int i = 0; i < results.Count; i++)
        {
            if (results[i].gameObject.name.Equals(objectName))
            {
                return results[i].gameObject.transform as RectTransform;
            }
        }
        return null;
    }

    public static T GetNearest<T>(Vector3 source, T[] arrayOfT) where T : MonoBehaviour
    {
        if (arrayOfT.Length == 0)
        {
            return default(T);
        }
        List<T> sorteds = arrayOfT.OrderBy(x => Vector3.Distance(source, x.transform.position)).ToList();
        return sorteds[Random.Range(0, Mathf.Min(4, arrayOfT.Length))];
    }

    public static T GetFarthest<T>(Vector3 source, T[] arrayOfT) where T : MonoBehaviour
    {
        if (arrayOfT.Length == 0)
        {
            return default(T);
        }
        List<T> sorteds = arrayOfT.OrderBy(x => Vector3.Distance(source, x.transform.position)).Reverse().ToList();
        return sorteds[Random.Range(0, Mathf.Min(4, arrayOfT.Length))];
    }
}
