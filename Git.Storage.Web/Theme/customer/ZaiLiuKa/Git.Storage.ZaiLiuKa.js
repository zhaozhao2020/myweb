  
function searchProvinceChange(){

    var province = document.getElementById('province');
    var city = document.getElementById('city');
    city.textContent = null;
    cityOption = document.createElement('option');
    cityOption.value =0;
    cityOption.text = "市区";
    city.appendChild(cityOption);
    
    var cityArr = [];
    cityArr[0] = ['千代田区','中央区', '港区','新宿区','文京区','中野区','豊島区','練馬区'];
    cityArr[1] = ['横浜市','厚木市','大井町', '鎌倉市', '相模原市', '川崎市', '座間市']; 
    cityArr[2] = ['桑名市','伊賀市','松阪市', '名張市','鳥羽市','熊野市','亀山市']; 
    cityArr[3] = ['新潟市','長岡市','柏崎市','南魚沼市','小千谷市','上越市','三条市']; 
    cityArr[4] = ['大阪市','貝塚市', '柏原市', '吹田市', '高石市', '阪南市']; 

    for (var i = 0; i < province.length; i++) {      
        if (province[i+1].selected) {
                 for(var key in cityArr[i]) {                          
                cityOption = document.createElement('option');
                cityOption.text = cityArr[i][key];
                city.appendChild(cityOption);
            }
        }
    }

}


function editAjax() {
    $.ajax({
        type: "POST",
        url: "/ZaiLiuKa/ZaiLiuKaAjax/Edit",
        data: $('#userEdit').serialize(),
        dataType: "json",
        success: function (result) {
            if (result.update == "success") {
                alert("変更完了しました！");
                window.location.href = "/ZaiLiuKa/ZaiLiuKa/Index";
            } else {
                alert("変更失敗しました！");
                document.getElementById("userRegister").reset();
            }

        },
        error: function () {
            alert("アクセス失敗しました！");
            document.getElementById("userRegister").reset();
        }
    });
}


function registerAjax() {
    $.ajax({
        type: "POST",
        url: "/ZaiLiuKa/ZaiLiuKaAjax/Register",
        data: $('#userRegister').serialize(),
        dataType:"json",
        success: function (result) {          
            if (result.add == "success") {
                alert("登録完了しました！");
                document.getElementById("userRegister").reset();
            } else {
                alert("登録失敗しました！");
                document.getElementById("userRegister").reset();
            }

        },
        error: function () {
            alert("アクセス失敗しました！");
            document.getElementById("userRegister").reset();
        }
    });
}


var val = 0;
//var len = document.getElementsByName("ra").length;
var len = "";
var list = [];

function displayPage(value) {
    //alert(value);
    var tR = document.getElementsByTagName("tr");
    len = tR.length;
    
    for (var i = 1; i < len; i++) {
        var td = tR[i].children;
        var dto = {};
        dto["ZaiLiuKaNo"] = td[0].innerHTML;
        dto["UserName"] = td[1].innerHTML;
        dto["Birthday"] = td[2].innerHTML;
        dto["Sex"] = td[3].innerHTML
        dto["Qualification"] = td[4].innerHTML;
        dto["Adress"] = td[5].innerHTML;
        dto["Motivation"] = td[6].innerHTML;
        dto["PermitDay"] = td[7].innerHTML;
        list.push(dto);
      
    }
   
    val = value;

    var zaiLiuKa = document.getElementById("tbb");
    zaiLiuKa.textContent = null;
    if (value == 5) {
                if (len >= value) {
                    for (var i = 0; i < value; i++) {
                        var tr = document.createElement("tr");

                        var tdZaiLiuKaNo = document.createElement("td");
                        var tdUserName = document.createElement("td");
                        var tdBirthday = document.createElement("td");
                        var tdSex = document.createElement("td");
                        var tdQualification = document.createElement("td");
                        var tdAdress = document.createElement("td");
                        var tdMotivation = document.createElement("td");
                        var tdPermitDay = document.createElement("td");
                        var tdBianJi = document.createElement("td");
                        var tdDelete = document.createElement("td");
                        var tdDeleteAll = document.createElement("td");
                        
                       
                        tdZaiLiuKaNo.innerHTML = list[i].ZaiLiuKaNo;
                        tdZaiLiuKaNo.name = "zaiLiuKa";
                        tdUserName.innerHTML = list[i].UserName;
                        tdBirthday.innerHTML = list[i].Birthday;
                        tdSex.innerHTML = list[i].Sex;
                        tdQualification.innerHTML = list[i].Qualification;
                        tdAdress.innerHTML = list[i].Adress;
                        tdMotivation.innerHTML = list[i].Motivation;
                        tdPermitDay.innerHTML = list[i].PermitDay;
                        tdBianJi.innerHTML = "<td><button onclick='toEditPage(" + i + ")'>編集</button></td>";
                        tdDelete.innerHTML = "<button type='submit' onclick='deleteAjax(this.id)' id='"+i+"'>削除</button>";
                        tdDeleteAll.innerHTML = "<td><input type='checkbox' id='zai" + i + "'> </td>";

                        
                        tr.appendChild(tdZaiLiuKaNo);
                        tr.appendChild(tdUserName);
                        tr.appendChild(tdBirthday);
                        tr.appendChild(tdSex);
                        tr.appendChild(tdQualification);
                        tr.appendChild(tdAdress);
                        tr.appendChild(tdMotivation);
                        tr.appendChild(tdPermitDay);
                        tr.appendChild(tdBianJi);
                        tr.appendChild(tdDelete);
                        tr.appendChild(tdDeleteAll);

                        zaiLiuKa.appendChild(tr);

                    }
                }
                if (len < value) {
                    for (var i = 0; i < len; i++) {

                        var tr = document.createElement("tr");
                        var tdZaiLiuKaNo = document.createElement("td");
                        var tdUserName = document.createElement("td");
                        var tdBirthday = document.createElement("td");
                        var tdSex = document.createElement("td");
                        var tdQualification = document.createElement("td");
                        var tdAdress = document.createElement("td");
                        var tdMotivation = document.createElement("td");
                        var tdPermitDay = document.createElement("td");
                        var tdBianJi = document.createElement("td");
                        var tdDelete = document.createElement("td");
                        var tdDeleteAll = document.createElement("td");

                        tdZaiLiuKaNo.innerHTML = list[i].ZaiLiuKaNo;
                        tdZaiLiuKaNo.name = "zaiLiuKa";
                        tdUserName.innerHTML = list[i].UserName;
                        tdBirthday.innerHTML = list[i].Birthday;
                        tdSex.innerHTML = list[i].Sex;
                        tdQualification.innerHTML = list[i].Qualification;
                        tdAdress.innerHTML = list[i].Adress;
                        tdMotivation.innerHTML = list[i].Motivation;
                        tdPermitDay.innerHTML = list[i].PermitDay;
                        tdBianJi.innerHTML = "<td><button onclick='toEditPage(" + i + ")'>編集</button></td>";
                        tdDelete.innerHTML = "<button type='submit' onclick='deleteAjax(this.id)' id='" + i + "'>削除</button>";
                        tdDeleteAll.innerHTML = "<td><input type='checkbox' id='zai" + i + "'> </td>";

                       
                        tr.appendChild(tdZaiLiuKaNo);
                        tr.appendChild(tdUserName);
                        tr.appendChild(tdBirthday);
                        tr.appendChild(tdSex);
                        tr.appendChild(tdQualification);
                        tr.appendChild(tdAdress);
                        tr.appendChild(tdMotivation);
                        tr.appendChild(tdPermitDay);
                        tr.appendChild(tdBianJi);
                        tr.appendChild(tdDelete);
                        tr.appendChild(tdDeleteAll);

                        zaiLiuKa.appendChild(tr);

                    }


                }


            }

            if (value == 10) {
                if (len >= value) {
                    for (var i = 0; i < value; i++) {
                        var tr = document.createElement("tr");
                        var tdZaiLiuKaNo = document.createElement("td");
                        var tdUserName = document.createElement("td");
                        var tdBirthday = document.createElement("td");
                        var tdSex = document.createElement("td");
                        var tdQualification = document.createElement("td");
                        var tdAdress = document.createElement("td");
                        var tdMotivation = document.createElement("td");
                        var tdPermitDay = document.createElement("td");
                        var tdBianJi = document.createElement("td");
                        var tdDelete = document.createElement("td");
                        var tdDeleteAll = document.createElement("td");

                        tdZaiLiuKaNo.innerHTML = list[i].ZaiLiuKaNo;
                        tdZaiLiuKaNo.name = "zaiLiuKa";
                        tdUserName.innerHTML = list[i].UserName;
                        tdBirthday.innerHTML = list[i].Birthday;
                        tdSex.innerHTML = list[i].Sex;
                        tdQualification.innerHTML = list[i].Qualification;
                        tdAdress.innerHTML = list[i].Adress;
                        tdMotivation.innerHTML = list[i].Motivation;
                        tdPermitDay.innerHTML = list[i].PermitDay;
                        tdBianJi.innerHTML = "<td><button onclick='toEditPage(" + i + ")'>編集</button></td>";
                        tdDelete.innerHTML = "<button type='submit' onclick='deleteAjax(this.id)' id='" + i + "'>削除</button>";
                        tdDeleteAll.innerHTML = "<td><input type='checkbox' id='zai" + i + "'> </td>";

                        
                        tr.appendChild(tdZaiLiuKaNo);
                        tr.appendChild(tdUserName);
                        tr.appendChild(tdBirthday);
                        tr.appendChild(tdSex);
                        tr.appendChild(tdQualification);
                        tr.appendChild(tdAdress);
                        tr.appendChild(tdMotivation);
                        tr.appendChild(tdPermitDay);
                        tr.appendChild(tdBianJi);
                        tr.appendChild(tdDelete);
                        tr.appendChild(tdDeleteAll);

                        zaiLiuKa.appendChild(tr);

                    }
                }
                if (len < value) {
                    for (var i = 0; i < len; i++) {
                        var tr = document.createElement("tr");
                        var tdZaiLiuKaNo = document.createElement("td");
                        var tdUserName = document.createElement("td");
                        var tdBirthday = document.createElement("td");
                        var tdSex = document.createElement("td");
                        var tdQualification = document.createElement("td");
                        var tdAdress = document.createElement("td");
                        var tdMotivation = document.createElement("td");
                        var tdPermitDay = document.createElement("td");
                        var tdBianJi = document.createElement("td");
                        var tdDelete = document.createElement("td");
                        var tdDeleteAll = document.createElement("td");

                        tdZaiLiuKaNo.innerHTML = list[i].ZaiLiuKaNo;
                        tdZaiLiuKaNo.name = "zaiLiuKa";
                        tdUserName.innerHTML = list[i].UserName;
                        tdBirthday.innerHTML = list[i].Birthday;
                        tdSex.innerHTML = list[i].Sex;
                        tdQualification.innerHTML = list[i].Qualification;
                        tdAdress.innerHTML = list[i].Adress;
                        tdMotivation.innerHTML = list[i].Motivation;
                        tdPermitDay.innerHTML = list[i].PermitDay;
                        tdBianJi.innerHTML = "<td><button onclick='toEditPage(" + i + ")'>編集</button></td>";
                        tdDelete.innerHTML = "<button type='submit' onclick='deleteAjax(this.id)' id='" + i + "'>削除</button>";
                        tdDeleteAll.innerHTML = "<td><input type='checkbox' id='zai" + i + "'> </td>";

                      
                        tr.appendChild(tdZaiLiuKaNo);
                        tr.appendChild(tdUserName);
                        tr.appendChild(tdBirthday);
                        tr.appendChild(tdSex);
                        tr.appendChild(tdQualification);
                        tr.appendChild(tdAdress);
                        tr.appendChild(tdMotivation);
                        tr.appendChild(tdPermitDay);
                        tr.appendChild(tdBianJi);
                        tr.appendChild(tdDelete);
                        tr.appendChild(tdDeleteAll);

                        zaiLiuKa.appendChild(tr);
                    }

                }

            }

            if (value == 15) {
                if (len >= value) {
                    for (var i = 0; i < value; i++) {
                        var tr = document.createElement("tr");
                        var tdZaiLiuKaNo = document.createElement("td");
                        var tdUserName = document.createElement("td");
                        var tdBirthday = document.createElement("td");
                        var tdSex = document.createElement("td");
                        var tdQualification = document.createElement("td");
                        var tdAdress = document.createElement("td");
                        var tdMotivation = document.createElement("td");
                        var tdPermitDay = document.createElement("td");
                        var tdBianJi = document.createElement("td");
                        var tdDelete = document.createElement("td");
                        var tdDeleteAll = document.createElement("td");

                        tdZaiLiuKaNo.innerHTML = list[i].ZaiLiuKaNo;
                        tdZaiLiuKaNo.name = "zaiLiuKa";
                        tdUserName.innerHTML = list[i].UserName;
                        tdBirthday.innerHTML = list[i].Birthday;
                        tdSex.innerHTML = list[i].Sex;
                        tdQualification.innerHTML = list[i].Qualification;
                        tdAdress.innerHTML = list[i].Adress;
                        tdMotivation.innerHTML = list[i].Motivation;
                        tdBianJi.innerHTML = "<td><button onclick='toEditPage(" + i + ")'>編集</button></td>";
                        tdDelete.innerHTML = "<button type='submit' onclick='deleteAjax(this.id)' id='" + i + "'>削除</button>";
                        tdDeleteAll.innerHTML = "<td><input type='checkbox' id='zai" + i + "'> </td>";

                        
                        tr.appendChild(tdZaiLiuKaNo);
                        tr.appendChild(tdUserName);
                        tr.appendChild(tdBirthday);
                        tr.appendChild(tdSex);
                        tr.appendChild(tdQualification);
                        tr.appendChild(tdAdress);
                        tr.appendChild(tdMotivation);
                        tr.appendChild(tdPermitDay);
                        tr.appendChild(tdBianJi);
                        tr.appendChild(tdDelete);
                        tr.appendChild(tdDeleteAll);

                        zaiLiuKa.appendChild(tr);

                    }

                }

                if (len < value) {
                    for (var i = 0; i < len; i++) {

                        var tr = document.createElement("tr");
                        var tdZaiLiuKaNo = document.createElement("td");
                        var tdUserName = document.createElement("td");
                        var tdBirthday = document.createElement("td");
                        var tdSex = document.createElement("td");
                        var tdQualification = document.createElement("td");
                        var tdAdress = document.createElement("td");
                        var tdMotivation = document.createElement("td");
                        var tdPermitDay = document.createElement("td");
                        var tdBianJi = document.createElement("td");
                        var tdDelete = document.createElement("td");
                        var tdDeleteAll = document.createElement("td");

                        tdZaiLiuKaNo.innerHTML = list[i].ZaiLiuKaNo;
                        tdZaiLiuKaNo.name = "zaiLiuKa";
                        tdUserName.innerHTML = list[i].UserName;
                        tdBirthday.innerHTML = list[i].Birthday;
                        tdSex.innerHTML = list[i].Sex;
                        tdQualification.innerHTML = list[i].Qualification;
                        tdAdress.innerHTML = list[i].Adress;
                        tdMotivation.innerHTML = list[i].Motivation;
                        tdPermitDay.innerHTML = list[i].PermitDay;
                        tdBianJi.innerHTML = "<td><button onclick='toEditPage(" + i + ")'>編集</button></td>";
                        tdDelete.innerHTML = "<button type='submit' onclick='deleteAjax(this.id)' id='" + i + "'>削除</button>";
                        tdDeleteAll.innerHTML = "<td><input type='checkbox' id='zai" + i + "'> </td>";

                        
                        tr.appendChild(tdZaiLiuKaNo);
                        tr.appendChild(tdUserName);
                        tr.appendChild(tdBirthday);
                        tr.appendChild(tdSex);
                        tr.appendChild(tdQualification);
                        tr.appendChild(tdAdress);
                        tr.appendChild(tdMotivation);
                        tr.appendChild(tdPermitDay);
                        tr.appendChild(tdBianJi);
                        tr.appendChild(tdDelete);
                        tr.appendChild(tdDeleteAll);

                        zaiLiuKa.appendChild(tr);

                    }

                }


            }

          

        }
 










function pageClick(value) {
   
    var zaiLiuKa = document.getElementById("tbb");
    zaiLiuKa.textContent = null;
               if ((value * val) <= len) {
                for (var i = (value - 1) * val; i < value * val; i++) {

                    var tr = document.createElement("tr");
                    var tdZaiLiuKaNo = document.createElement("td");
                    var tdUserName = document.createElement("td");
                    var tdBirthday = document.createElement("td");
                    var tdSex = document.createElement("td");
                    var tdQualification = document.createElement("td");
                    var tdAdress = document.createElement("td");
                    var tdMotivation = document.createElement("td");
                    var tdPermitDay = document.createElement("td");
                    var tdBianJi = document.createElement("td");
                    var tdDelete = document.createElement("td");
                    var tdDeleteAll = document.createElement("td");

                    tdZaiLiuKaNo.innerHTML = list[i].ZaiLiuKaNo;
                    tdZaiLiuKaNo.name = "zaiLiuKa";
                    tdUserName.innerHTML = list[i].UserName;
                    tdBirthday.innerHTML = list[i].Birthday;
                    tdSex.innerHTML = list[i].Sex;
                    tdQualification.innerHTML = list[i].Qualification;
                    tdAdress.innerHTML = list[i].Adress;
                    tdMotivation.innerHTML = list[i].Motivation;
                    tdPermitDay.innerHTML = list[i].PermitDay;
                    tdBianJi.innerHTML = "<td><button onclick='toEditPage(" + i + ")'>編集</button></td>";
                    tdDelete.innerHTML = "<button type='submit' onclick='deleteAjax(this.id)' id='" + i + "'>削除</button>";
                    tdDeleteAll.innerHTML = "<input type='checkbox'  name='delCheck'> ";
                    
                    tr.appendChild(tdZaiLiuKaNo);
                    tr.appendChild(tdUserName);
                    tr.appendChild(tdBirthday);
                    tr.appendChild(tdSex);
                    tr.appendChild(tdQualification);
                    tr.appendChild(tdAdress);
                    tr.appendChild(tdMotivation);
                    tr.appendChild(tdPermitDay);
                    tr.appendChild(tdBianJi);
                    tr.appendChild(tdDelete);
                    tr.appendChild(tdDeleteAll);

                    zaiLiuKa.appendChild(tr);

                }


            }

            if ((value * val) > len) {

                for (var i = (value - 1) * val; i < len; i++) {

                    var tr = document.createElement("tr");
                    var tdZaiLiuKaNo = document.createElement("td");
                    var tdUserName = document.createElement("td");
                    var tdBirthday = document.createElement("td");
                    var tdSex = document.createElement("td");
                    var tdQualification = document.createElement("td");
                    var tdAdress = document.createElement("td");
                    var tdMotivation = document.createElement("td");
                    var tdPermitDay = document.createElement("td");
                    var tdBianJi = document.createElement("td");
                    var tdDelete = document.createElement("td");
                    var tdDeleteAll = document.createElement("td");

                    tdZaiLiuKaNo.innerHTML = list[i].ZaiLiuKaNo;
                    tdZaiLiuKaNo.name = "zaiLiuKa";
                    tdUserName.innerHTML = list[i].UserName;
                    tdBirthday.innerHTML = list[i].Birthday;
                    tdSex.innerHTML = list[i].Sex;
                    tdQualification.innerHTML = list[i].Qualification;
                    tdAdress.innerHTML = list[i].Adress;
                    tdMotivation.innerHTML = list[i].Motivation;
                    tdPermitDay.innerHTML = list[i].PermitDay;
                    tdBianJi.innerHTML = "<td><button onclick='toEditPage(" + i + ")'>編集</button></td>";
                    tdDelete.innerHTML = "<button type='submit' onclick='deleteAjax(this.id)' id='" + i + "'>削除</button>";
                    tdDeleteAll.innerHTML = "<input type='checkbox'  name='delCheck'> ";

                    tr.appendChild(tdZaiLiuKaNo);
                    tr.appendChild(tdUserName);
                    tr.appendChild(tdBirthday);
                    tr.appendChild(tdSex);
                    tr.appendChild(tdQualification);
                    tr.appendChild(tdAdress);
                    tr.appendChild(tdMotivation);
                    tr.appendChild(tdPermitDay);
                    tr.appendChild(tdBianJi);
                    tr.appendChild(tdDelete);
                    tr.appendChild(tdDeleteAll);

                    zaiLiuKa.appendChild(tr);


                }
            }

            if ((value - 1) * val >= len) {

            }


         



        }
    


function sexAjax(sex) {
   
        $.gitAjax({
            type: "POST",
            url: "/ZaiLiuKa/ZaiLiuKaAjax/SearchBySex",
            data: { "sex": sex },
            dataType: "json",
            success: function (result) {             
                //alert(result);
                if (result!= null) {
                    var Html = "";

                    $(result).each(function (i, item) {
                        Html += "<tr>";
                        Html += "<td >" + item.ZaiLiuKaNo + "</td>";
                        Html += "<td>" + item.UserName + "</td>";
                        Html += "<td>" + item.Birthday + "</td>";
                        Html += "<td>" + item.Sex + "</td>";
                        Html += "<td>" + item.Qualification + "</td>";
                        Html += "<td>" + item.Adress + "</td>";
                        Html += "<td>" + item.Motivation + "</td>";
                        Html += "<td>" + item.PermitDay + "</td>";
                        Html += "<td><button onclick='toEditPage(" + i + ")'>編集</button></td>";
                        Html += "<td><button type='submit' onclick='deleteAjax(this.id)' id='" + i + "'>削除</button></td>";
                        Html += "<td><input type='checkbox' id='zai" + i + "'> </td>";
                        Html += "</tr>";
                    })
                    $("#table1 tbody").html(Html);
                }
                else {
                    document.getElementById("tbb").textContent=null;
                }

            },

            error: function () {
                alert("アクセス失敗しました！");

            }

        });

    }







var add=5;
function addBeforePage(){
    if(add>5){ 
        document.getElementById("pages").textContent=null;
        for(var i=add-9;i<=add;i++ ){
            var button = document.createElement("button");
            button.innerHTML=i;
            button.name ="page";
            button.onclick = function () { pageClick(this.innerHTML); };
            document.getElementById("pages").appendChild(button);
        }
        add-=5;
    }


}

    
    
function addAfterPage(){
      
    document.getElementById("pages").textContent=null;
         
    for(var i=add+1;i<=add+10;i++ ){
        var button = document.createElement("button");
        button.innerHTML=i;
        button.onclick = function () { pageClick(this.innerHTML,'@ViewBag.List'); };
        button.name ="page";

        document.getElementById("pages").appendChild(button);

    }

    add+=5;

}









     
function preview(oper){
    if (oper ==1){
        bdhtml=window.document.body.innerHTML;
        sprnstr="<!--startprint"+oper+"-->";
        eprnstr="<!--endprint"+oper+"-->";
        prnhtml=bdhtml.substring(bdhtml.indexOf(sprnstr)+18); 
        prnhtml=prnhtml.substring(0,prnhtml.indexOf(eprnstr));
        window.document.body.innerHTML=prnhtml;
        window.print();
        window.document.body.innerHTML=bdhtml;
    } 
    else {
        window.print();
    }
}



function createCSV(){
    var tr = document.getElementsByTagName("tr");
    var td = document.getElementsByTagName("td");
    var str="";
		
    for(var i=1; i<tr.length;i++){
        for(var j=(i-1)*11; j<(i-1)*11+8; j++){
            str +=td[j].innerHTML+ ",";
        }
        str +="\n";
    }
			
    var link = document.createElement("a"); 
    var csvContent = "data:text/csv;charset=GBK,\uFEFF" + str; 
    var encodedUri = encodeURI(csvContent); 
    link.setAttribute("href", encodedUri);
    link.setAttribute("download", "data.csv");
    document.body.appendChild(link);
    link.click(); 
    document.body.removeChild(link); 
}



function selectAll() {
    //if (val == 0) {
    //    for (var i = 0; i < len; i++) {
    //        var inp = document.getElementsByName(i.toString());
    //        inp[0].checked = true;
    //    }
    //}
   
      
    var tr = document.getElementsByTagName("tr");
   
            for (var i = 1; i < tr.length; i++) {
                var input = tr[i].lastChild.firstChild;
                input.checked = true;
               
           
        }
        
}



function CheckedDeleteAjax() {
   // tableInit();
    var submit = function (v, h, f) {
        if (v == 'ok') {
            var checkedString = "";
            //if (val == 0) {
            //    for (var i = 0; i < len; i++) {
            //        var inp = document.getElementsByName(i);
            //        if (inp[0].checked == true) {
            //            checkedString += list[i].ZaiLiuKaNo + ",";
            //        }
            //    }
            //    var checkedString = checkedString.substr(0, checkedString.length - 1);
            //    alert(checkedString);
            //}

            var tr = document.getElementsByTagName("tr");
            for (var i = 1; i < tr.length - 3; i++) {
                var input = tr[i].lastChild.firstChild;
                if (input.checked) {
                    var td = tr[i].firstElementChild;
                    checkedString += td.innerHTML + ",";
                }
            }
                var checkedString = checkedString.substr(0, checkedString.length - 1);

                //alert(checkedString);

                $.ajax({
                    type: "GET",
                    url: "/ZaiLiuKa/ZaiLiuKaAjax/BatchDel",
                    data: { "zaiLiuKaNo": checkedString },
                    dataType: "json",
                    success: function (result) {
                        if (result.delChecked == "success") {
                            $.jBox.tip("削除しました", "success");

                            //var e = 0;
                            //if (val == 0) {
                            //    for (var i = 0; i < len; i++) {
                            //        var inp = document.getElementsByName(i.toString());
                            //        if (inp[0].checked == true) {
                            //            document.getElementById("tbb").deleteRow(Number(i) + 1 - e);
                            //            e++
                            //        }
                            //    }

                            //}

                        
                            var tr = document.getElementsByTagName("tr");
                            //alert(tr.length);
                            //alert(tr[2].lastChild.firstChild);
                            for (var i = 1; i < tr.length; i++) {
                                var input = tr[i].lastChild.firstChild;
                               // alert(input.checked);
                                if (input.checked) {
                                    //alert(input.id);
                                    document.getElementById(input.id).parentNode.parentNode.innerHTML = null;
                                }
                                                             
                                             
                            }

                        }
                        if (result.delChecked == "error") {
                            $.jBox.tip("削除失敗", "error");
                        }
                    },

                    error: function () {
                        alert("アクセス失敗しました！");

                    }

                });

            }
        }
    

    $.jBox.confirm("選択したもの全部削除しますか？", "提示", submit);

}



function deleteAjax(i) {

    var submit = function (v, h, f) {
        if (v == 'ok') {
            var tr = document.getElementsByTagName("tr");
           var zaiLiuKaNo =tr[Number(i)+1].firstElementChild.innerHTML;

            $.ajax({
                type: "GET",
                url: "/ZaiLiuKa/ZaiLiuKaAjax/Delete",
                data: { "zaiLiuKaNo": zaiLiuKaNo },
                dataType: "json",
                success: function (result) {
                    if (result.delete == "success") {
                        $.jBox.tip("削除しました", "success");
                        if (val != 0) {
                            document.getElementById("tbb").deleteRow(Number(i) % val + 1);
                        }
                        document.getElementById("tbb").deleteRow(Number(i)+1);

                    }
                    if (result.delete == "error") {
                        $.jBox.tip("削除失敗", "error");
                    }
                },
                error: function () {
                    alert("アクセス失敗しました！");

                }
            });
        }
    }
   $.jBox.confirm("削除しますか？", "提示", submit);

}


function pageChange() {
    window.location.href = "/ZaiLiuKa/ZaiLiuKa/Register";
}

var birthYYYY = document.getElementById('birthYYYY');
var birthMM = document.getElementById('birthMM');
var birthDD = document.getElementById('birthDD');

var permitStartYYYY = document.getElementById('permit-startYYYY');
var permitStartMM = document.getElementById('permit-startMM');
var permitStartDD = document.getElementById('permit-startDD');

var permitEndYYYY = document.getElementById('permit-endYYYY');
var permitEndMM = document.getElementById('permit-endMM');
var permitEndDD = document.getElementById('permit-endDD');

function changeYYYY() {
    for (var i = 1; i <= 12; i++) {
        var birthYYYY = document.getElementById('birthYYYY');
        var birthMM = document.getElementById('birthMM');
        var birthDD = document.getElementById('birthDD');

        var permitStartYYYY = document.getElementById('permit-startYYYY');
        var permitStartMM = document.getElementById('permit-startMM');
        var permitStartDD = document.getElementById('permit-startDD');

        var permitEndYYYY = document.getElementById('permit-endYYYY');
        var permitEndMM = document.getElementById('permit-endMM');
        var permitEndDD = document.getElementById('permit-endDD');




        var optionBirthMonth = document.createElement('option');
        var optionPermitStartMonth = document.createElement('option');
        var optionPermitEndMonth = document.createElement('option');

        optionBirthMonth.text = i.toString();
        optionPermitStartMonth.text = i.toString();
        optionPermitEndMonth.text = i.toString();

        optionBirthMonth.value = i;
        optionPermitStartMonth.value = i;
        optionPermitEndMonth.value = i;

        birthMM.options.add(optionBirthMonth);
        permitStartMM.options.add(optionPermitStartMonth);
        permitEndMM.options.add(optionPermitEndMonth);
    }
}

function changeBirthMM() {
    var year = document.getElementById('birthYYYY').value;
    var month = document.getElementById('birthMM').value;
    var birthDD = document.getElementById('birthDD');
    getDays(month, year, birthDD);
}

function changePermitStartMM() {
    var year = document.getElementById('permit-startYYYY').value;
    var month = document.getElementById('permit-startMM').value;
    var permitStartDD = document.getElementById('permit-startDD');
    getDays(month, year, permitStartDD);
}

function changePermitEndMM() {
    var year = document.getElementById('permit-endYYYY').value;
    var month = document.getElementById('permit-endMM').value;
    var permitEndDD = document.getElementById('permit-endDD');
    getDays(month, year, permitEndDD);
}


function getDaysForMonth(month, year) {
    var days;
    if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) {
        days = 31;
    } else if (month == 4 || month == 6 || month == 9 || month == 11) {
        days = 30;
    } else {
        if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0)) {
            days = 29;
        } else {
            days = 28;
        }
    }
    return days;
}



function getDays(month, year, dd) {
    var days = getDaysForMonth(month, year);
    for (var i = 1; i <= days; i++) {
        var optionDay = document.createElement('option');
        optionDay.text = i.toString();
        optionDay.value = i;
        dd.options.add(optionDay);
    }
}





function changeId(value) {
    if (value.replace(" ", "") == 0) {
        alert("在留番号を入力してください！");
    }

    var flg = false;
    for (var i = 0; i < value.length; i++) {
        if (value.charCodeAt(i) == 12288) {//全角空格                
            flg = true;
            continue;
        }
        if (value.charCodeAt(i) >= 127) {//半角字符的unnicode码
            flg = true;
        }
    }
    if (flg) {
        alert("正しい在留番号を入力してください！");
    }

    //   var has = value.match(/[\uff00-\uffff]/g);
    //  if(has!=null){
    //         alert("正しい在留番号を入力してください！");
    //     }

    if (value.length > 12) {
        alert("在留番号は12桁で入力してください。")
    }
}

function changeUserName(value) {
    if (value.replace(" ", "") == 0) {
        alert("氏名を入力してください！");
    }

    // 　var has = value.match(/[\uff00-\uffff]/g);
    //   var chinese = value.match(/[\u4e00-\u9fa5]/g);
    //  　if(has!=null||chinese!=null){
    //         alert("正しい氏名を入力してください！");
    //     }

    var flg = false;
    for (var i = 0; i < value.length; i++) {
        if (value.charCodeAt(i) == 12288) {//全角空格                
            flg = true;
            continue;
        }
        if (value.charCodeAt(i) >= 127) {//半角字符的unnicode码
            flg = true;
        }
    }
    if (flg) {
        alert("正しい氏名を入力してください！");
    }




}

function toEditPage(i) {
    
    var tr = document.getElementsByTagName("tr");
   // alert(i);
    var zaiLiuKaNo = tr[Number(i) + 1].firstElementChild.innerHTML;
    $.ajax({

        type: "POST",
        url: "/ZaiLiuKa/ZaiLiuKa/Change",
        dataType: "json",
        data: { "zaiLiuKaNo": zaiLiuKaNo },
        success: function (result) {
           // alert("toedit");
            window.location.href = "/ZaiLiuKa/ZaiLiuKa/Edit?zaiLiuKaNo=" + result.ZaiLiuKaNo + "&userName=" + result.UserName + "&birthday=" + result.Birthday + "&sex=" + result.Sex + "&qualification=" + result.Qualification + "&adress=" + result.Adress + "&motivation=" + result.Motivation + "&permitDay=" + result.PermitDay;
           
        },
        error: function () {
            alert("アクセス失敗しました！");

        }

    });
               
}

