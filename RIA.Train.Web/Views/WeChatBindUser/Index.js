(function (w, j, u) {

    var queryConfig = { url: { registerUrl: '/WeChatBindUser/Register' } };

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
        loginNo: j("#loginNo"),
        password: j("#password"),
        Submit: j("#submit")
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

            var login = pageDom.loginNo.val();
            var pwd = pageDom.password.val();

            if (login == "") {
                $.toptip('工资号不能为空！', 'error');
                return;

            } else if (password == "") {
                $.toptip('密码不能为空！', 'error');
                return;
            }

            var param = {};
            param.LoginNo = login;
            param.Password = pwd;
            param.OpenId = openId;
            //param.RetUrl = retUrl;


            var postParam = {
                data: param, url: queryConfig.url.registerUrl, success: function (data) {
                    //$.toptip(data.Msg, 'success');
                    if (data.result.code == 200) {
                        $.alert(data.result.msg, "信息提示", function () {
                            //点击确认后的回调函数
                            w.location = retUrl;
                        });
                    }
                    else {
                        $.toptip(data.result.msg, 'error');
                    }

                }, error: function () {
                    $.toptip("注册失败", 'success');
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