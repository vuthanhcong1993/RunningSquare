using UnityEngine;


//Singleton Pattern là pattern đảm bảo rằng một lớp chỉ có một thể hiện (instance) duy nhất và trong đó cung cấp một cổng giao tiếp chung nhất để truy cập vào lớp đó.


//Quản lý việc truy cập tốt hơn vì chỉ có một thể hiện đơn nhất.
//Cho phép cải tiến lại các tác vụ(operations) và các thể hiện(representation) do pattern có thể được kế thừa và tùy biến lại thông qua một thể hiện của lớp con
//Quản lý số lượng thể hiện của một lớp, không nhất thiết chỉ có một thể hiện mà có số thể hiện xác định.
//Khả chuyển hơn so với việc dùng một lớp có thuộc tính là static, vì việc dùng lớp static chỉ có thể sử dụng một thể hiện duy nhất, còn Singleton Pattern cho phép quản lý các thể hiện tốt hơn và tùy biến theo điều kiện cụ thể.

//Trong trường hợp chỉ cần một thể hiện duy nhất của một lớp.
//Khi thể hiện duy nhất khả mở thông qua việc kế thừa, người dùng có thể sử dụng thể hiện kế thừa đó mà không cần thay đổi các đoạn mã của chương trình.

/*so sanh Observe
 -dung khi can truy cap vao bien
 - neu chi dung trong thoi gian ngan han >> dung observe
*/


public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    instance = obj.AddComponent<T>();
                }
            }
            return instance;
        }
    }

     void Awake()
    {
        if (instance != null && instance.GetInstanceID() != this.GetInstanceID())
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this as T;
            DontDestroyOnLoad(this.gameObject);

        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}