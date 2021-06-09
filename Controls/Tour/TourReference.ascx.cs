using System;
using BIC.Utils;
using BIC.WebControls;

public partial class Controls_Tour_TourReference : BaseUIControl
{
    public int MenuUserId { get; set; }
    public int LastTourId { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        lvTourRef.MenuUserId = BicConvert.ToString(MenuUserId);
        lvTourRef.LastTourID = LastTourId;
        lvTourRef.EnableAroundUp = false;
        lvTourRef.PageSize = 10; //Mặc định giá trị là 10

        if (IsPostBack) return;
        LoadData(); //Nạp dữ liệu cho control

        //Nếu không có bản ghi nào sẽ ẩn control này
        if (lvTourRef.TotalItem == 0)
            Visible = false;
    }

    public void LoadData()
    {
        lvTourRef.LoadData();
    }

    public string IsNone(string value)
    {
        return (string.IsNullOrEmpty(value) == true ? "none" : "");
    }

    public string GetSafe(string oldPrice, string newPrice)
    {
        try
        {
            string result = string.Empty;
            if (string.IsNullOrEmpty(oldPrice) || string.IsNullOrEmpty(newPrice))
                result = "none";
            else
            {
                double old = BicConvert.ToDouble(BicString.Number(oldPrice));
                double newO = BicConvert.ToDouble(BicString.Number(newPrice));

                if (old > newO)
                {
                    result = (Math.Round((old - newO) * 100 / (old), 0)).ToString();
                }
                else
                {
                    result = "none";
                }
            }
            return result;
        }
        catch (Exception ex)
        {
            return "none";
        }
    }

    public string ToNo(string price)
    {
        try
        {
            if (string.IsNullOrEmpty(price))
            {
                return "";
            }
            else
            {
                return BicString.ToStringNO(price) + " " + BicResource.GetValue("donvigia");
            }
        }
        catch (Exception ex)
        {
            return price;
        }
    }
}