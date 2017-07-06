;
+(function (w, j, u) {

    var queryConfig = { url: { registerUrl: '/WeChatEstimate/CommitTrain', success: '/WeChatRequire/Success' } };

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
        Save: function () {


            var trainContent = $("#trainContent").val();

            var category = [], categoryName = [];
            $('input[type="radio"]:checked').each(function () {
                category.push($(this).val());

            });
            if (category.length <= 3) {
                $.toptip('请全部点评！', 'error');
                return;
            }

            var param = {};
            param.Content = trainContent;

            param.ChectKPointId = category.join('|');
            param.FK_ClassId = categoryName.join('、');
            param.FK_ClassId = $("#itemId").val();
            var paramArr = [];
            for (var index = 0; index <= category.length - 1; index++) {
                var items = category[index].split('+');
                paramArr.push({ FK_ClassId: param.FK_ClassId, FK_ContentId: items[1], FK_GradeId: items[0] });
            }
            console.log(paramArr);
            var postParam = {
                data: { CommitTrain: paramArr }, url: queryConfig.url.registerUrl, success: function (data) {
                    //$.toptip(data.Msg, 'success');
                    $.alert(data.Msg, "信息提示", function () {
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

            pageDom.Submit.on('click', function () {
                inOp.Save();
            });
        }
    }

    u.init = inOp.init;

})(window, jQuery, window.ssUser || (window.ssUser = {}));