﻿app = app || {};
app.modals = app.modals || {};
(function ($) {
    app.modals.CreateOrEditT_ItemModal = function () {

        var _modalManager;

        var _t_ItemService = abp.services.app.t_Item;

		$(".maxlength-handler").maxlength({
            limitReachedClass: "label label-danger",
            alwaysShow: true,
            threshold: 5,
            placement: 'bottom'
        });

        var _$t_ItemInformationForm = null;


        this.init = function (modalManager) {
            _modalManager = modalManager;
			            _$t_ItemInformationForm = _modalManager.getModal().find("form[name=t_ItemInformationsForm]");

						
			 
			   	 


						
			 
			   	 


						
			 
			   	 	 	 // 初始化 创建时间 的包含时分秒的日期控件
		  // //包含时分秒的日期选择器             
    //        $("input[name=CreateTime]").datetimepicker({
    //            autoclose: true,
    //            isRTL: false,
    //            format: "yyyy-mm-dd hh:ii",
    //            pickerPosition: ("bottom-left"),
				////默认为E文按钮要中文，自己去找语言包
				//   todayBtn: true,
				//     language: "zh-CN"
    //        });
	 


			
			
      


        }
        
        this.save = function () {
            if (!_$t_ItemInformationForm.valid()) {
                return;
            }
            //校验通过

            var t_Item = _$t_ItemInformationForm.serializeFormToObject();
          //  console.log(t_Item);

            _modalManager.setBusy(true);

            _t_ItemService.createOrUpdateT_ItemAsync({
                t_ItemEditDto: t_Item
            }).done(function () {
                //提示信息
                abp.notify.info(app.localize('SavedSuccessfully'));
                //关闭窗体
                _modalManager.close();
                //信息保存成功后调用事件，刷新列表
                abp.event.trigger('app.createOrEditT_ItemModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        }
    }
})(jQuery);

   