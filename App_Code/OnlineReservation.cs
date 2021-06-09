using System;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;
using BIC.Data;
using BIC.Entity;
using BIC.Biz;

namespace BIC.Utils
{
    public class RoomDetail
    {
        public int ID { get; set; }
        public int TypeOfRoomId { get; set; }
        public string NameOfRoom { get; set; }
        public string TypeOfRoom { get; set; }
        public int NoOfRoom { get; set; }
        public int MaxPeople { get; set; }
        public string RateOfRoom { get; set; }
        public string HotelName { get; set; }
        public string RoomPrice { get; set; }

        public RoomDetail(int typeOfRoomId, string nameOfRoom, string typeOfRoom, int noOfRoom, int maxPeople, string rateOfRoom, string hotelName, string roomPrice)
        {
            ID = typeOfRoomId;
            NameOfRoom = nameOfRoom;
            TypeOfRoom = typeOfRoom;
            NoOfRoom = noOfRoom;
            MaxPeople = maxPeople;
            RateOfRoom = rateOfRoom;
            HotelName = hotelName;
            RoomPrice = roomPrice;
        }

        public RoomDetail(string nameOfRoom, string hotelname, string idOfroom)
        {
            var dr = GetFirstTypeRoom(idOfroom);
            HotelName = hotelname;
            NameOfRoom = nameOfRoom;
            if (dr != null)
            {
                ID = BicConvert.ToInt32(dr[TypeOfRoomEntity.FIELD_TYPEOFROOMID]);
                TypeOfRoom = dr[TypeOfRoomEntity.FIELD_NAME].ToString();
                MaxPeople = BicConvert.ToInt32(dr[TypeOfRoomEntity.FIELD_MAXPEOPLE]);
                RateOfRoom = dr[TypeOfRoomEntity.FIELD_PRICE].ToString();
            }
            NoOfRoom = 1;
        }
        public RoomDetail(string idOfroom, string hotelname)
        {
            var dr = GetFirstTypeRoom(idOfroom);
            HotelName = hotelname;
            //NameOfRoom = nameOfRoom;
            if (dr != null)
            {
                ID = BicConvert.ToInt32(dr[TypeOfRoomEntity.FIELD_TYPEOFROOMID]);
                TypeOfRoom = dr[TypeOfRoomEntity.FIELD_NAME].ToString();
                MaxPeople = BicConvert.ToInt32(dr[TypeOfRoomEntity.FIELD_MAXPEOPLE]);
                RateOfRoom = dr[TypeOfRoomEntity.FIELD_PRICE].ToString();
                NameOfRoom = dr[TypeOfRoomEntity.FIELD_ROOMNAME].ToString();
                RoomPrice = dr[TypeOfRoomEntity.FIELD_PRICE].ToString().Replace("++", string.Empty);
            }
            NoOfRoom = 1;
        }
        //public RoomDetail(int roomId, string nameOfRoom,string hotelName)
        //{
        //    DataRow dr = GetFirstTypeRoom(nameOfRoom);
        //    ID = roomId;
        //    NameOfRoom = nameOfRoom;

        //    if (dr != null)
        //    {
        //        TypeOfRoom = dr["Name"].ToString();
        //        MaxPeople = BicConvert.ToInt32(dr["MaxPeople"]);
        //    }
        //    NoOfRoom = 1;
        //    HotelName = hotelName;
        //}
        public RoomDetail()
        {

        }
        protected DataRow GetFirstTypeRoom(string roomID)
        {
            DataRow dr = null;
            var data = new BicGetData { TableName = "TypeOfRoom", PageSize = 1 };
            data.Sorting.Add(new SortingItem("Priority", true));
            data.Selecting.Add(TypeOfRoomEntity.FIELD_ROOMNAME);
            data.Selecting.Add(TypeOfRoomEntity.FIELD_MAXPEOPLE);
            data.Selecting.Add(TypeOfRoomEntity.FIELD_PRICE);
            data.Selecting.Add(TypeOfRoomEntity.FIELD_TYPEOFROOMID);
            data.Selecting.Add(TypeOfRoomEntity.FIELD_NAME);

            data.Conditioning.Add(new ConditioningItem
              {
                  Column = "RoomID",
                  Value = roomID,
                  Operator = Operator.EQUAL,
                  CompareType = CompareType.STRING
              });
            var dt = data.GetPagingData();
            if (dt.Rows.Count > 0)
                dr = dt.Rows[0];

            return dr;
        }

        public Reservation Reservation
        {
            set { BicSession.SetValue("OnlineReservation", value); }
            get
            {
                var res = (Reservation)BicSession.ToObject("OnlineReservation") ?? new Reservation();
                return res;
            }
        }

    }
    public class Reservation
    {

        public string Checkin { get; set; }
        public string Checkout { get; set; }
        public int Adults { get; set; }
        public int Child { get; set; }
        public bool Smoking { get; set; }
        public bool NeedCar { get; set; }
        public string FightNumber { get; set; }
        public string ArriveDate { get; set; }
        public string ArriveHour { get; set; }
        public string ArriveMinute { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string OtherRequest { get; set; }
        public string Visa { get; set; }
        public string DateVisa { get; set; }

        private Hashtable _hashTable = new Hashtable();
        public Hashtable RoomDetails
        {
            set { _hashTable = value; }
            get { return _hashTable; }
        }
        public ICollection RoomTable
        {
            get { return RoomDetails.Values; }
        }
        /// <summary>
        /// Danh sach phong da chon
        /// </summary>
        public Reservation()
        {
            var res = (Reservation)BicSession.ToObject("OnlineReservation");
            if (res != null)
            {
                Checkin = res.Checkin;
                Checkout = res.Checkout;
                Adults = res.Adults;
                Child = res.Child;
                Smoking = res.Smoking;
                NeedCar = res.NeedCar;
                FightNumber = res.FightNumber;
                ArriveDate = res.ArriveDate;
                ArriveHour = res.ArriveHour;
                ArriveMinute = res.ArriveMinute;
                FullName = res.FullName;
                Address = res.Address;
                Country = res.Country;
                Mobile = res.Mobile;
                Email = res.Email;
                OtherRequest = res.OtherRequest;
                RoomDetails = res.RoomDetails;
                Visa = res.Visa;
                DateVisa = res.DateVisa;
            }

        }
        public void Save()
        {
            BicSession.SetValue("OnlineReservation", this);
        }
        public void Clear()
        {
            BicSession.SetValue("OnlineReservation", null);

        }
        public void Add(RoomDetail roomDetail)
        {
            if (roomDetail == null) throw new ArgumentNullException("roomDetail");
            if (_hashTable[roomDetail.ID] == null)
            {
                _hashTable.Add(roomDetail.ID, roomDetail);
            }
            else
            {
                var roomcurent = (RoomDetail)_hashTable[roomDetail.ID];
                roomcurent.TypeOfRoom = roomDetail.TypeOfRoom;
                roomcurent.NoOfRoom = roomDetail.NoOfRoom;
                roomcurent.RoomPrice = roomDetail.RoomPrice;
            }
            roomDetail.Reservation = this;
        }
        public void Remove(int iId)
        {
            if (_hashTable[iId] != null)
            {
                var roomcurent = (RoomDetail)_hashTable[iId];
                _hashTable.Remove(iId);
                roomcurent.Reservation = this;
            }

        }

    }

}
