using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//xác định hành vi trong một phân lớp bằng cách sử dụng một tập hợp các hoạt động được cung cấp bởi lớp cơ sở của nó.


//Một lớp cơ sở định nghĩa một phương pháp sandbox trừu tượng và một số hoạt động được cung cấp.Đánh dấu chúng được bảo vệ làm rõ rằng chúng được sử dụng bởi các 
//lớp bắt nguồn.Mỗi lớp con được tạo ra sandboxed thực hiện các phương pháp sandbox sử dụng các hoạt động cung cấp.

//Mẫu Sandbox Subclass là một mẫu rất đơn giản, phổ biến ẩn giấu ở rất nhiều codebases, thậm chí bên ngoài của trò chơi.Nếu bạn có một phương pháp không được bảo vệ ảo nằm xung quanh, có lẽ bạn đã sử dụng một cái gì đó như thế này.Subclass Sandbox phù hợp khi:

//- Bạn có một lớp cơ sở với một số lớp bắt nguồn.
//- Lớp cơ sở có thể cung cấp tất cả các hoạt động mà một lớp bắt nguồn có thể cần phải thực hiện.
//- Có sự chồng chéo hành vi trong các lớp con và bạn muốn chia sẻ mã giữa chúng dễ dàng hơn.
//- Bạn muốn giảm thiểu sự ghép nối giữa các lớp có nguồn gốc và phần còn lại của chương trình.

// không phải sửa đổi lớp con liên tục
public abstract class Sandbox : MonoBehaviour {
    
    public abstract void Active();

     protected  void PlayerSound(int a)
    {
        Debug.Log("PlayerSound");
    }
     protected  void GamePlay()
    {
        Debug.Log("GamePlay");
    }
}

public class ChildSandBox : Sandbox
{
    public override void Active()
    {
        PlayerSound(5);
        GamePlay();
    }
}

public class ChildSandBox1 : Sandbox
{
    public override void Active()
    {
        PlayerSound(8);
        GamePlay();
    }
}


