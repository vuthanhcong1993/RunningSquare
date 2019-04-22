using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tạo ra đối tượng mà không cần biết chính xác kiểu dữ liệu.
//Giúp mã nguồn của bạn trở nên dễ dàng bảo trì nếu có sự thay đổi.


//Khi nào sử dụng và Lợi ích của Abstract Factory **

//Taọ các đối tượng tương tự nhau
//Cung cấp phương thức hoàn chỉnh(có thể tổng hợp thành library) để sinh các đối tượng
//Tạo các đối tượng đặc biệt từ các lớp cha
//Dễ dàng tạo extends system từ system cũ
public class GunBase : MonoBehaviour {

    public int bullet;
    public int damage;
    public bool isSilence;
    public bool isKnife;

    public virtual void Title() { }
    
}
