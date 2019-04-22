using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Command Pattern là một Design Pattern trong đó nó được dùng để đóng gói các yêu cầu khác nhau thành từng đối tượng riêng biệt, qua đó cho phép ta tham chiếu đến client với những yêu cầu khác nhau.
//Mẫu Command đóng gói yêu cầu như một đối tượng, làm cho nó có thể được truyền như 1 tham số, và được lưu trữ lại theo những cách thức khác nhau.



//### Command
//* tuyên bố một giao diện để thực hiện một hoạt động

//### ConcreteCommand
//* Định nghĩa sự ràng buộc giữa đối tượng Receiver và một hành động
//* thực hiện Execute bằng cách gọi các thao tác tương ứng(s) trên Receiver

//### Client 
//* tạo ra một đối tượng ConcreteCommand và đặt người nhận nó

//### Invoker
//* yêu cầu lệnh để thực hiện yêu cầu

//### Receiver
//* biết làm thế nào để thực hiện các hoạt động liên quan đến việc thực hiện yêu cầu.

//Dùng Command pattern khi:
//Tham chiếu đến một object.
//Xác định và thực hiện những yêu cầu tại những thời điểm khác nhau.
//Cần thực hiện thao tác Undo.
//Cần thực hiện thao tác Logging changes (trong trường hợp hệ thống bị treo).
//Cấu trúc hệ thống có dạng: điều khiển cấp cao được xây dựng trên những điều khiển nền tảng.
public interface ICommand 
{
    void Execute(PlayerCommand playerCommand);

    
}