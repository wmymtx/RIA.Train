;
+(function (w, j, u) {

    var queryConfig = { url: { registerUrl: '/WeChatRequire/CommitContent', success: '/WeChatRequire/Success', Detail:'/WeChatRequire/GetDetail' } };

    function checkName(val) {
        if (removeAllSpace(val) == "") {
            return false;
        }
        else {
            return true;
        }
    }
    function checkPhone(val) {
        var re = /^1\d{10}$/
        if (re.test(val)) {
            return true;
        } else {
            return false;
        }
    }
    function checkWeChat(val) {
        if (removeAllSpace(val) == "") {
            return false;
        }
        else {
            return true;
        }
    }
    function checkAddress(val) {
        if (removeAllSpace(val) == "") {
            return false;
        }
        else {
            return true;
        }
    }
    function removeAllSpace(str) {
        return str.replace(/\s+/g, "");
    }
    function isCardNo(card) {
        // 身份证号码为15位或者18位，15位时全为数字，18位前17位为数字，最后一位是校验位，可能为数字或字符X  
        var reg = /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/;
        if (reg.test(card) === false) {
            return false;
        }
        else {
            return true;
        }
    }


    var pageDom = {
        AllCheckbox: j("[type=checkbox]"),
        trainContent: j("#trainContent"),
        Submit: j("#btnSave")
    };

    var changeValue = [];

    var inOp = {
        Post: function (params) {
            var postParam = params || { url: '', type: 'post' };
            j.ajax({
                type: 'post', url: postParam.url || '', contentType: postParam.contentType || "application/json; charset=utf-8",
                data: JSON.stringify(postParam.data) || {}, dataType: postParam.dataType || "json",
                beforeSend: postParam.beforeSend || function (xhr) {
                    console.log(xhr);
                    console.log('发送前');
                },
                success: postParam.success || function (data) {
                    $.toptip(data.msg, 'success');
                    w.reload();
                },
                error: postParam.error || function (msg) {
                    alert(msg);
                }
            });
        },
        getDetail(id)
        {
            var postParam = {
                data: { id: id }, url: queryConfig.url.Detail, success: function (data) {
                    //$.toptip(data.Msg, 'success');
                    var h = "";
                    for (var index = 0; index <= data.length - 1; index++)
                    {
                        h += ' <div class="weui_cell" ><div class="weui_cell_hd">' + data[index].TrainContent + '</div></div>';
                    }
                    $("#detail_div").empty().append(h);
                }, error: function () {
                    $.toptip("提报失败", 'success');
                }
            }
            inOp.Post(postParam);
        }
        ,
        Save: function () {


            var trainContent = $("#trainContent").val();

            var category = [], categoryName = []; var paramItem = [];
            $('input[name="category"]:checked').each(function () {
                category.push($(this).val());
                var text = $(this).parent().parent().parent().find('textarea')

                paramItem.push({ Fk_Item_Require_Id: $(this).val(), Content: text.val() })
                //categoryName.push($(this).attr('valueName'));
                categoryName.push(text.val());
            });
            
             if (category.length == 0) {
                $.toptip('请选择培训项目！', 'error');
                return;
            }
            console.log(category.toString());

            var param = {};
            param.Content = trainContent;

            //param.ChectKPointId = category.join('|');
            //param.CheckKPoint = categoryName.join('、');
            param.Fk_Item_Require_Id = $("#itemId").val();
            var postParam = {
                data: { T_RequireEditDto: paramItem }, url: queryConfig.url.registerUrl, success: function (data) {
                    //$.toptip(data.Msg, 'success');
                    $.alert('提交成功', "信息提示", function () {
                        //点击确认后的回调函数
                        w.location = queryConfig.url.success;
                    });

                }, error: function () {
                    $.toptip("提报失败", 'success');
                }
            }

            inOp.Post(postParam);
        }
        ,
        init: function () {
            var $content = $("#content");
            pageDom.Submit.on('click', function () {
                inOp.Save();
            });

            $("#btnCancel").on("click", function () {
                $.closePopup();
            });

            $(".title_click").on('click', function () {
                inOp.getDetail($(this).attr('id'));
                $content.popup();
            });
        }
    }

    u.init = inOp.init;

})(window, jQuery, window.ssUser || (window.ssUser = {}));