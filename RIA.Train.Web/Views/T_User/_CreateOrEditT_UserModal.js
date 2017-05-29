
(function ($) {
    app.modals.CreateOrEditT_UserModal = function () {

        var _modalManager;

        var _t_UserService = abp.services.app.t_User;

		$(".maxlength-handler").maxlength({
            limitReachedClass: "label label-danger",
            alwaysShow: true,
            threshold: 5,
            placement: 'bottom'
        });

        var _$t_UserInformationForm = null;


        this.init = function (modalManager) {
            _modalManager = modalManager;
			            _$t_UserInformationForm = _modalManager.getModal().find("form[name=t_UserInformationsForm]");

						
			 
			   	 


						
			 
			   	      
								 //渲染select
								    $("#fK_StaffIdEdit").selectpicker();



						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 	 	 // 初始化 CreteTime 的包含时分秒的日期控件
		   //包含时分秒的日期选择器             
            $("input[name=CreteTime]").datetimepicker({
                autoclose: true,
                isRTL: false,
                format: "yyyy-mm-dd hh:ii",
                pickerPosition: ("bottom-left"),
				//默认为E文按钮要中文，自己去找语言包
				   todayBtn: true,
				     language: "zh-CN"
            });
	 


			
			
      


        }
        
        this.save = function () {
            if (!_$t_UserInformationForm.valid()) {
                return;
            }
            //校验通过

            var t_User = _$t_UserInformationForm.serializeFormToObject();
          //  console.log(t_User);

            _modalManager.setBusy(true);

            _t_UserService.createOrUpdateT_UserAsync({
                t_UserEditDto: t_User
            }).done(function () {
                //提示信息
                abp.notify.info(app.localize('SavedSuccessfully'));
                //关闭窗体
                _modalManager.close();
                //信息保存成功后调用事件，刷新列表
                abp.event.trigger('app.createOrEditT_UserModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        }
    }
})(jQuery);

   