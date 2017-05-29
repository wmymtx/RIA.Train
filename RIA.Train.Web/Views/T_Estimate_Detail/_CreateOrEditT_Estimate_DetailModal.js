
(function ($) {
    app.modals.CreateOrEditT_Estimate_DetailModal = function () {

        var _modalManager;

        var _t_Estimate_DetailService = abp.services.app.t_Estimate_Detail;

		$(".maxlength-handler").maxlength({
            limitReachedClass: "label label-danger",
            alwaysShow: true,
            threshold: 5,
            placement: 'bottom'
        });

        var _$t_Estimate_DetailInformationForm = null;


        this.init = function (modalManager) {
            _modalManager = modalManager;
			            _$t_Estimate_DetailInformationForm = _modalManager.getModal().find("form[name=t_Estimate_DetailInformationsForm]");

						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 	 	 // 初始化 CreateTime 的包含时分秒的日期控件
		   //包含时分秒的日期选择器             
            $("input[name=CreateTime]").datetimepicker({
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
            if (!_$t_Estimate_DetailInformationForm.valid()) {
                return;
            }
            //校验通过

            var t_Estimate_Detail = _$t_Estimate_DetailInformationForm.serializeFormToObject();
          //  console.log(t_Estimate_Detail);

            _modalManager.setBusy(true);

            _t_Estimate_DetailService.createOrUpdateT_Estimate_DetailAsync({
                t_Estimate_DetailEditDto: t_Estimate_Detail
            }).done(function () {
                //提示信息
                abp.notify.info(app.localize('SavedSuccessfully'));
                //关闭窗体
                _modalManager.close();
                //信息保存成功后调用事件，刷新列表
                abp.event.trigger('app.createOrEditT_Estimate_DetailModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        }
    }
})(jQuery);

   