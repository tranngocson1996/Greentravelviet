/**
* @author: ideawu
* @link: http://www.ideawu.net/prj/jquery-lazy-bind/
*/

function getBaseURL() {
    var url = location.href;
    var baseURL = url.substring(0, url.indexOf('/', 14));
    if (baseURL.indexOf('http://localhost') != -1 || baseURL.indexOf('http://buitricong') != -1) {
        // Base Url for localhost
        var url = location.href; // window.location.href;
        var pathname = location.pathname; // window.location.pathname;
        var index1 = url.indexOf(pathname);
        var index2 = url.indexOf("/", index1 + 1);
        var baseLocalUrl = url.substr(0, index2);
        return baseLocalUrl + "/";
    } else {
        // Root Url for domain name
        return baseURL + "/";
    }
}
var MyMap = {};

// callback(LatLng)
MyMap.auto_location = function (callback, fallback_addr) {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(
			function (position) {
			    var pos = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
			    callback(pos);
			},
			function () {
			    if (default_addr) {
			        MyMap.geoencode(fallback_addr, function (pos) {
			            callback(pos);
			        });
			    }
			}
		);
    } else {
        if (fallback_addr) {
            MyMap.geoencode(fallback_addr, function (pos) {
                callback(pos);
            });
        }
    }
}

/**
* option{addr, pos, callback(pos, addr, addr_ext), width, height}
* if addr and pos are both provided, only pos will be used.
*/
function AddressPicker(option) {
    var self = this;
    var default_opt = {
        posX: 21.029367706085676,
        posY: 105.85246763229372,
        callback: function () { },
        width: 540,
        height: 500,
        container: 'body',
        search: false, //true or false
        zoom: 15,
        buttonTitle: "",
        addressInput: "",
        view: false
    };

    if (option == undefined) {
        option = default_opt;
    } else {
        for (var k in default_opt) {
            if (option[k] == undefined) {
                option[k] = default_opt[k];
            }
        }
    }

    var map = null;
    var marker;
    var geocoder;
    var zoom = 15;

    var html = '' + '<div class="google-map">';
    if (option.search) {
        html += '<div class="input-local" ><span class="title">Bản đồ </span><input type="text" watermarkStyle="text" watermarkText="Nhập địa chỉ tìm kiếm." name="input_addr" value="" class="input-addr" id="inputAddr"/><input class="btnLocate" type="button" value="' + option.buttonTitle + '"/></div><div class="clear"></div>';
    }
    html += '<div id="map_canvas"></div></div>';
    self.node = $(html);
    self.node.appendTo($(option.container));

    self.node.find('input.btnLocate').click(function () {
        lacate_at_addr(self.node.find('input[name=input_addr]').val());
    });
    self.node.find('input[name=input_addr]').keydown(function (e) {
        var key = e.which;
        if (key == 13) {
            lacate_at_addr(self.node.find('input[name=input_addr]').val());
        }
    });

    if (option.addr) {
        self.node.find('input[name=input_addr]').val(option.addr);
    }

    self.close = function () {
        self.node.slideUp('normal', function () {
            infowindow.close();
        });
    }

    self.open = function () {
        //        var top = ($(window).height() - option.height) / 2;
        //        var left = ($(window).width() - option.width) / 2;
        //        top = Math.max(0, top);
        //        left = Math.max(0, left);

        //        self.node.css({
        //            padding: '10px',
        //            border: '3px solid #3cf',
        //            position: 'absolute',
        //            top: top + 'px',
        //            left: left + 'px',
        //            width: option.width + 'px'
        //        });

        self.node.slideDown('normal', function () {
            if (map == null) {
                var map_canvas = self.node.find('#map_canvas');
                map_canvas.css('width', option.width).css('height', option.height);
                map_init(map_canvas[0]);
            }
        });
    }

    function set_position(pos) {
        marker.setPosition(pos);
        map.setZoom(zoom);
        map.setCenter(pos);
    }

    function lacate_at_addr(addr) {
        infowindow.close();
        geocoder.geocode({ 'address': addr }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                var pos = results[0].geometry.location;
                set_position(pos);
            }
        });
    }

    function map_init(map_canvas) {

        var myOptions = {
            zoom: zoom,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        map = new google.maps.Map(map_canvas, myOptions);
        var companyImage = new google.maps.MarkerImage(
                getBaseURL() + 'Controls/GoogleMap/img/favicon.png',
            		new google.maps.Size(50, 50),
            		new google.maps.Point(0, 0),
            		new google.maps.Point(0, 0)
            	);

        var companyShadow = new google.maps.MarkerImage(
            getBaseURL() + 'Controls/GoogleMap/img/favicon.png',
                new google.maps.Size(50, 50),
                new google.maps.Point(0, 0),
                new google.maps.Point(0, 0));

        marker = new google.maps.Marker({
            map: map,
            icon: companyImage,
            shadow: companyShadow,
            title: "",
            zIndex: 3
        });
        geocoder = new google.maps.Geocoder();
        infowindow = new google.maps.InfoWindow({});

        var _pos = new google.maps.LatLng(option.posX, option.posY);

        set_position(_pos);
        if (_pos) {
            set_position(_pos);
        } else if (option.address) {
            lacate_at_addr(option.address);
        } else {
            MyMap.auto_location(function (pos) {
                set_position(pos);
            });
        }
        if (option.addressInput != "")
            geodecode(_pos);
        function geodecode(latLng) {
            marker.setPosition(latLng);

            var str = '<div style="text-align: center;">';
            str += '<b>Loading...</b>';
            str += '</div>';
            infowindow.setContent(str);
            infowindow.open(map, marker);

            geocoder.geocode({ 'latLng': latLng }, function (results, status) {
                if (status != google.maps.GeocoderStatus.OK) {
                    return;
                }
                var addr = "";

                if (option.addressInput != "") {
                    addr = option.addressInput;
                }
                else {
                    addr = results[0].formatted_address;
                }

                var str = '<div class="addressContainer"><div class="addr">' + addr + '</div>';
                str += '<input type="button" value="Lưu vị trí" id="ok" class="ok" title="Lưu vị trí bản đồ trên google map"/><input style="display:none" type="button" value="Thay đổi địa chỉ" id="save" class="ok" title="Chấp nhận địa chỉ sau khi sửa"/></div></div>';

                var node = $(str);
                if (option.view != "True") {
                    node.find('div.addr').dblclick(function () {
                        if ($(this).find("#txtInput").length != 1) {
                            node.find('input#ok').hide();
                            node.find('input#save').show();
                            $(this).html("<input type='text' value='" + $(this).html() + "' id='txtInput'/>");
                            $(this).find("input").bind("blur", function () {
                                $("div.addr").html($(this).val());
                                $('input#save').hide();
                                $('input#ok').show();
                            });
                        }
                    });
                    node.find('input#ok').click(function () {
                        //infowindow.close();
                        addr_ext = $("div.addr").html();
                        $("div.addr").html($("input#txtInput").val());
                        option.callback(latLng, addr, addr_ext);
                        $(this).hide();
                        return false;
                    });
                }
                else {
                    node.find('input#ok').hide();
                }
                infowindow.setContent(node[0]);
            });
        }

        google.maps.event.addListener(map, 'click', function (event) {
            //if (option.view != "True")
            geodecode(event.latLng);
            $('#txtXY').val(event.latLng);
            //alert(event.latLng);
            
        });
        google.maps.event.addListener(marker, 'click', function (event) {
            //if (option.view != "True")
            geodecode(event.latLng);
            //alert("a1");
        });
    }
}