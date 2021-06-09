using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

/// <summary>
/// Summary description for UserCart
/// </summary>
public class UserInformation
{
    public UserInformation()
    {
        UserName = "";
        PassWord = "";
        Email = "";
        FullName = "";
        Address = "";
        Phone = "";
        City = "";
        District = "";
        GioiTinh = "";
        Company = "";
        Note = "";
    }
    public string UserName { get; set; }
    public string PassWord { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string GioiTinh { get; set; }
    public string Company { get; set; }
    public string Note { get; set; }
}

public class ShoppingCartInformation
{
    //BicSession.SetValue("shoppingCartInformation", shoppingCartInformation);
    public UserInformation NguoiDat { get; set; }
    public UserInformation ThanhToan { get; set; }
    public UserInformation NguoiNhan { get; set; }
    public string ShippingMethod { get; set; }
    public string PayMethod { get; set; }
    public string ShippingFee { get; set; }
}