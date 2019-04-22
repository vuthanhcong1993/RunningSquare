// BounceApplication.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Model

//Giữ dữ liệu cốt lõi của ứng dụng và trạng thái, chẳng hạn như trình phát healthhoặc súng ammo.
//Sắp xếp theo thứ tự, deserialize, và / hoặc chuyển đổi giữa các loại.
//Tải / lưu dữ liệu (cục bộ hoặc trên web).
//Thông báo cho Ban kiểm soát về tiến độ hoạt động.
//Lưu trữ trạng thái trò chơi cho Máy trò chơi hữu hạn của trò chơi.
//Không bao giờ truy cập Views.

//View

//Có thể nhận dữ liệu từ Mô hình để đại diện cho trạng thái trò chơi cập nhật cho người dùng. Ví dụ: phương thức Xem player.Run() có thể sử dụng nội bộ model.speed để biểu hiện khả năng của người chơi.
//Nên không bao giờ mutate Models.
//Thực hiện đúng chức năng của lớp học. Ví dụ:
//A PlayerViewkhông nên thực hiện phát hiện đầu vào hoặc sửa đổi Game State.
//Chế độ xem phải hoạt động như một hộp đen có giao diện và thông báo cho các sự kiện quan trọng.
//Không lưu trữ dữ liệu cốt lõi (như tốc độ, sức khoẻ, cuộc sống, ...).

//Controller

//Không lưu trữ dữ liệu cốt lõi.
//Đôi khi có thể lọc thông báo từ các Lượt xem Không mong muốn.
//Cập nhật và sử dụng dữ liệu của Mô hình.
//Quản lý quy trình làm việc của Unity.

// Base class for all elements in this application.
public class BounceElement : MonoBehaviour
{
    // Gives access to the application and all instances.
    public BounceApplication app { get { return GameObject.FindObjectOfType<BounceApplication>(); } }
}

// 10 Bounces Entry Point.
public class BounceApplication : MonoBehaviour
{
    // Reference to the root instances of the MVC.
    public BounceModel model;
    public BounceView view;
    public BounceController controller;

    // Init things here
    void Start() { }
}