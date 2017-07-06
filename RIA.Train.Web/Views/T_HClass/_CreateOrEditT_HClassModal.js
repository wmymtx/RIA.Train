app = app || {};
app.modals = app.modals || {};
(function ($) {
    app.modals.CreateOrEditT_HClassModal = function () {

        var _modalManager;

        var _t_HClassService = abp.services.app.t_HClass;

		$(".maxlength-handler").maxlength({
            limitReachedClass: "label label-danger",
            alwaysShow: true,
            threshold: 5,
            placement: 'bottom'
        });

        var _$t_HClassInformationForm = null;


        this.init = function (modalManager) {
            _modalManager = modalManager;
			            _$t_HClassInformationForm = _modalManager.getModal().find("form[name=t_HClassInformationsForm]");

						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


						
			 
			   	 


			
			
      


        }
        
        this.save = function () {
            if (!_$t_HClassInformationForm.valid()) {
                return;
            }
            //校验通过

            var t_HClass = _$t_HClassInformationForm.serializeFormToObject();
          //  console.log(t_HClass);

            _modalManager.setBusy(true);

            _t_HClassService.createOrUpdateT_HClassAsync({
                t_HClassEditDto: t_HClass
            }).done(function () {
                //提示信息
                abp.notify.info(app.localize('SavedSuccessfully'));
                //关闭窗体
                _modalManager.close();
                //信息保存成功后调用事件，刷新列表
                abp.event.trigger('app.createOrEditT_HClassModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        }
    }
})(jQuery);

   