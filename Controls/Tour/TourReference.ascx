<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TourReference.ascx.cs" Inherits="Controls_Tour_TourReference" %>
<%@ Import Namespace="BIC.Utils" %>

<div class="Tour-Ref TourRef w100 fl">
    <div class="captionRef w100 fl">
        <bic:MenuCaption ID="CaptionRef" runat="server">
             <%=BicResource.GetValue("RELATEDTOURS")%>   
        </bic:MenuCaption>
    </div>
    <div class="list w100 fl adv-Tour-Ref">
        <bic:TourListViewRef ID="lvTourRef" runat="server" EnableAutoRedirect="False" ShowTourId="False">
            <ItemTemplate>
                <div class="itemRef">
                    <div class="imageRef">
                        <div class="img-safe <%#GetSafe(Eval("Mota2").ToString(),Eval("GiaHienThi").ToString()) %>">
                            <span class="ndkm">-<%#GetSafe(Eval("Mota2").ToString(),Eval("GiaHienThi").ToString()) %>%
                            </span>
                        </div>
                        <bic:Image CssClass="imageRef-item" Title='<%#Eval("TenTour")%>' ID="Image1" LoadThumbnail="True" runat="server" ImageId='<%# Eval("ImageID") %>' Link='<%# Eval("Url") %>' Alt='<%# Eval("TenTour") %>' />
                    </div>
                    <div class='title'>
                        <a href='<%#Eval("Url")%>' title='<%#Eval("TenTour")%>'><%#Eval("TenTour").ToString().Trim()%></a>
                    </div>
                    <div class="content">
                        <div class="matour">
                            <span class="lable"><%=BicResource.GetValue("Matour") %>: </span><%#Eval("MaTour") %>
                        </div>
                        <div class="daysto">
                            <span class="lable"><%=BicResource.GetValue("Daysto") %>: </span><%#Eval("NoiDi") %>
                        </div>
                        <div class="number"><span class="lable"><%=BicResource.GetValue("NumberDays") %>:</span> <%#Eval("SoNgay") %> <%=BicResource.GetValue("day") %> / <%#Eval("SoDem") %> <%=BicResource.GetValue("sodem") %></div>
                        <div class="price-older"><span class="<%#IsNone(Eval("Mota2").ToString()) %> priceOdd"><%=BicResource.GetValue("priceold") %>: <%#ToNo(Eval("Mota2").ToString()) %> <%=BicResource.GetValue("donvigia") %></span> </div>
                        <div class="price-new"><span class="lable"></span><%#ToNo(Eval("GiaHienThi").ToString()) %>  </div>
                    </div>
                    <div class="dattour">
                            <a  onclick="saveTour(<%#Eval("TourID")%>)">
                                <%=BicLanguage.CurrentLanguage=="vi"?"Đặt tour":"Book now" %>
                            </a>
                        </div>
                </div>
            </ItemTemplate>
        </bic:TourListViewRef>
    </div>
</div>
<script type="text/javascript">
    $('.list .image img').addClass('img-responsive');
</script>

<script type="text/javascript">
    $(document).ready(function () {
        $('.adv-Tour-Ref').slick({
            infinite: true,
            slidesToShow: 3,
            dots: false,
            slidesToScroll: 1,
            autoplay: true,
            responsive: [
                {
                    breakpoint: 2000,
                    settings: {
                        slidesToShow: 4,
                        slidesToScroll: 1,
                        dots: false
                    }

                },
                 {
                     breakpoint: 1367,
                     settings: {
                         slidesToShow: 3,
                         slidesToScroll: 1,
                         dots: false
                     }

                 },
                      {
                          breakpoint: 1038,
                          settings: {
                              slidesToShow: 3,
                              slidesToScroll: 1,
                              dots: false
                          }

                      },
                 {
                     breakpoint: 921,
                     settings: {
                         slidesToShow: 3,
                         slidesToScroll: 1,
                         dots: false

                     }

                 },

                 {
                     breakpoint: 769,
                     settings: {
                         slidesToShow: 3,
                         slidesToScroll: 1,
                         dots: true

                     }

                 },
                  {
                      breakpoint: 569,
                      settings: {
                          slidesToShow: 2,
                          slidesToScroll: 1,
                          dots: false

                      }

                  },
                   {
                       breakpoint: 561,
                       settings: {
                           slidesToShow: 2,
                           slidesToScroll: 1,
                           dots: false

                       }

                   },
                    {
                        breakpoint: 481,
                        settings: {
                            slidesToShow: 2,
                            slidesToScroll: 1,
                            dots: false

                        }

                    }
                    , {
                        breakpoint: 375,
                        settings: {
                            slidesToShow: 1,
                            slidesToScroll: 1,
                            dots: false

                        }
                    }
                    ,
                    {
                        breakpoint: 321,
                        settings: {
                            slidesToShow: 1,
                            slidesToScroll: 1,
                            dots: false
                        }
                    }
            ]
        });
    });
</script>


