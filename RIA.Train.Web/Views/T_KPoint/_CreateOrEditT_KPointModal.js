
(function ($) {
    app.modals.CreateOrEditT_KPointModal = function () {

        var _modalManager;

        var _t_KPointService = abp.services.app.t_KPoint;

		$(".maxlength-handler").maxlength({
            limitReachedClass: "label label-danger",
            alwaysShow: true,
            threshold: 5,
            placement: 'bottom'
        });

        var _$t_KPointInformationForm = null;


        this.init = function (modalManager) {
            _modalManager = modalManager;
			            _$t_KPointInformationForm = _modalManager.getModal().find("form[name=t_KPointInformationsForm]");

						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


			
			
      


        }
        
        this.save = function () {
            if (!_$t_KPointInformationForm.valid()) {
                return;
            }
            //校验通过

            var t_KPoint = _$t_KPointInformationForm.serializeFormToObject();
          //  console.log(t_KPoint);

            _modalManager.setBusy(true);

            _t_KPointService.createOrUpdateT_KPointAsync({
                t_KPointEditDto: t_KPoint
            }).done(function () {
                //提示信息
                abp.notify.info(app.localize('SavedSuccessfully'));
                //关闭窗体
                _modalManager.close();
                //信息保存成功后调用事件，刷新列表
                abp.event.trigger('app.createOrEditT_KPointModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        }
    }
})(jQuery);

   