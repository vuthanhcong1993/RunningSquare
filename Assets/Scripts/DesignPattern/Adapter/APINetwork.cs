using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Cho phép nhiều đối tượng có giao diện giao tiếp khác nhau có thể tương tác và giao tiếp với nhau.
//Tăng khả năng sử dụng lại thư viện với giao diện không thay đổi do không có mã nguồn.


//Người lập trình muốn sử dụng một lớp đã tồn tại trước đó nhưng giao diện sử dụng không phù hợp như mong muốn.
//Khi muốn tạo ra những lớp có khả năng sử dụng lại, chúng phối hợp với các lớp không liên quan hay những lớp không thể đoán trước được và những lớp này không có những giao diện tương thích.
//Cần phải có sự chuyển đổi giao diện từ nhiều nguồn khác nhau.
//Khi giao diện mong muốn không phải là interface mà là một lớp trừu tượng hay muốn tiếp hợp nhiều đối tượng cùng một lúc.

//Adaptee: định nghĩa giao diện không tương thích, cần được tiếp hợp vào.
//Adapter: lớp tiếp hợp, giúp giao diện không tương thích tiếp hợp được với giao diện đang làm việc.
//Target: định nghĩa giao diện đang làm việc(domain specific).
//Client: lớp sử dụng các đối tượng có giao diện Target.
//Có hai cách để thực hiện Adapter Pattern:
//Tiếp hợp lớp (Class Adapter Pattern).
//Tiếp hợp đối tượng(Object Adapter Pattern).

public interface UseAPI
{
    void InitNow();


    void LoginNow();


    void JoinNow();

}



//adaptee
public class APINetwork : MonoBehaviour
{

    public void Init()
    {
        //abc
    }

    public void Login()
    {
        //abc
    }

    public void Join()
    {
        //abc
    }
}

public class AdapterAPI : UseAPI
{
    APINetwork APINetwork = new APINetwork();
    public void InitNow()
    {
        APINetwork.Init();
    }

    public void JoinNow()
    {
        APINetwork.Login();
    }

    public void LoginNow()
    {
        APINetwork.Join();
    }
}
// Neu APINetwork thay doi,khong lo sua lai code o day,chi sua code o AdapterAPI
public class UseAPINow : MonoBehaviour
{
    private void Start()
    {
        UseAPI useApii = new AdapterAPI();
        useApii.InitNow();
    }
   
  



}
