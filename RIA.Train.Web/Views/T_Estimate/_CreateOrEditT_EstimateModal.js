
(function ($) {
    app.modals.CreateOrEditT_EstimateModal = function () {

        var _modalManager;

        var _t_EstimateService = abp.services.app.t_Estimate;

		$(".maxlength-handler").maxlength({
            limitReachedClass: "label label-danger",
            alwaysShow: true,
            threshold: 5,
            placement: 'bottom'
        });

        var _$t_EstimateInformationForm = null;


        this.init = function (modalManager) {
            _modalManager = modalManager;
			            _$t_EstimateInformationForm = _modalManager.getModal().find("form[name=t_EstimateInformationsForm]");

						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


			
			
      


        }
        
        this.save = function () {
            if (!_$t_EstimateInformationForm.valid()) {
                return;
            }
            //校验通过

            var t_Estimate = _$t_EstimateInformationForm.serializeFormToObject();
          //  console.log(t_Estimate);

            _modalManager.setBusy(true);

            _t_EstimateService.createOrUpdateT_EstimateAsync({
                t_EstimateEditDto: t_Estimate
            }).done(function () {
                //提示信息
                abp.notify.info(app.localize('SavedSuccessfully'));
                //关闭窗体
                _modalManager.close();
                //信息保存成功后调用事件，刷新列表
                abp.event.trigger('app.createOrEditT_EstimateModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        }
    }
})(jQuery);

   