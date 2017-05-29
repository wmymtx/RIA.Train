
(function ($) {
    app.modals.CreateOrEditT_StaffModal = function () {

        var _modalManager;

        var _t_StaffService = abp.services.app.t_Staff;

		$(".maxlength-handler").maxlength({
            limitReachedClass: "label label-danger",
            alwaysShow: true,
            threshold: 5,
            placement: 'bottom'
        });

        var _$t_StaffInformationForm = null;


        this.init = function (modalManager) {
            _modalManager = modalManager;
			            _$t_StaffInformationForm = _modalManager.getModal().find("form[name=t_StaffInformationsForm]");

						
			 
			   	 


						
			 
			   	      
								 //渲染select
								    $("#fK_GroupIdEdit").selectpicker();



						
			 
			   	 


						
			 
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
            if (!_$t_StaffInformationForm.valid()) {
                return;
            }
            //校验通过

            var t_Staff = _$t_StaffInformationForm.serializeFormToObject();
          //  console.log(t_Staff);

            _modalManager.setBusy(true);

            _t_StaffService.createOrUpdateT_StaffAsync({
                t_StaffEditDto: t_Staff
            }).done(function () {
                //提示信息
                abp.notify.info(app.localize('SavedSuccessfully'));
                //关闭窗体
                _modalManager.close();
                //信息保存成功后调用事件，刷新列表
                abp.event.trigger('app.createOrEditT_StaffModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        }
    }
})(jQuery);

   