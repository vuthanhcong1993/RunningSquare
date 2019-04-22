using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Separate parts handle a specific function out of your object

//Xác định một gia đình các thuật toán, đóng gói mỗi một, và làm cho họ hoán đổi cho nhau. Chiến lược cho phép thuật toán thay đổi độc lập với các máy khách sử dụng thuật toán.

//Các lớp và các đối tượng tham gia trong mô hình này là:

//### Strategy   (SortStrategy)
//* tuyên bố một giao diện chung cho tất cả các thuật toán được hỗ trợ.Bối cảnh sử dụng giao diện này để gọi thuật toán được xác định bởi một ConcreteStrategy

//### ConcreteStrategy (QuickSort, ShellSort, MergeSort)
//* Thực hiện các thuật toán bằng cách sử dụng giao diện Chiến lược

//###Context (SortedList)
//* được cấu hình với đối tượng ConcreteStrategy
//* duy trì một tham chiếu đến một đối tượng Chiến lược
//* có thể định nghĩa một giao diện cho phép Chiến lược truy cập dữ liệu của nó.
public interface IMove
{
    void Move();
}
 


public class Strategy : MonoBehaviour, IMove
{
   
    // Use this for initialization
    void Start () {
       

    }
	
	// Update is called once per frame
	void Update () {
		
	}

   public void Move()
    {
        Debug.Log("111");
    }
}

public class Strategy1 : MonoBehaviour, IMove
{

    public void Move()
    {
        Debug.Log("xxx");
    }
}
