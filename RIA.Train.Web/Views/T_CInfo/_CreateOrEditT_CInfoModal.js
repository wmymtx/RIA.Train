app = app || {};
app.modals = app.modals || {};
(function ($) {
    app.modals.CreateOrEditT_CInfoModal = function () {

        var _modalManager;

        var _t_CInfoService = abp.services.app.t_CInfo;

		$(".maxlength-handler").maxlength({
            limitReachedClass: "label label-danger",
            alwaysShow: true,
            threshold: 5,
            placement: 'bottom'
        });

        var _$t_CInfoInformationForm = null;


        this.init = function (modalManager) {
            _modalManager = modalManager;
			            _$t_CInfoInformationForm = _modalManager.getModal().find("form[name=t_CInfoInformationsForm]");

						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


			
			
      


        }
        
        this.save = function () {
            if (!_$t_CInfoInformationForm.valid()) {
                return;
            }
            //校验通过

            var t_CInfo = _$t_CInfoInformationForm.serializeFormToObject();
          //  console.log(t_CInfo);

            _modalManager.setBusy(true);

            _t_CInfoService.createOrUpdateT_CInfoAsync({
                t_CInfoEditDto: t_CInfo
            }).done(function () {
                //提示信息
                abp.notify.info(app.localize('SavedSuccessfully'));
                //关闭窗体
                _modalManager.close();
                //信息保存成功后调用事件，刷新列表
                abp.event.trigger('app.createOrEditT_CInfoModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        }
    }
})(jQuery);

   